﻿using System.Web.Http;
using SRL.Models.Order;
using SRL.Data_Access.Repository;
using SRL.Models.Constants;
using SRL_Portal_API.Common;
using System.Collections.Generic;

namespace SRL_Portal_API.Controllers
{
    /// <summary>
    /// To handle order detail actions
    /// </summary>
    [RoutePrefix("api")]
    public class OrderDetailController : BaseController
    {
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator, UserRoles.Customer })]
        public OrderDetail Get(int orderId)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"orderdetail\\get?orderId={orderId}"));
            OrderDetailRepository repository = new OrderDetailRepository();
            return repository.GetOrderDetail(orderId);
        }

        [CustomAuthorizationFilter(new string[] { UserRoles.Customer })]
        public OrderDetail Get(int orderId, int retailerChainId)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"orderdetail\\get?orderId={orderId}&retailerChainId={retailerChainId}"));
            OrderDetailRepository repository = new OrderDetailRepository();

            return repository.GetOrderDetail(orderId, retailerChainId);
        }

        [HttpGet]
        [Route("SSCCListForOrder")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator, UserRoles.Customer })]
        public SSCCsForOrder GetSSCCListForOrder(int orderId)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"orderdetail\\SSCCListForOrder?orderId={orderId}"));
            OrderDetailRepository repository = new OrderDetailRepository();
            return repository.GetSSCCListForOrder(orderId, RequestContext.Principal.Identity.Name);
        }

        [HttpGet]
        [Route("OpenSSCCListForOrder")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator})]
        public SSCCsForOrder GetOpenSSCCListForOrder(int orderId)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"orderdetail\\OpenSSCCListForOrder?orderId={orderId}"));
            OrderDetailRepository repository = new OrderDetailRepository();
            return repository.GetOpenSSCCListForOrder(orderId);
        }

        [HttpGet]
        [Route("LoadUnitConditionsForOrder")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator, UserRoles.Customer })]
        public LUCsForOrder GetLUCsForOrder(int orderId)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"orderdetail\\LoadUnitConditionsForOrder?orderId={orderId}"));
            OrderDetailRepository repository = new OrderDetailRepository();
            return repository.GetSSCCLUCsForOrder(orderId);
        }
    }
}