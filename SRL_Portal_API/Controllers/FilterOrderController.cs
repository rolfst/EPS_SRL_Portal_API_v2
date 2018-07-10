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
        /// <param name="validationDeadlinePassed"></param>
        /// <param name="user">Represents the user looking up the information. Value is optional.</param>
        /// <param name="from">Company from which the order is coming. Value is optional.</param>
        /// <param name="to">Company to which the order is going. Value is optional.</param>
        /// <param name="orderNumber">identifiable number for the order. Value is optional.</param>
        /// <param name="shopNok"></param>
        /// <param name="slaOkStatus">Value which determines the slaOkStatus. Value is optional.</param>
        /// <param name="validationDeadline"></param>
        /// <param name="validationDeadlineOpen"></param>
        /// <param name="validationDeadlineExceeded"></param>
        /// <param name="shopOk"></param>
        /// <returns>A collection of orders.</returns>
        [HttpPost]
        public JsonResult<List<FilterOrderResponseModel>> FilterOrder(
        int? actorId = null, DateTime? orderDateFrom = null,
        DateTime? orderDateTo = null, int? orderStatus = null,
        DateTime? ciDateTo = null, DateTime? ciDateFrom = null,
        DateTime? validationDeadline = null, string validationDeadlineOpen = null, 
        string validationDeadlineExceeded = null, string validationDeadlinePassed = null, 
        string user = null, string from = null, 
        string to = null, string orderNumber = null,
        bool shopOk = false, bool shopNok = false, string slaOkStatus = null)
        {
            var response = new List<FilterOrderResponseModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SRL_Portal"].ConnectionString))
            {
                // todo: add Stored Procedure
                using (var cmd = new SqlCommand("dbo.API_ORDER_LIST", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ORD_ORDER_NUMBER", orderNumber));
                    cmd.Parameters.Add(new SqlParameter("@RETAILER_CHAIN_ID", actorId));
                    cmd.Parameters.Add(new SqlParameter("@ORDER_DATE_FROM", orderDateFrom));
                    cmd.Parameters.Add(new SqlParameter("@ORDER_DATE_TO", orderDateTo));
                    cmd.Parameters.Add(new SqlParameter("@ORDER_STATUS", orderStatus));
                    cmd.Parameters.Add(new SqlParameter("@CI_DATE_FROM", ciDateFrom));
                    cmd.Parameters.Add(new SqlParameter("@CI_DATE_TO", ciDateTo));
                    cmd.Parameters.Add(new SqlParameter("@VALIDATION_DEADLINE", validationDeadline));
                    cmd.Parameters.Add(new SqlParameter("@USER", user));
                    cmd.Parameters.Add(new SqlParameter("@ACTOR_ID_FROM", from));
                    cmd.Parameters.Add(new SqlParameter("@ACTOR_ID_TO", to));
                    cmd.Parameters.Add(new SqlParameter("@SHOP_COUNT_OK", shopOk));
                    cmd.Parameters.Add(new SqlParameter("@SHOP_COUNT_NOK", shopNok));
                    cmd.Parameters.Add(new SqlParameter("@VALIDATION_DEADLINE_OPEN", validationDeadlineOpen));
                    cmd.Parameters.Add(new SqlParameter("@VALIDATION_DEADLINE_EXCEEDED", validationDeadlineExceeded));
                    cmd.Parameters.Add(new SqlParameter("@VALIDATION_DEADLINE_PASSED", validationDeadlinePassed));

                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var result = new FilterOrderResponseModel
                        {
                            // todo: Convert datetimes to example: "\/Date(1527808202000)\/"
                            OrderId = reader["ID_ORDER"],
                            OrderDate = reader["ORDER_DATE"],
                            OrderNumber = reader["ORD_ORDER_NUMBER"],
                            From = reader["FROM_NAME"],
                            To = reader["TO_NAME"],
                            OrderStatus = reader["ORDER_STATUS"],
                            ValidationDeadline = reader["VALIDATION_DEADLINE"],
                            SlaOk = reader["SHOP_OK"],
                            CountingOk = reader["SHOP_OK"],
                            CiDate = reader["CI_DATE"],
                        };
                        response.Add(result);
                    }
                }
            }
            return Json(response);
        }
    }
}
