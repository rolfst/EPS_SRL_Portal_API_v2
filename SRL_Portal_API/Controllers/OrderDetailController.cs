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
    public class OrderDetailController : ApiController
    {
        [CustomAuthorizationFilter(UserRoles.SuperUser)]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public OrderDetail Get(int orderId)
        {
            OrderDetailRepository repository = new OrderDetailRepository();
            return repository.GetOrderDetail(orderId);
        }

        [CustomAuthorizationFilter(UserRoles.Customer)]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public OrderDetail Get(int orderId, int retailerChainId)
        {
            OrderDetailRepository repository = new OrderDetailRepository();

            return repository.GetOrderDetail(orderId, retailerChainId);
        }

        [HttpGet]
        [Route("SSCCListForOrder")]
        public List<SSCCDetailForOrder> GetSSCCListForOrder(int orderId)
        {
            OrderDetailRepository repository = new OrderDetailRepository();
            return repository.GetSSCCListForOrder(orderId);
        }
    }
}