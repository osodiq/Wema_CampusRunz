using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class OrderAggregate: BaseEntity
    {
        public string Category  { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
    }
}
