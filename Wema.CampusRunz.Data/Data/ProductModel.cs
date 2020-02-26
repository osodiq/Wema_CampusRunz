using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Data.Data
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Vendor { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Delivery { get; set; }
        public double DeliveryCost { get; set; }
        public double ConvienceFee { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Address { get; set; }
        public bool Visibility { get; set; } = true;
    }
}
