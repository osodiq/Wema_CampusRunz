using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
    }
}
