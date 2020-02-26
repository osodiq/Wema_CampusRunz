using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class SalesHistory : BaseEntity
    {
        public List<string> Categories { get; set; }
        public int NoOfMerchants { get; set; }
        public double UnitCost { get; set; }
        public int Order { get; set; }
        public double Amount { get; set; }
    }
}
