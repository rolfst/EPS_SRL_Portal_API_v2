using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SRL.Models;
using SRL.Data_Access.Repository;
using SRL.Models.Order;

namespace SRL.WebAPI.Controllers
{
    /// <summary>
    /// Controller handling order related actions
    /// </summary>
    public class OrderDetailController : ApiController
    {
        /// <summary>
        /// Fetch order details based on order id for internal user
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>Returns order details</returns>
        [HttpGet]
        public OrderDetail Get(int orderId)
        {
            OrderDetailRepository repository = new OrderDetailRepository();
           return repository.GetOrderDetail(orderId);
        }

        /// <summary>
        /// Fetch order details based on order id and retailer chain id for external user
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="retailerChainId"></param>
        /// <returns></returns>
        [HttpGet]
        public OrderDetail Get(int orderId, int retailerChainId)
        {
            OrderDetailRepository repository = new OrderDetailRepository();
            return repository.GetOrderDetail(orderId, retailerChainId);
        }
    }
}
