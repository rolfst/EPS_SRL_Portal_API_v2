using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRL.Models;
using SRL.Data_Access.Entity;
using SRL.Data_Access.Adapter;
using SRL.Models.Order;

namespace SRL.Data_Access.Repository
{
   public class OrderDetailRepository
    {
        public SRL.Models.OrderDetail GetOrderDetail(int orderId, int retailChainId = -1)
        {
            OrderDetail orderDetail = new OrderDetail();
            using (var cntx = new SRL.Data_Access.Entity.BACKUP_SRL_20180613Entities())
            {
                orderDetail = ((GetOrderDetail_Result)cntx.GetOrderDetail(orderId, retailChainId).FirstOrDefault()).ConvertOrderDetailResult();

            };
            return orderDetail;
        }
    }
}
