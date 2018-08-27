using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Ajax.Utilities;
using SRL.Data_Access.Adapter;
using SRL.Data_Access.Repository;
using SRL.Models.Constants;
using SRL.Models.Order;
using SRL_Portal_API.Common;

namespace SRL_Portal_API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Controller which handles GET requests for filtering orders.
    /// </summary>
    public class OrdersController : BaseController
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
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"orders\\filter"));
            request = _repo.EditRequest(request);
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
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"order\\get?retailerchainid={retailerChainId}"));

            var request = new OrderRequest(retailerChainId: retailerChainId);
            dynamic response = _repo.GetOrderNumbers(request, RequestContext.Principal.Identity.Name).DistinctBy(x => x.ID_ORDER).Select(x => new { x.ID_ORDER, x.ORD_ORDER_NUMBER });
            return response;
        }

        [HttpGet]
        [Route("GetApprovedOrders")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public int GetApprovedOrdersCount(int retailerChainId = -1)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"sscc\\GetApprovedOrders?retailerchainId={retailerChainId}"));
            return _repo.GetApprovedOrdersCount(RequestContext.Principal.Identity.Name, retailerChainId);
        }


    }
}
