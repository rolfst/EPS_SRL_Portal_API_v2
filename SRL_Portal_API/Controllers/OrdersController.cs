using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SRL.Data_Access.Entity;
using SRL.Models.Order;
using BACKUP_SRL_20180613Entities = SRL.Data_Access.Entity.BACKUP_SRL_20180613Entities;

namespace SRL_Portal_API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Controller which handles GET requests for filtering orders.
    /// </summary>
    public class OrdersController : ApiController
    {
        private readonly BACKUP_SRL_20180613Entities _dbEntities = new BACKUP_SRL_20180613Entities();

        /// <summary>
        /// Get a list of Orders based on the specified request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A collection of orders which corresponds to the request.</returns>
        [HttpPost]
        public IList<OrderResponse> FilterOrder(
            [FromBody] OrderRequest request)
        {

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

            _dbEntities.Configuration.ProxyCreationEnabled = false;
            List<ORDER_LIST_Result> orderList = _dbEntities.API_ORDER_LIST(request.OrdOrderNumber, request.RetailerChainId, request.OrderDateFrom, 
                    request.OrderDateTo, request.OrderNew, request.OrderOpen, request.OrderValidated, request.CiDateFrom, request.CiDateTo, 
                    request.ValidationDeadline, request.User, request.ActorIdFrom, request.ActorIdTo, request.OrderNumber,
                request.ShopCountOk, request.ShopCountNok, request.ValidationOpen, request.ValidationExceeded, request.ValidationPassed).Take(1000)
                .ToList();
            return ConvertOrderList(orderList);
        }


        /// <summary>
        /// Convert the raw data from the database into the form as expected by the front-end
        /// </summary>
        /// <param name="input">The raw data as retrieved list of <see cref="ORDER_LIST_Result"/></param>
        /// <returns>A list of <see cref="OrderResponse"/> based on the input</returns>
        private List<OrderResponse> ConvertOrderList(IEnumerable<ORDER_LIST_Result> input)
        {
            var now = DateTime.Now;
            var VMList = new List<OrderResponse>();
            foreach (var item in input)
            {
                var vm = new OrderResponse
                {
                    OrderId = item.ID_ORDER,
                    OrderDate = item.ORDER_DATE,
                    OrderNumber = item.ORD_ORDER_NUMBER,
                    ActorFrom = item.FROM_NAME,
                    ActorTo = item.TO_NAME
                };
                switch (item.ORDER_STATUS)
                {
                    case 1:
                        vm.OrderStatus = "New";
                        break;
                    case 2:
                        vm.OrderStatus = "Processed";
                        break;
                    case 3:
                        vm.OrderStatus = "Validated";
                        break;
                    default:
                        vm.OrderStatus = "New";
                        break;
                }
                if (item.VALIDATION_DEADLINE.HasValue)
                {
                    vm.ValidationDeadline = Math.Round((item.VALIDATION_DEADLINE.Value - now).TotalHours, 0);
                }
                vm.CountingOK = item.SHOP_OK == 1;
                vm.CIDate = item.CI_DATE;
                vm.IsValidated = item.VALIDATED == 1;
                vm.ValidationStatus = SetValidationStatus(item.VALIDATED == 1, item.VALIDATION_DEADLINE);
                VMList.Add(vm);
            }

            return VMList;
        }

        private string SetValidationStatus(bool IsValidated, DateTime? valDeadline)
        {
            if (IsValidated)
                return "Passed";

            if (valDeadline.HasValue && valDeadline < DateTime.Now)
                return "Exceeded";

            return "Open";
        }
    }
}
