using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Http;
using SRL.Models;

namespace SRL_Portal_API.Controllers
{
    public class ReportsController : BaseController
    {
        [HttpPost]
        public void SendReportsToActors(SendReportRequestList sendReportRequest)
        {
            // Send report to every request
            foreach (var request in sendReportRequest.Requests)
            {
                // Validate mailAddresses
                var mailAddress = new MailAddress(request.MailAddress);

                SendReportToActor(mailAddress, request.OrderNumber);
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
                Body = orderDetail.ToString()
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