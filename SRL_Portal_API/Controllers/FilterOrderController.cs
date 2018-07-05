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
    /// <inheritdoc />
    /// <summary>
    /// Controller which handles GET requests for filtering orders.
    /// </summary>
    public class FilterOrderController : ApiController
    {
        /// <summary>
        /// Get all users from the database.
        /// </summary>
        /// <returns>A collection of usernames.</returns>
        [HttpGet]
        public JsonResult<IList<string>> GetUsers()
        {
            IList<string> response = null;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SRL_Portal"].ConnectionString))
            {
                // todo: Add correct Stored Procedure
                using (var cmd = new SqlCommand("dbo.API_LIST_ACTORS_TRANSACTION", conn))
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    response = new List<string>();
                    while (reader.Read())
                    {
                        response.Add(reader.GetString(1));
                    }
                }
            }

            return Json(response);
        }

        /// <summary>
            /// Get a list of Orders based on the specified filters.
            /// </summary>
            /// <param name="actorId">The actor which the orders are from. Value is optional.</param>
            /// <param name="orderDateFrom">Date after which the filter searches orders. Value is optional.</param>
            /// <param name="orderDateTo">Date before which the filter searches orders. Value is optional.</param>
            /// <param name="orderStatus">The status of the order. Value is optional.</param>
            /// <param name="ciDateTo">Value is optional.</param>
            /// <param name="ciDateFrom">Value is optional.</param>
            /// <param name="validationDeadlineStatus">Value which tells the filter what type of status the deadline has.
            ///     Value is optional.</param>
            /// <param name="user">Represents the user looking up the information. Value is optional.</param>
            /// <param name="from">Company from which the order is coming. Value is optional.</param>
            /// <param name="to">Company to which the order is going. Value is optional.</param>
            /// <param name="orderNumber">identifiable number for the order. Value is optional.</param>
            /// <param name="shopOkStatus">Value which determines the Shop status. Value is optional.</param>
            /// <param name="slaOkStatus">Value which determines the slaOkStatus. Value is optional.</param>
            /// <returns>A collection of orders.</returns>
            [HttpPost]
        public JsonResult<List<FilterOrderResponseModel>> FilterOrder(
            int? actorId = null, DateTime? orderDateFrom = null, 
            DateTime? orderDateTo = null, int? orderStatus = null, 
            DateTime? ciDateTo = null, DateTime? ciDateFrom = null, 
            string validationDeadlineStatus = null, string user = null, 
            string from = null, string to = null, int? orderNumber = null, 
            string shopOkStatus = null, string slaOkStatus = null)
        {
            var response = new List<FilterOrderResponseModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SRL_Portal"].ConnectionString))
            {
                // todo: add Stored Procedure
                using (var cmd = new SqlCommand("dbo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Actor_Id", actorId));
                    cmd.Parameters.Add(new SqlParameter("@OrderDateFrom", orderDateFrom));
                    cmd.Parameters.Add(new SqlParameter("@OrderDateTo", orderDateTo));
                    cmd.Parameters.Add(new SqlParameter("@OrderStatus", orderStatus));
                    cmd.Parameters.Add(new SqlParameter("@CIDateFrom", ciDateFrom));
                    cmd.Parameters.Add(new SqlParameter("@CIDateTo", ciDateTo));
                    cmd.Parameters.Add(new SqlParameter("@ValidationDeadline", validationDeadlineStatus));
                    cmd.Parameters.Add(new SqlParameter("@User", user));
                    cmd.Parameters.Add(new SqlParameter("@From", from));
                    cmd.Parameters.Add(new SqlParameter("@To", to));
                    cmd.Parameters.Add(new SqlParameter("@OrderNumber", orderNumber));
                    cmd.Parameters.Add(new SqlParameter("@CountingStatusSLA", slaOkStatus));
                    cmd.Parameters.Add(new SqlParameter("@CountingStatusSHOP", shopOkStatus));

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
