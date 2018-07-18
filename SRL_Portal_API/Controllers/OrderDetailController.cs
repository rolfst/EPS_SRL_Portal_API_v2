using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SRL.Entities;
using SRL.Data_Access.Repository;
using SRL.Models.Order;

namespace SRL.WebAPI.Controllers
{
    public class OrderDetailController : ApiController
    {
        public OrderDetail Get(int orderId)
        {
            OrderDetailRepository repository = new OrderDetailRepository();
           return repository.GetOrderDetail(orderId);
        }

        public OrderDetail Get(int orderId, int retailerChainId)
        {
            OrderDetailRepository repository = new OrderDetailRepository();
            return repository.GetOrderDetail(orderId, retailerChainId);
        }
    }
}
