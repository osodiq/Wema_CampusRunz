using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class Product : BaseEntity
    {
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
        public string EventDate { get; set; } = DateTime.Now.ToShortDateString();
        public string EventTime { get; set; } = DateTime.Now.ToLongDateString();
        public virtual ICollection<ProductCategory> ProductCatory { get; set; } = new List<ProductCategory>();
        [ForeignKey("AppUser")]
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}
