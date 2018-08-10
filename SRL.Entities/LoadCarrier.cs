using System;

namespace SRL.Models
{
    public class LoadCarrier
    {
        public DateTime InsertDate { get; set; }
        public string InsertUser { get; set; }
        public DateTime UpdateDate { get; set; }

        public int LoadCarrierCode {get;set;}
        public int LoadCarrierHeight { get; set; }
        public int LoadCarrierLength { get; set; }
        public int LoadCarrierSort { get; set; }
        public Decimal LoadCarrierSurface { get; set; }
        public Decimal LoadCarrierVolume { get; set; }
        public int LoadCarrierWeight { get; set; }
        public int LoadCarrierWidth { get; set; }



        public DateTime UpdateTime { get; set; }
        public DateTime UpdateUser { get; set; }

    }
}
