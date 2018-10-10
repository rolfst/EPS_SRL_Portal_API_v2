using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.ActorMasterData
{
    public class AddActorDetailRequest
    {
        public int? ActorId { get; set; }
        public int ActorCode { get; set; }
        public int ActorTypeId { get; set; }
        public int RetailerChainId { get; set; }
        public int DefaultLanguageCodeId { get; set; }
        public string DefaultLanguageCode { get; set; }
        public string ActorIPAddress { get; set; }
        public int EmergencyStockQty { get; set; }
        public int DummyActorReferenceId { get; set; }
        public string LabelType { get; set; }
        public decimal NOVEXXClientCode { get; set; }
        public int NumberOfLabel { get; set; }
        public int ActorDeliveryId { get; set; }
        public int CardboardBox { get; set; }
        public string CurrentUser { get; set; }
        public List<Actor_SLA_Request> SLAs { get; set; }
        public int? CopySLAActorId { get; set; }

    }
}
