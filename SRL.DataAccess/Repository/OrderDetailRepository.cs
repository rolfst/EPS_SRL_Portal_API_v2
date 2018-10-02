using System.Linq;
using SRL.Data_Access.Entity;
using SRL.Data_Access.Adapter;
using SRL.Models.Order;
using System.Collections.Generic;


namespace SRL.Data_Access.Repository
{
    public class OrderDetailRepository
    {
        public OrderDetail GetOrderDetail(int orderId, int retailChainId = -1)
        {
            OrderDetail orderDetail = new OrderDetail();
            using (var cntx = new SRL.Data_Access.Entity.BACKUP_SRL_20180613Entities())
            {
                orderDetail = ((GetOrderDetail_Result)cntx.GetOrderDetail(orderId, retailChainId).FirstOrDefault()).ConvertOrderDetailResult();
            };
            return orderDetail;
        }

        public SSCCsForOrder GetSSCCListForOrder(long orderId, string userEmail)
        {
            SSCCsForOrder result = new SSCCsForOrder();
            List<string> containerNames = new List<string>();
            
            using (var cntx = new SRL.Data_Access.Entity.BACKUP_SRL_20180613Entities())
            {
                result.SSCCs = cntx.API_LIST_SSCC_ON_ORDER(orderId).ToList().ConvertSSCCListForOrder();
            }

            //Show only validated SSCCs for customer
            UserRepository userRepository = new UserRepository();
            if(userRepository.IsExternalUser(userEmail))
            {
                List<SSCCDetailForOrder> ssccList = result.SSCCs.Where(s => string.Compare(s.SSCCStatus, Resources.SSCCStatus.VALIDATED, true) == 0).ToList();
                result.SSCCs = ssccList;
            }

            //To get the list of possible container names
            result.SSCCs.ForEach(s => s.RTIQuantities.ForEach(q =>
            {
                if (!containerNames.Contains(q.ContainerName))
                    containerNames.Add(q.ContainerName);
            }));
            result.ContainerNames = containerNames;
            return result;
        }

        public SSCCsForOrder GetOpenSSCCListForOrder(long orderId)
        {
            SSCCsForOrder result = new SSCCsForOrder();
            List<string> containerNames = new List<string>();
            using (var cntx = new SRL.Data_Access.Entity.BACKUP_SRL_20180613Entities())
            {
                //Filter SSCC list based on sscc status, where 3 stands for validated SSCC
                result.SSCCs = cntx.API_LIST_SSCC_ON_ORDER(orderId).Where(s => s.SSCC_STATUS != 3).ToList().ConvertSSCCListForOrder();
            }
            //To get the list of possible container names
            result.SSCCs.ForEach(s => s.RTIQuantities.ForEach(q =>
            {
                if (!containerNames.Contains(q.ContainerName))
                    containerNames.Add(q.ContainerName);
            }));
            result.ContainerNames = containerNames;
            return result;
        }
    }
}
