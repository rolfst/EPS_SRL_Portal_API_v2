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

        public List<SSCCDetailForOrder> GetSSCCListForOrder(long orderId)
        {
            List<SSCCDetailForOrder> ssccList = new List<SSCCDetailForOrder>();
            using (var cntx = new SRL.Data_Access.Entity.BACKUP_SRL_20180613Entities())
            {
                ssccList = cntx.API_LIST_SSCC_ON_ORDER(orderId).ToList().ConvertSSCCListForOrder();
            }
            return ssccList;
        }

        public List<SSCCDetailForOrder> GetOpenSSCCListForOrder(long orderId)
        {
            List<SSCCDetailForOrder> ssccList = new List<SSCCDetailForOrder>();
            using (var cntx = new SRL.Data_Access.Entity.BACKUP_SRL_20180613Entities())
            {
                //Filter SSCC list based on sscc status, where 3 stands for validated SSCC
                ssccList = cntx.API_LIST_SSCC_ON_ORDER(orderId).Where(s => s.SSCC_STATUS != 3).ToList().ConvertSSCCListForOrder();
            }
            return ssccList;
        }
    }
}
