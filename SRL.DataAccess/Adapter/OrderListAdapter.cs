using System;
using System.Collections.Generic;
using SRL.Data_Access.Entity;
using SRL.Models.Order;

namespace SRL.Data_Access.Adapter
{
    public static class OrderListAdapter
    {
        /// <summary>
        /// Convert the raw data from the database into the form as expected by the front-end
        /// </summary>
        /// <param name="input">The raw data as retrieved list of <see cref="ORDER_LIST_Result"/></param>
        /// <returns>A list of <see cref="OrderResponse"/> based on the input</returns>
        public static List<OrderResponse> ConvertOrderList(IEnumerable<ORDER_LIST_Result> input)
        {
            var now = DateTime.Now;
            var results = new List<OrderResponse>();
            foreach (var item in input)
            {
                var vm = new OrderResponse
                {
                    OrderId = item.ID_ORDER,
                    OrderDate = item.ORDER_DATE,
                    OrderNumber = item.ORD_ORDER_NUMBER,
                    ActorFrom = item.FROM_NAME,
                    ActorTo = item.TO_NAME
                };

                switch (item.ORDER_STATUS)
                {
                    case 1:
                        vm.OrderStatus = "New";
                        break;
                    case 2:
                        vm.OrderStatus = "Processed";
                        break;
                    case 3:
                        vm.OrderStatus = "Validated";
                        break;
                    default:
                        vm.OrderStatus = "New";
                        break;
                }

                if (item.VALIDATION_DEADLINE.HasValue)
                {
                    vm.ValidationDeadline = Math.Round((item.VALIDATION_DEADLINE.Value - now).TotalHours, 0);
                }

                vm.CountingOK = item.SHOP_OK == 1;
                vm.CIDate = item.CI_DATE;
                vm.IsValidated = item.VALIDATED == 1;
                vm.ValidationStatus = SetValidationStatus(item.VALIDATED == 1, item.VALIDATION_DEADLINE);
                results.Add(vm);
            }

            return results;
        }

        /// <summary>
        /// Set the validation status based on the response
        /// </summary>
        /// <param name="isValidated">Whether or not the order is validated</param>
        /// <param name="valDeadline">The order deadline</param>
        /// <returns><see cref="string"/> based upon the status of the validation.</returns>
        private static string SetValidationStatus(bool isValidated, DateTime? valDeadline)
        {
            if (isValidated)
            {
                return "Passed";
            }

            return valDeadline.HasValue && valDeadline < DateTime.Now ? "Exceeded" : "Open";
        }
    }
}
