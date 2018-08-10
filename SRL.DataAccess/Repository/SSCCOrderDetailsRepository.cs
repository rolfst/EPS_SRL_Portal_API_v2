using SRL.Data_Access.Common;
using SRL.Data_Access.Entity;
using SRL.Models.SSCC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRL.Data_Access.Repository
{
    public class SSCCOrderDetailsRepository
    {
        public API_LCP_ORDER_DETAILS_Result GetSSCCOrderDetails(string id)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                var orderDetails = dbEntity.API_LCP_ORDER_DETAILS(id).FirstOrDefault();

                return orderDetails;
            }
        }

        public int SaveSSCC(SSCCEditIntermediate request)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities1())
            {
                var isSuccess = dbEntity.API_INSERT_CHANGE(request.SSCC, request.OrderNumber, request.NewOrderNumber, request.OldActor, request.NewActor, request.LoadMessageStatusId, request.UpdateDate,
                        request.UpdateUser, request.OldLoadUnitConditionCode, request.NewLoadUnitConditionCode, request.OldQtyRTI, request.ESoftPackingId, request.NewQtyRTI,
                        request.DeleteSSCC, request.OldSSCC, request.NewSSCC, request.TRAItemInId, request.SLACode, request.Time, request.Validation, request.OldLoadUnitConditionSubCode,
                        request.NewLoadUnitConditionSubCode, request.VoidSSCC, request.OldLoadCarrierEAN, request.NewLoadCarrierEAN);

                return isSuccess.FirstOrDefault().Value;
            }

        }
        public string EditSSCC(SSCCEditRequest request)
        {
            StringBuilder message = new StringBuilder();
            SSCCEditIntermediate requestObj = new SSCCEditIntermediate()
            {
                SSCC = request.SSCC,
                UpdateDate = request.UpdateDate,
                UpdateUser = request.UpdateUser,
                Time = request.Time,
                LoadMessageStatusId = request.LoadMessageStatusId,
                OrderNumber = request.OrderNumber
            };

            //To save SSCC number
            if(!string.IsNullOrEmpty(request.NewSSCC))
            {
                requestObj.NewSSCC = request.NewSSCC;
                requestObj.OldSSCC = request.OldSSCC;
                if (SaveSSCC(requestObj) == 0)
                {
                    message.Append(string.Format("Insert failed for new SSCC number {0}", requestObj.NewSSCC));
                }
                requestObj.NewSSCC = null;
                requestObj.OldSSCC = null;
            }

            //To save Actor Origin
            if(request.NewActor.HasValue)
            {
                requestObj.NewActor = request.NewActor;
                requestObj.OldActor = request.OldActor;
                if (SaveSSCC(requestObj) == 0)
                {
                    message.Append("Insert failed for the new actor origin");
                }
                requestObj.NewActor = null;
                requestObj.OldActor = null;
            }

            //To save Order number
            if (request.NewOrderNumber.HasValue)
            {
                requestObj.NewOrderNumber = request.NewOrderNumber;
                requestObj.OrderNumber = request.OrderNumber;
                if (SaveSSCC(requestObj) == 0)
                {
                    message.Append(string.Format("Insert failed for new Order number {0}", requestObj.NewOrderNumber.Value));
                }
                requestObj.NewOrderNumber = null;
            }

            ///To save ITR quantities
            if (request.RTIQuantities!= null && request.RTIQuantities.Any())
            {
                foreach (SSCCEditRTIQty item in request.RTIQuantities)
                {
                    requestObj.NewQtyRTI = item.NewQtyRTI;
                    requestObj.OldQtyRTI = item.OldQtyRTI;
                    requestObj.ESoftPackingId = item.ESoftPackingId;
                    if (SaveSSCC(requestObj) == 0)
                    {
                        message.Append(string.Format("Insert failed for new RTI quantity {0} for TRA Code {1}", requestObj.NewQtyRTI, requestObj.ESoftPackingId));
                    }
                    requestObj.NewQtyRTI = null;
                    requestObj.OldQtyRTI = null;
                    requestObj.ESoftPackingId = null;
                }
            }
            //To save load carrier 
            if (!string.IsNullOrEmpty(request.NewLoadCarrierEAN))
            {
                requestObj.OldLoadCarrierEAN = request.OldLoadCarrierEAN;
                requestObj.NewLoadCarrierEAN = request.NewLoadCarrierEAN;
                if (SaveSSCC(requestObj) == 0)
                {
                    message.Append(string.Format("Insert failed for new load carrier {0}", requestObj.NewLoadCarrierEAN));
                }
                requestObj.OldLoadCarrierEAN = null;
                requestObj.NewLoadCarrierEAN = null;
            }

            return message.ToString();

        }
    }
}
