using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class ProductPhoto : BaseEntity
    {
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string ImageString { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
