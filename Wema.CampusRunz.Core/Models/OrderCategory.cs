using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class OrderCategory: BaseEntity
    {
        public string Category  { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
