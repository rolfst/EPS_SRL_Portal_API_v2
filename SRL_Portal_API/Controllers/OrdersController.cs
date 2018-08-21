using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Ajax.Utilities;
using SRL.Data_Access.Adapter;
using SRL.Data_Access.Repository;
using SRL.Models.Order;

namespace SRL_Portal_API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Controller which handles GET requests for filtering orders.
    /// </summary>
    [EnableCors(origins: "http://localhost:9005", headers: "*", methods: "*")]
    public class OrdersController : ApiController
    {
        private readonly OrderListRepository _repo = new OrderListRepository();

        /// <summary>
        /// Get a list of Orders based on the specified request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A collection of orders which corresponds to the request.</returns>
        [HttpPost]
        public IList<OrderResponse> FilterOrder(
            [FromBody] OrderRequest request)
        {
            request = EditRequest(request);
            return OrderListAdapter.ConvertOrderList(_repo.GetOrders(request));
        }

        /// <summary>
        /// get all orders linked to a customer.
        /// </summary>
        /// <param name="retailerChainId">specific customer related id. Returns all orders if value is -1</param>
        /// <returns>a <see cref="List{T}"/> containing the orderid and ordernumber.</returns>
        [HttpGet]
        public object GetOrderNumber(int retailerChainId = -1)
        {
            var request = new OrderRequest(retailerChainId: retailerChainId);
            dynamic response = _repo.GetOrderNumbers(request, RequestContext.Principal.Identity.Name).DistinctBy(x => x.ID_ORDER).Select(x => new { x.ID_ORDER, x.ORD_ORDER_NUMBER });
            return response;
        }

        private OrderRequest EditRequest(OrderRequest request)
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

            return request;
        }
    }
}
