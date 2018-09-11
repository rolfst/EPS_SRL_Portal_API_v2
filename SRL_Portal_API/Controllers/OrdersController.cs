using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using SRL.Data_Access.Adapter;
using SRL.Data_Access.Repository;
using SRL.Models.Constants;
using SRL.Models.Exceptions;
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
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator, UserRoles.Customer })]
        public IList<OrderResponse> FilterOrder(
            [FromBody] OrderRequest request)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"orders\\filter"));
            request = _repo.EditRequest(request, RequestContext.Principal.Identity.Name);
            return OrderListAdapter.ConvertOrderList(_repo.GetOrders(request));
        }

        /// <summary>
        /// get all orders linked to a customer.
        /// </summary>
        /// <param name="retailerChainId">specific customer related id. Returns all orders if value is -1</param>
        /// <returns>a <see cref="List{T}"/> containing the orderid and ordernumber.</returns>
        [HttpGet]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator, UserRoles.Customer })]
        public object GetOrderNumber(int retailerChainId = -1)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"order\\get?retailerchainid={retailerChainId}"));

            var request = new OrderRequest(retailerChainId: retailerChainId);
            dynamic response = _repo.GetOrderNumbers(request, RequestContext.Principal.Identity.Name).DistinctBy(x => x.ID_ORDER).Select(x => new { x.ID_ORDER, x.ORD_ORDER_NUMBER });
            return response;
        }

        [HttpGet]
        [Route("GetApprovedOrders")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator, UserRoles.Customer })]
        public int GetApprovedOrdersCount(int retailerChainId = -1)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"Order\\GetApprovedOrders?retailerchainId={retailerChainId}"));
            return _repo.GetApprovedOrdersCount(RequestContext.Principal.Identity.Name, retailerChainId);
        }

        [HttpPost]
        [Route("ApproveOrders")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent })]
        public NonValidatedOrderResponse ValidateMultipleOrders(List<int> orderIdList)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"Order\\ApproveOrders?orderIdList={string.Join(",", orderIdList) }"));
            NonValidatedOrderResponse response = new NonValidatedOrderResponse();
            response = _repo.ValidateMultipleOrders(orderIdList, RequestContext.Principal.Identity.Name);
            if (response.NonValidatedOrderList != null && response.NonValidatedOrderList.Any())
            {
                throw HttpMessageExceptionBuilder.Build(HttpStatusCode.Accepted, HttpMessageType.Warn, JsonConvert.SerializeObject(string.Join(",", response.NonValidatedOrderList.Select(item => item.OrderNumber))), "Validate Order(s)", "Following order(s) could not be validated-");
            }
            return response;
        }

    }
}
