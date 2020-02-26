using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.Models
{
    public class ProductPhoto : BaseEntity
    {
        public string ProductId { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
