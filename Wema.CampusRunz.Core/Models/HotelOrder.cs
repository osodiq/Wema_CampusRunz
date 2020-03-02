using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class HotelOrder: BaseEntity
    {
        public ICollection<OrderCategory> OrderCategories { get; set; } = new List<OrderCategory>();
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public decimal TotalAmount { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
