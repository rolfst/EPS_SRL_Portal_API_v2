using System;
using System.Collections.Generic;
using System.Text;

namespace SRL.Models.SSCC
{
  public  class SSCCPendingChange
    {
        public string ChangeType { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
