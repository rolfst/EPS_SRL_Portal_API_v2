using SRL.Data_Access.Entity;
using SRL.Models.Enums;
using SRL.Models.Order;
using System.Collections.Generic;
using System.Linq;


namespace SRL.Data_Access.Adapter
{
    public static class OrderDetailAdapter
    {
        const string NoReference = "No reference";
        const string REALLOCATION = "Reallocation";
        internal static OrderDetail ConvertOrderDetailResult(this GetOrderDetail_Result orderDetail)
        {
            if (orderDetail == null)
            {
                return new OrderDetail();
            }

            return new OrderDetail
            {
                OrderNumber = orderDetail.ORD_ORDER_NUMBER,
                FromActorName = orderDetail.FROM_NAME,
                FromActorAddressLine1 = orderDetail.FROM_ADDRESSLINE1,
                FromActorAddressLine2 = orderDetail.FROM_ADDRESSLINE2,
                ToActorName = orderDetail.TO_NAME,
                ToActorAddressLine1 = orderDetail.TO_ADDRESSLINE1,
                ToActorAddressLine2 = orderDetail.TO_ADDRESSLINE2,
                Status = (OrderStatus)orderDetail.ORDER_STATUS,
                OrderDate = orderDetail.ORDER_DATE,
                UnloadingDate = orderDetail.UNLOADING_DATE,
                Transport = string.Empty, //Not known yet
                CIDate = orderDetail.CI_DATE,
                ShipmentNumber = orderDetail.TOUR_NUMBER ?? string.Empty,
                Reference = orderDetail.ORD_CUSTOMER_REFERENCE ?? NoReference,
                Transporter = orderDetail.SHIPMENT_COMPANY_NAME ?? string.Empty,
                LicensePlate = orderDetail.LICENSE_PLATE ?? string.Empty,
                TotalSSCCs = orderDetail.OUTBOUND_SSCC_ON_ORDER,
                OpenSSCCs = orderDetail.NUMBER_SSCC_ON_ORDER_OPEN ?? 0,
                ApprovedSSCCs = orderDetail.NUMBER_SSCC_ON_ORDER_VALIDATED ?? 0,
                ToApprovedPercentage = orderDetail.OUTBOUND_SSCC_ON_ORDER.HasValue ? (orderDetail.NUMBER_SSCC_ON_ORDER_OPEN ?? 0 / orderDetail.OUTBOUND_SSCC_ON_ORDER.Value) * 100 : 0
            };
        }
        internal static List<SSCCDetailForOrder> ConvertSSCCListForOrder(this List<API_LIST_SSCC_ON_ORDER_Result> ssccList)
        {
            List<SSCCDetailForOrder> sSSCCForOrder = new List<SSCCDetailForOrder>();
            //To fetch all SSCCs into a list
            List<string> SSCCs = ssccList.Select(s => s.SSCC).Distinct().ToList();
            foreach (string sscc in SSCCs)
            {
                //fetch all records for a particular SSCC
                List<API_LIST_SSCC_ON_ORDER_Result> listObj = ssccList.Where(s => s.SSCC == sscc).ToList();
                List<RTIQty> rTIQties = new List<RTIQty>();
                API_LIST_SSCC_ON_ORDER_Result obj = listObj.FirstOrDefault();
                SSCCDetailForOrder ssccObj = new SSCCDetailForOrder()
                {
                    SSCC = obj.SSCC,
                    ActorOrigin = obj.ACTOR_ORIGIN,
                    Unit = obj.UNIT,
                    LoadCarrierName = obj.LOAD_CARRIER_NAME,
                    ReturnedValue = obj.RETURNED_VALUE ?? 0,
                    ExpectedValue = obj.EXPECTED_VALUE_MIN == obj.EXPECTED_VALUE_MAX ? obj.EXPECTED_VALUE_MIN.Value.ToString() : obj.EXPECTED_VALUE_MIN + " - " + obj.EXPECTED_VALUE_MAX,
                    ExpectedValueMax = obj.EXPECTED_VALUE_MAX ?? 0,
                    ExpectedValueMin = obj.EXPECTED_VALUE_MIN ?? 0,
                };
                ssccObj.Deviation = ssccObj.ReturnedValue <= ssccObj.ExpectedValueMin ? ssccObj.ReturnedValue - ssccObj.ExpectedValueMin :
                    ssccObj.ReturnedValue >= ssccObj.ExpectedValueMax ? ssccObj.ReturnedValue - ssccObj.ExpectedValueMax : 0;
                foreach(var item in listObj)
                {
                    rTIQties.Add(new RTIQty {
                        ContainerName = item.RTI_NAME,
                        EsoftPackingId = item.ESOFT_PACKING_ID,
                        RTIQuantity = item.QTY_RTI
                    });
                }
                ssccObj.RTIQuatities = rTIQties;
                ssccObj.TotalCounting = rTIQties.Sum(s => s.RTIQuantity);
                //Set the status
                switch (obj.SSCC_STATUS)
                {
                    case 1:
                        ssccObj.SSCCStatus = "New";
                        break;
                    case 2:
                        ssccObj.SSCCStatus = "Processed";
                        break;
                    case 3:
                        ssccObj.SSCCStatus = "Validated";
                        break;
                    default:
                        ssccObj.SSCCStatus = "New";
                        break;
                }

                sSSCCForOrder.Add(ssccObj);
            }
            return sSSCCForOrder;
        }
      
    }
}
