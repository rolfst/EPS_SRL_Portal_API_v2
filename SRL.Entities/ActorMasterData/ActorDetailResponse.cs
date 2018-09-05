using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.ActorMasterData
{
   public class ActorDetailResponse
    {
        public int ActorId { get; set; }
        public decimal ActorCode { get; set; }
        public string ActorName { get; set; }
        public int ActorTypeId { get; set; }
        public string ActorTypeName { get; set; }
        public int RetailerChainId { get; set; }
        public int DefaultLanguageCodeId { get; set; }
        public string Language { get; set; }
        public string ActorIPAddress { get; set; }
        public int EmergencyQuantity { get; set; }
        public int DummyActorReferenceId { get; set; }
        public string DummyActorName { get; set; }
        public string  LabelType { get; set; }
        public decimal NovexxClientCode { get; set; }
        public int NumberOfLabels { get; set; }
        public int CardboardBox { get; set; }
        public int ActorDeliveryId { get; set; }

        public List<Actor_SLA> SLAs { get; set; }

    }
}
