using System.Web.Http;
using SRL.Models.Order;
using SRL.Data_Access.Repository;
using System.Web.Http.Cors;
using SRL.Models.Constants;
using SRL_Portal_API.Common;
using System.Collections.Generic;

namespace SRL_Portal_API.Controllers
{
    /// <summary>
    /// To handle order detail actions
    /// </summary>
    [EnableCors(origins: "http://localhost:9005", headers: "*", methods: "*")]
    public class OrderDetailController : BaseController
    {
        [CustomAuthorizationFilter(UserRoles.SuperUser)]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public OrderDetail Get(int orderId)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"orderdetail\\get?orderId={orderId}"));
            OrderDetailRepository repository = new OrderDetailRepository();
            return repository.GetOrderDetail(orderId);
        }

        [CustomAuthorizationFilter(UserRoles.Customer)]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public OrderDetail Get(int orderId, int retailerChainId)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"orderdetail\\get?orderId={orderId}&retailerChainId={retailerChainId}"));
            OrderDetailRepository repository = new OrderDetailRepository();

            return repository.GetOrderDetail(orderId, retailerChainId);
        }

        [HttpGet]
        [Route("SSCCListForOrder")]
        public List<SSCCDetailForOrder> GetSSCCListForOrder(int orderId)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"orderdetail\\SSCCListForOrder?orderId={orderId}"));
            OrderDetailRepository repository = new OrderDetailRepository();
            return repository.GetSSCCListForOrder(orderId);
        }

        [HttpGet]
        [Route("OpenSSCCListForOrder")]
        public List<SSCCDetailForOrder>GetOpenSSCCListForOrder(int orderId)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"orderdetail\\get?orderId{orderId}"));
            OrderDetailRepository repository = new OrderDetailRepository();
            return repository.GetOpenSSCCListForOrder(orderId);
        }
    }
}