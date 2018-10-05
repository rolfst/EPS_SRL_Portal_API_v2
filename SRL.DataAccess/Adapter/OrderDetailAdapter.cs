using SRL.Data_Access.Entity;
using SRL.Models.Enums;
using SRL.Models.Order;
using System.Collections.Generic;
using System.Linq;
using SRL.Data_Access.Common;

namespace SRL.Data_Access.Adapter
{
    public static class OrderDetailAdapter
    {
        const string NOREFERENCE = "No reference";
        const string REALLOCATION = "Reallocation";
        internal static OrderDetail ConvertOrderDetailResult(this GetOrderDetail_Result orderDetail)
        {
            if (orderDetail == null)
            {
                return new OrderDetail();
            }
            OrderDetail result =
             new OrderDetail
             {
                 OrderId = orderDetail.ID_ORDER,
                 OrderNumber = orderDetail.ORD_ORDER_NUMBER,
                 FromActorName = orderDetail.FROM_NAME,
                 FromActorAddressLine1 = orderDetail.FROM_ADDRESSLINE1,
                 FromActorAddressLine2 = orderDetail.FROM_ADDRESSLINE2,
                 ToActorName = orderDetail.TO_NAME,
                 ToActorAddressLine1 = orderDetail.TO_ADDRESSLINE1,
                 ToActorAddressLine2 = orderDetail.TO_ADDRESSLINE2,
                 Status = ((OrderStatus)orderDetail.ORDER_STATUS).GetOrderStatusDescription(),
                 FirstReceiptDate = orderDetail.UNLOADING_DATE,
                 CIDate = orderDetail.CI_DATE,
                 TotalSSCCs = orderDetail.INBOUND_SSCC_ON_ORDER,
                 OpenSSCCs = orderDetail.NUMBER_SSCC_ON_ORDER_OPEN ?? 0,
                 ApprovedSSCCs = orderDetail.NUMBER_SSCC_ON_ORDER_VALIDATED ?? 0,
                 OutBound = orderDetail.OUTBOUND_SSCC_ON_ORDER,
                 InBound = orderDetail.INBOUND_SSCC_ON_ORDER,
                 CI = orderDetail.CI_SSCC_ON_ORDER,
                 ValidationDeadline = orderDetail.VALIDATION_DEADLINE
             };
            result.ToApprovedPercentage = result.TotalSSCCs.HasValue ?(result.OpenSSCCs / result.TotalSSCCs.Value) * 100 : 0;
            return result;
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
                    HasAnomalies = obj.HAS_ANOMALIES
                };
                ssccObj.Deviation = ssccObj.ReturnedValue <= ssccObj.ExpectedValueMin ? ssccObj.ReturnedValue - ssccObj.ExpectedValueMin :
                    ssccObj.ReturnedValue >= ssccObj.ExpectedValueMax ? ssccObj.ReturnedValue - ssccObj.ExpectedValueMax : 0;
                foreach (var item in listObj)
                {
                    rTIQties.Add(new RTIQty
                    {
                        ContainerName = item.RTI_NAME,
                        EsoftPackingId = item.ESOFT_PACKING_ID,
                        RTIQuantity = item.QTY_RTI
                    });
                }
                ssccObj.RTIQuantities = rTIQties;
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
                    case 4:
                        ssccObj.SSCCStatus = "Processing";
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
