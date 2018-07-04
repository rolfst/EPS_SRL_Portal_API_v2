using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Http.Results;
using SRL_Portal_API.Model.FilterOrder;

namespace SRL_Portal_API.Controllers
{
    public class FilterOrderController : ApiController
    {
        // GET api/filterorder
        /// <summary>
        /// Get a list of Orders based on the specified filters.
        /// </summary>
        /// <param name="actorId">The actor which the orders are from. Value can be <c>null</c></param>
        /// <param name="orderDateFrom">Date after which the filter searches orders. Value can be <c>null</c></param>
        /// <param name="orderDateTo">Date before which the filter searches orders. Value can be <c>null</c></param>
        /// <param name="orderStatus">The status of the order. Value can be <c>null</c></param>
        /// <param name="ciDateTo">Value can be <c>null</c></param>
        /// <param name="ciDateFrom">Value can be <c>null</c></param>
        /// <param name="validationDeadlineStatus">Value which tells the filter what type of status the deadline has. Value can be <c>null</c></param>
        /// <param name="user">Represents the user looking up the information. Value can be <c>null</c></param>
        /// <param name="from">Company from which the order is coming. Value can be <c>null</c></param>
        /// <param name="to">Company to which the order is going. Value can be <c>null</c></param>
        /// <param name="orderNumber">identifiable number for the order. Value can be <c>null</c></param>
        /// <param name="shopOkStatus">Value which determines the Shop status. Value can be <c>null</c></param>
        /// <param name="slaOkStatus">Value which determines the slaOkStatus. Value can be <c>null</c></param>
        /// <returns>A collection of orders.</returns>
        public JsonResult<List<FilterOrderResponseModel>> Get(int actorId, DateTime orderDateFrom, DateTime orderDateTo, int orderStatus, DateTime ciDateTo, DateTime ciDateFrom, string validationDeadlineStatus, string user, string from, string to, int orderNumber, string shopOkStatus, string slaOkStatus)
        {
            var response = new List<FilterOrderResponseModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SRL_Portal"].ConnectionString))
            {
                using (var cmd = new SqlCommand("", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Actor_ID", actorId));
                    cmd.Parameters.Add(new SqlParameter("@OrderDateFrom", actorId));
                    cmd.Parameters.Add(new SqlParameter("@OrderDateTo", actorId));
                    cmd.Parameters.Add(new SqlParameter("@OrderStatus", actorId));
                    cmd.Parameters.Add(new SqlParameter("@CIDateFrom", actorId));
                    cmd.Parameters.Add(new SqlParameter("@CIDateTo", actorId));
                    cmd.Parameters.Add(new SqlParameter("@ValidationDeadline", actorId));
                    cmd.Parameters.Add(new SqlParameter("@User", actorId));
                    cmd.Parameters.Add(new SqlParameter("@From", actorId));
                    cmd.Parameters.Add(new SqlParameter("@To", actorId));
                    cmd.Parameters.Add(new SqlParameter("@OrderNumber", actorId));
                    cmd.Parameters.Add(new SqlParameter("@CountingStatusSLA", actorId));
                    cmd.Parameters.Add(new SqlParameter("@CountingStatusSHOP", actorId));

                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var result = new FilterOrderResponseModel
                        {
                            OrderId = reader.GetInt32(0),
                            OrderDate = reader.GetDateTime(1),
                            OrderNumber = reader.GetInt32(2),
                            From = reader.GetString(3),
                            To = reader.GetString(4),
                            OrderStatus = reader.GetString(5),
                            ValidationDeadline = reader.GetString(6),
                            SlaOk = reader.GetString(7),
                            CountingOk = reader.GetString(8),
                            CiDate = reader.GetDateTime(9)
                        };
                        response.Add(result);
                    }
                }
            }
            return Json(response);
        }
    }
}
