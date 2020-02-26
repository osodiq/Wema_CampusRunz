using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Data.Data
{
    public class SalesHistoryModel
    {
        public int Id { get; set; }
        public List<string> Categories { get; set; }
        public int NoOfMerchants { get; set; }
        public double UnitCost { get; set; }
        public int Order { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
