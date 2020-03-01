using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class CustomerOrder: BaseEntity
    {
        public string Detail { get; set; }
        public decimal TotalAmount { get; set; }
        public string DeliveryAddress { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Payment Payment { get; set; }
        public OrderCategory Aggregate { get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
