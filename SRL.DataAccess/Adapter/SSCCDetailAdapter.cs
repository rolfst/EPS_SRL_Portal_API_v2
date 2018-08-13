using SRL.Data_Access.Entity;
using SRL.Models.SSCC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SRL.Data_Access.Adapter
{
    public static class SSCCDetailAdapter
    {
        private const string CUSTOMERCOUNTING = "Customer Counting";
        private const string CICOUNTING = "C&I Counting";
        private const string REALLOCATIONCOUNTING = "Reallocation";
        public static SSCCDetailsModel ConvertSSCCDetails(
            API_LCP_ORDER_DETAILS_Result orderDetailResult,
            IEnumerable<API_LCP_TRANSACTIONS_Result> transactionsResult,
            IEnumerable<API_LCP_COUNTING_Result> countingResult,
            IEnumerable<API_LCP_IMAGES_Result> imagesResult,
            IEnumerable<API_LCP_DEVIATIONS_Result> deviationsResult)
        {
            var now = DateTime.Now;

            // Create new SSCCDetailsViewModel
            SSCCDetailsModel sdModel = new SSCCDetailsModel();

            #region SSCCOrderDetails
            // Fill SSCCOrderDetailsModel from queryresult
            SSCCOrderDetailsModel odm = new SSCCOrderDetailsModel();
            odm.OrderNumber = orderDetailResult.ORDER_NUMBER;
            odm.SsccNumber = orderDetailResult.SSCC;
            odm.PhysicalFrom = orderDetailResult.PHYSICAL_FROM;
            odm.PhysicalTo = orderDetailResult.PHYSICAL_TO;
            odm.TransportedBy = orderDetailResult.TRANSPORTED_BY;

            switch (orderDetailResult.SSCC_STATUS)
            {
                case 1:
                    odm.SsccStatus = "New";
                    break;
                case 2:
                    odm.SsccStatus = "Processed";
                    break;
                case 3:
                    odm.SsccStatus = "Validated";
                    break;
                default:
                    odm.SsccStatus = "New";
                    break;
            }

            odm.AnomaliesCount = deviationsResult.Count();
            if (orderDetailResult.VALIDATION_DEADLINE.HasValue)
            {
                odm.ValidationDeadline = Math.Round((orderDetailResult.VALIDATION_DEADLINE.Value - now).TotalHours, 0);
            }
            odm.Validated = orderDetailResult.VALIDATED;

            sdModel.OrderDetails = odm;
            #endregion

            #region SSCCLoadCarrier
            // Fill SSCCLoadCarrierModel from queryresult
            List<SSCCLoadCarrierModel> lcList = new List<SSCCLoadCarrierModel>();
            foreach (var item in transactionsResult)
            {
                SSCCLoadCarrierModel lcm = new SSCCLoadCarrierModel();
                lcm.TransactionDate = item.TRANSACTION_DATETIME;
                lcm.Actor = item.ACTOR_NAME;
                lcm.TransactionType = item.TRANSACTION_TYPE_ID;
                lcm.TransactionSubType = item.TRANSACTION_SUBTYPE;
                lcm.DeviceCode = item.DEVICE_CODE;
                lcm.IsValidated = item.VALIDATED;
                lcList.Add(lcm);
            }
            sdModel.LoadCarrierList = lcList;
            #endregion

            #region SSCC Pallet Counting
            // Fill SSCCPalletCountingModel from queryresult
            // The queryresult returns duplicate information on records with different RTI_NAMES per COUNTING_TYPE
            List<SSCCPalletCountingModel> pcList = new List<SSCCPalletCountingModel>();

            //Get a list of containers used and loop through them
            List<string> containers = countingResult.Select(o => o.RTI_NAME).Distinct().ToList();

            foreach (string container in containers)
            {
                List<API_LCP_COUNTING_Result> tList = countingResult.Where(o => o.RTI_NAME == container).ToList();
                API_LCP_COUNTING_Result item = tList.First();
                SSCCPalletCountingModel pcm = new SSCCPalletCountingModel()
                {
                    ContainerName = item.RTI_NAME,
                    Esoft_Packing_Id = item.ESOFT_PACKING_ID?? 0,
                    LoadCarrierName = item.LOAD_CARRIER_NAME,
                    LoadCarrierEAN = item.LOAD_CARRIER_EAN,
                    ReturnedValue = item.RETURNED_VALUE,
                    Actor = item.ACTOR_ORIGIN,
                    ActorId = item.ACTOR_ID,
                    ExpectedValueMinMax = item.EXPECTED_VALUE_MIN == item.EXPECTED_VALUE_MAX ? item.EXPECTED_VALUE_MIN.Value.ToString() : item.EXPECTED_VALUE_MIN + " - " + item.EXPECTED_VALUE_MAX,
                    Unit = item.UNIT,
                    Deviation = item.RETURNED_VALUE <= item.EXPECTED_VALUE_MIN ? item.RETURNED_VALUE - item.EXPECTED_VALUE_MIN :
                    item.RETURNED_VALUE >= item.EXPECTED_VALUE_MAX ? item.RETURNED_VALUE - item.EXPECTED_VALUE_MAX : 0,
                };

                foreach (var qtyItem in tList)
                {
                    switch (qtyItem.COUNTING_TYPE)
                    {
                        case CUSTOMERCOUNTING:
                            pcm.CustomerCountingQty = qtyItem.QTY_RTI;
                            break;
                        case CICOUNTING:
                            pcm.CICountingQty = qtyItem.QTY_RTI;
                            break;
                        case REALLOCATIONCOUNTING:
                            pcm.ReallocationQty = qtyItem.QTY_RTI;
                            break;
                    }

                }

                pcList.Add(pcm);
            }
            sdModel.PalletCountingList = pcList;

            //To get the total quantity counts
            sdModel.TotalCustomerCounting = sdModel.PalletCountingList.Select(p => p.CustomerCountingQty).Sum();
            sdModel.TotalCICounting = sdModel.PalletCountingList.Select(p => p.CICountingQty).Sum();
            sdModel.TotalReallocationCounting = sdModel.PalletCountingList.Select(p => p.ReallocationQty).Sum();

            #region oldCode
            ////Get a list of the different COUNTING_TYPES and loop through them
            //List<string> types = countingResult.Select(o => o.COUNTING_TYPE).Distinct().ToList();
            //    foreach (string type in types)
            //    {
            //        int counter = 1;
            //SSCCPalletCountingModel pcm = new SSCCPalletCountingModel();

            //// Select the rows from the queryresult on COUNTING_TYPE
            //List<API_LCP_COUNTING_Result> tList = countingResult.Where(o => o.COUNTING_TYPE == type).ToList();
            //        foreach (var t in tList)
            //        {
            //            switch (t.RTI_NAME)
            //            {
            //                case "H-Container":
            //                    pcm.HContainerCount = t.QTY_RTI;
            //                    break;
            //                case "M-Container":
            //                    pcm.MContainerCount = t.QTY_RTI;
            //                    break;
            //                case "L-Container":
            //                    pcm.LContainerCount = t.QTY_RTI;
            //                    break;
            //                default:
            //                    pcm.UnsortedCount = t.QTY_RTI;
            //                    break;
            //            }

            //            // Avoid the duplicate information in the query result
            //            if (counter == 1)
            //            {
            //                pcm.CountingType = type;
            //                pcm.LoadCarrierName = t.LOAD_CARRIER_NAME;
            //                pcm.ReturnedValue = t.RETURNED_VALUE;
            //                //pcm.ExpectedValueMin = t.EXPECTED_VALUE_MIN;
            //                //pcm.ExpectedValueMax = t.EXPECTED_VALUE_MAX;
            //                if (t.EXPECTED_VALUE_MIN == t.EXPECTED_VALUE_MAX)
            //                    pcm.ExpectedValueMinMax = t.EXPECTED_VALUE_MIN.Value.ToString();
            //                else
            //                    pcm.ExpectedValueMinMax = t.EXPECTED_VALUE_MIN + " - " + t.EXPECTED_VALUE_MAX;
            //                pcm.Unit = t.UNIT;
            //                if (pcm.ReturnedValue <= t.EXPECTED_VALUE_MIN)
            //                {
            //                    pcm.Deviation = pcm.ReturnedValue - t.EXPECTED_VALUE_MIN;
            //                }
            //                else if (pcm.ReturnedValue >= t.EXPECTED_VALUE_MAX)
            //                {
            //                    pcm.Deviation = pcm.ReturnedValue - t.EXPECTED_VALUE_MAX;
            //                }
            //                else
            //                {
            //                    pcm.Deviation = 0;
            //                }
            //                pcm.Actor = t.ACTOR_ORIGIN;
            //            }
            //            pcm.CountingResult = pcm.HContainerCount + pcm.MContainerCount + pcm.LContainerCount + pcm.UnsortedCount;
            //            counter++;
            //        }
            //  pcList.Add(pcm);
            //   }
            //sdModel.PalletCountingList = pcList;
            #endregion

            #endregion

            #region SSCC Images
            // Fill the list of SSCCDetailsImagesModels
            List<SSCCImagesModel> imageList = new List<SSCCImagesModel>();
            foreach (var item in imagesResult)
            {
                SSCCImagesModel imageVm = new SSCCImagesModel();
                imageVm.ImagePath = item.PICTURE_EVIDENCE_PATH;
                imageVm.PicturePosition = item.PICTURE_POSITION;
                imageVm.PalletPosition = item.PALLET_POSITION;
                imageList.Add(imageVm);
            }
            sdModel.ImageList = imageList;
            #endregion

            #region SSCC Deviation Details
            // Fill deviations
            SSCCDeviationsModel deviations = new SSCCDeviationsModel();
            int i = 1;
            foreach (var item in deviationsResult)
            {
                if (i == 1)
                {
                    deviations.TransactionDateTime = item.TRANSACTION_DATETIME;
                    deviations.DeviationReasonList = new List<string>();
                }
                deviations.DeviationReasonList.Add(item.LOAD_UNIT_CONDITION_NAME);
                i++;
            }
            sdModel.DeviationDetailsList = deviations;
            #endregion

            return sdModel;
        }
    }
}
