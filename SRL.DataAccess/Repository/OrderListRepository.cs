using System;
using System.Collections.Generic;
using System.Linq;
using SRL.Data_Access.Entity;
using SRL.Models.Order;

namespace SRL.Data_Access.Repository
{
    public class OrderListRepository
    {
        const int VALIDATED_ORDER_STATUS_ID = 14;
        public IEnumerable<ORDER_LIST_Result> GetOrders(OrderRequest request)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                List<ORDER_LIST_Result> result = dbEntity.API_ORDER_LIST( 
                    request.OrdOrderNumber, 
                    request.RetailerChainId, 
                    request.OrderDateFrom,
                    request.OrderDateTo, 
                    request.OrderNew, 
                    request.OrderOpen, 
                    request.OrderValidated,
                    request.OrderId,
                    request.CiDateFrom, 
                    request.CiDateTo,
                    request.ValidationDeadline, 
                    request.User, 
                    request.ActorIdFrom, 
                    request.ActorIdTo, 
                    request.OrderNumber,
                    request.ShopCountOk, 
                    request.ShopCountNok, 
                    request.ValidationOpen, 
                    request.ValidationExceeded, 
                    request.ValidationPassed, 
                    request.ActorId)
                    .Take(1000)
                    .ToList();
                return result;
            };
        }

        public OrderRequest EditRequest(OrderRequest request,string userEmail)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(OrderRequest), "Request is not valid.");
            }

            // Filterfunctionality checkboxgroups: Select none = See all
            if (!request.OrderNew && !request.OrderOpen && !request.OrderValidated)
            {
                request.OrderNew = true; request.OrderOpen = true; request.OrderValidated = true;
            }
            if (!request.ShopCountOk && !request.ShopCountNok)
            {
                request.ShopCountOk = true; request.ShopCountNok = true;
            }
            if (!request.ValidationOpen && !request.ValidationExceeded && !request.ValidationPassed)
            {
                request.ValidationOpen = true; request.ValidationExceeded = true; request.ValidationPassed = true;
            }
            // Filterfunctionality Dates: If date from is not null and date to is null, get only selected date.
            if (request.OrderDateFrom != null && request.OrderDateTo == null)
            {
                request.OrderDateTo = request.OrderDateFrom;
            }
            if (request.CiDateFrom != null && request.CiDateTo == null)
            {
                request.CiDateTo = request.CiDateFrom;
            }

            #region User Management
            if (string.IsNullOrEmpty(request.ActorIdFrom) && string.IsNullOrEmpty(request.ActorId))
            {
                //To fetch order numbers for the assigned actors of the logged in user
                UserRespository userRespository = new UserRespository();
                List<int> actorIds = userRespository.GetActorIdList(userEmail);
                if (actorIds.Any())
                {
                    request.ActorIdFrom = string.Join(",", actorIds.Select(a => a).ToArray());
                }
            }

            #endregion

            return request;
        }

        public int GetApprovedOrdersCount(string userEmail, int retailerChainId =-1)
        {

            var request = new OrderRequest()
            {
                RetailerChainId = retailerChainId,
                OrderValidated = true,
                OrderNew = false,
                OrderOpen = false
            };
            //Return count of validated Orders
            return GetOrderNumbers(request, userEmail).Select(o=>o.ID_ORDER).Distinct().Count();
        }

        public IEnumerable<ORDER_LIST_Result> GetOrderNumbers(OrderRequest request,string userEmail)
        {
            #region User Management
            //To fetch order numbers for the assigned actors of the logged in user
            UserRespository userRespository = new UserRespository();
                List<int> actorIds = userRespository.GetActorIdList(userEmail);
                if(actorIds.Any())
                {
                    request.ActorIdFrom = string.Join(",", actorIds.Select(a => a).ToArray());
                }

            #endregion
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                List<ORDER_LIST_Result> result = dbEntity.API_ORDER_LIST(
                    request.OrdOrderNumber,
                    request.RetailerChainId,
                    request.OrderDateFrom,
                    request.OrderDateTo,
                    request.OrderNew,
                    request.OrderOpen,
                    request.OrderValidated,
                    request.OrderId,
                    request.CiDateFrom,
                    request.CiDateTo,
                    request.ValidationDeadline,
                    request.User,
                    request.ActorIdFrom,
                    request.ActorIdTo,
                    request.OrderNumber,
                    request.ShopCountOk,
                    request.ShopCountNok,
                    request.ValidationOpen,
                    request.ValidationExceeded,
                    request.ValidationPassed,
                    request.ActorId)
                    .ToList();
                return result;
            };
        }

        public NonValidatedOrderResponse ValidateMultipleOrders(List<int> OrderIdList, string userEmail)
        {
            NonValidatedOrderResponse response = new NonValidatedOrderResponse();


            return response;
        }
    }
}
