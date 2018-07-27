using System;
using System.Collections.Generic;
using SRL.Data_Access.Entity;
using SRL.Models.Enums;
using SRL.Models.Order;
using SRL.Models;

namespace SRL.Data_Access.Adapter
{
    public static class OrderDetailAdapter
    {
        const string NoReference = "No reference";
        internal static SRL.Models.OrderDetail ConvertOrderDetailResult(this GetOrderDetail_Result orderDetail)
        {
            if(orderDetail == null)
            {
                return new OrderDetail();
            }
            return new SRL.Models.OrderDetail
            {
                OrderNumber = orderDetail.ORD_ORDER_NUMBER,
                FromActorName = orderDetail.FROM_NAME,
                FromActorAddressLine1 = orderDetail.FROM_ADDRESSLINE1,
                FromActorAddressLine2 = orderDetail.FROM_ADDRESSLINE2,
                ToActorName = orderDetail.TO_NAME,
                ToActorAddressLine1 = orderDetail.TO_ADDRESSLINE1,
                ToActorAddressLine2 = orderDetail.TO_ADDRESSLINE2,
                Status = (OrderStatus)orderDetail.ORDER_STATUS,
                OrderDate = orderDetail.ORDER_DATE,
                UnloadingDate = orderDetail.UNLOADING_DATE,
                Transport = string.Empty, //Not known yet
                CIDate = orderDetail.CI_DATE,
                ShipmentNumber = orderDetail.TOUR_NUMBER?? string.Empty,
                Reference = orderDetail.ORD_CUSTOMER_REFERENCE ?? NoReference,
                Transporter = orderDetail.SHIPMENT_COMPANY_NAME ?? string.Empty,
                LicensePlate = orderDetail.LICENSE_PLATE ?? string.Empty,
                TotalSSCCs = orderDetail.OUTBOUND_SSCC_ON_ORDER,
                OpenSSCCs = orderDetail.NUMBER_SSCC_ON_ORDER_OPEN ?? 0,
                ApprovedSSCCs = orderDetail.NUMBER_SSCC_ON_ORDER_VALIDATED ?? 0,
                ToApprovedPercentage = orderDetail.OUTBOUND_SSCC_ON_ORDER.HasValue?(orderDetail.NUMBER_SSCC_ON_ORDER_OPEN ?? 0 / orderDetail.OUTBOUND_SSCC_ON_ORDER.Value) * 100: 0

               
            };
        }
    }
}
