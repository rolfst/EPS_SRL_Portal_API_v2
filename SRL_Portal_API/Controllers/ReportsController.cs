using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Http;
using SRL.Data_Access.Repository;
using SRL.Models;
using SRL.Models.Order;

namespace SRL_Portal_API.Controllers
{
    public class ReportsController : BaseController
    {
        [HttpPost]
        [Route("Send")]
        public void SendReportsToActors(IdList ids)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"Reports\\send"));
            var sb = new StringBuilder();
            for (var i = 0; i < ids.Ids.Count; i++)
            {
                sb.Append(ids.Ids[i]);
                if (i + 1 < ids.Ids.Count)
                {
                    sb.Append(",");
                }
            }
            var reportRequest = new SendReportRequestList
            {
                Requests = new List<SendReportRequest>()
            };

            var repo = new OrderListRepository();
            var result = repo.GetOrders(new OrderRequest {OrderNumber = sb.ToString()});
            foreach (var order in result)
            {
                var actorId = Convert.ToInt32(order.FROM_ACTOR_ID);
                var retailChain = order.RETAILER_CHAIN_ID;
                var orderNumber = Convert.ToInt32(order.ID_ORDER);

                reportRequest.Requests.Add(new SendReportRequest{ActorId = actorId, OrderNumber = orderNumber, RetailerChainId = retailChain});
            }

            SendReportsToActors(reportRequest);
        }

        private void SendReportsToActors(SendReportRequestList sendReportRequest)
        {
            var repo = new UserRespository();
            // Send report to every request
            foreach (var request in sendReportRequest.Requests)
            {
                var users = repo.GetUsersFromActor(request.ActorId, request.RetailerChainId);

                // Validate mailAddresses
                foreach (var user in users)
                {
                    var mailAddress = new MailAddress(user.Email, $"{user.FirstName} {user.LastName}");

                    SendReportToActor(mailAddress, request.OrderNumber);
                }
                
            }
        }

        private static void SendReportToActor(MailAddress mailAddress, int requestOrderNumber)
        {
            // Retrieve order
            var controller = new OrderDetailController();
            var repository = new OrderDetailRepository();
            var orderDetail = repository.GetOrderDetail(requestOrderNumber);

            var mail = new MailMessage(ConfigurationManager.AppSettings["smtpFrom"], mailAddress.Address)
            {
                Subject = $"Report for order {orderDetail.OrderNumber}",
                Body = $"Dear {mailAddress.DisplayName}, \n Your report for order {orderDetail.OrderNumber} is finished. \n\n{orderDetail}"
            };

            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = ConfigurationManager.AppSettings["smtpHost"],
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings["smtpUsername"], ConfigurationManager.AppSettings["smtpPassword"]),
                EnableSsl = true
            };
            client.Send(mail);
        }
    }
}