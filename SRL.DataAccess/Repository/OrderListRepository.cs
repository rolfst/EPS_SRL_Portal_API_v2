using System.Collections.Generic;
using System.Linq;
using SRL.Data_Access.Entity;
using SRL.Models.Order;

namespace SRL.Data_Access.Repository
{
    public class OrderListRepository
    {
        public IEnumerable<ORDER_LIST_Result> GetOrders(OrderRequest request)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                List<ORDER_LIST_Result> result = dbEntity.API_ORDER_LIST(request.OrdOrderNumber, request.RetailerChainId, request.OrderDateFrom,
                        request.OrderDateTo, request.OrderNew, request.OrderOpen, request.OrderValidated, request.CiDateFrom, request.CiDateTo,
                        request.ValidationDeadline, request.User, request.ActorIdFrom, request.ActorIdTo, request.OrderNumber,
                        request.ShopCountOk, request.ShopCountNok, request.ValidationOpen, request.ValidationExceeded, request.ValidationPassed, request.ActorId).Take(1000)
                    .ToList();
                return result;
            };
        }
    }
}
