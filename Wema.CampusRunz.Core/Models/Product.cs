using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class Product 
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Vendor { get; set; }
        public string Description { get; set; }
        public string Delivery { get; set; }
        public decimal DeliveryCost { get; set; }
        public decimal ConvinienceFee { get; set; }
        public string Comment { get; set; }
        public string Address { get; set; }
        public bool Visibility { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string EventDate { get; set; } = DateTime.Now.ToShortDateString();
        public string EventTime { get; set; } = DateTime.Now.ToLongDateString();
        public virtual ProductType ProductType { get; set; }
    }
}
