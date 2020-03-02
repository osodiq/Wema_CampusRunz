using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.DTOs
{
    public class GetFastFoodByIdDto
    {
        public int ProductId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool Visibility { get; set; } = true;
        public string Vendor { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string ConvenienceFee { get; set; }
        public List<string> UploadedImageList { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
