using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wema.CampusRunz.Core.DTOs
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
       // public DateTime CreatedAt { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public string Vendor { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Delivery { get; set; }
        [Required]
        public double DeliveryCost { get; set; }
        [Required]
        public double ConvienceFee { get; set; }
        [Required]
        public string Comment { get; set; }
        public bool Visibility { get; set; } = true;

        public List<string> UploadedImageList { get; set; }
        
                
    }
}
