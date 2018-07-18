using SRL.Data_Access.Entity;
using SRL.Models.SSCC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRL.Data_Access.Adapter
{
    public static class SSCCDetailAdapter
    {
        public static SSCCDetailsModel ConvertSSCCDetails(
            API_SSCC_ORDER_DETAILS_Result odResult,
            IEnumerable<API_SSCC_LOADCARRIER_DETAILS_Result> lcResult,
            IEnumerable<API_SSCC_PALLET_COUNTING_Result> pcResult,
            IEnumerable<API_SSCC_IMAGES_Result> imgResult,
            IEnumerable<API_SSCC_DEVIATION_DETAILS_Result> devResult)
        {
            // Create new SSCCDetailsViewModel
            SSCCDetailsModel sdModel = new SSCCDetailsModel();

            #region SSCCOrderDetails
            // Fill SSCCOrderDetailsModel from queryresult
            SSCCOrderDetailsModel odm = new SSCCOrderDetailsModel();
            odm.OrderNumber = odResult.ORDER_NUMBER;
            odm.SsccNumber = odResult.SSCC;
            odm.PhysicalFrom = odResult.PHYSICAL_FROM;
            odm.PhysicalTo = odResult.PHYSICAL_TO;
            odm.AnomaliesCount = devResult.Count();
            odm.ValidationDeadline = odResult.VALIDATION_DEADLINE;
            sdModel.OrderDetails = odm;
            #endregion

            #region SSCCLoadCarrier
            // Fill SSCCLoadCarrierModel from queryresult
            List<SSCCLoadCarrierModel> lcList = new List<SSCCLoadCarrierModel>();
            foreach (var item in lcResult)
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

            //Get a list of the different COUNTING_TYPES and loop through them
            List<string> types = pcResult.Select(o => o.COUNTING_TYPE).Distinct().ToList();
            foreach (string type in types)
            {
                int counter = 1;
                SSCCPalletCountingModel pcm = new SSCCPalletCountingModel();

                // Select the rows from the queryresult on COUNTING_TYPE
                List<API_SSCC_PALLET_COUNTING_Result> tList = pcResult.Where(o => o.COUNTING_TYPE == type).ToList();
                foreach (var t in tList)
                {
                    switch (t.RTI_NAME)
                    {
                        case "H-Container":
                            pcm.HContainerCount = t.QTY_RTI;
                            break;
                        case "M-Container":
                            pcm.MContainerCount = t.QTY_RTI;
                            break;
                        case "L-Container":
                            pcm.LContainerCount = t.QTY_RTI;
                            break;
                        default:
                            pcm.UnsortedCount = t.QTY_RTI;
                            break;
                    }

                    // Avoid the duplicate information in the query result
                    if (counter == 1)
                    {
                        pcm.CountingType = type;
                        pcm.LoadCarrierName = t.LOAD_CARRIER_NAME;
                        pcm.ReturnedValue = t.RETURNED_VALUE;
                        //pcm.ExpectedValueMin = t.EXPECTED_VALUE_MIN;
                        //pcm.ExpectedValueMax = t.EXPECTED_VALUE_MAX;
                        if (t.EXPECTED_VALUE_MIN == t.EXPECTED_VALUE_MAX)
                            pcm.ExpectedValueMinMax = t.EXPECTED_VALUE_MIN.Value.ToString();
                        else
                            pcm.ExpectedValueMinMax = t.EXPECTED_VALUE_MIN + " - " + t.EXPECTED_VALUE_MAX;
                        pcm.Unit = t.UNIT;
                        if (pcm.ReturnedValue <= t.EXPECTED_VALUE_MIN)
                        {
                            pcm.Deviation = pcm.ReturnedValue - t.EXPECTED_VALUE_MIN;
                        }
                        else if (pcm.ReturnedValue >= t.EXPECTED_VALUE_MAX)
                        {
                            pcm.Deviation = pcm.ReturnedValue - t.EXPECTED_VALUE_MAX;
                        }
                        else
                        {
                            pcm.Deviation = 0;
                        }
                        pcm.Actor = t.ACTOR_ORIGIN;
                    }
                    pcm.CountingResult = pcm.HContainerCount + pcm.MContainerCount + pcm.LContainerCount + pcm.UnsortedCount;
                    counter++;
                }
                pcList.Add(pcm);
            }
            sdModel.PalletCountingList = pcList;
            #endregion

            #region SSCC Images
            // Fill the list of SSCCDetailsImagesModels
            List<SSCCImagesModel> imageList = new List<SSCCImagesModel>();
            foreach (var item in imgResult)
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
            foreach (var item in devResult)
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
