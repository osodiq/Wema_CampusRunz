using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.DTOs
{
    public class GetFastFoodDto
    {
        public int ProductId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool Visibility { get; set; } = true;
        public string Vendor { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
