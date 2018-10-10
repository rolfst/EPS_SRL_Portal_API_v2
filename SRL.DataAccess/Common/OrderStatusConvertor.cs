using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SRL.Data_Access.Resources;
using SRL.Models.Enums;

namespace SRL.Data_Access.Common
{
    public static class OrderStatusConvertor
    {
        public static string GetOrderStatusDescription(this OrderStatus orderStatus )
        {
            return OrderStatuses.ResourceManager.GetString(orderStatus.ToString());
        }
    }
}