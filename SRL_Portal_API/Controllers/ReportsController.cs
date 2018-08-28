using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Http;
using SRL.Data_Access.Repository;
using SRL.Models;

namespace SRL_Portal_API.Controllers
{
    public class ReportsController : BaseController
    {
        [HttpPost]
        public void SendReportsToActors(SendReportRequestList sendReportRequest)
        {
            var repo = new UserRespository();
            // Send report to every request
            foreach (var request in sendReportRequest.Requests)
            {
                if (request.RetailerChainId == 0)
                {

                }
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
            var orderDetail = controller.Get(requestOrderNumber);

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