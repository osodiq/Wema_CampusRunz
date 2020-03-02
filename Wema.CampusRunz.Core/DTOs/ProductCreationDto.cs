using System;
using System.Collections.Generic;
using System.Text;
using Wema.CampusRunz.Core.Models;

namespace Wema.CampusRunz.Core.DTOs
{
    public static class ProductCreationDto
    {
        public class FastFoodDto
        {
            public string Vendor { get; set; }
            public string Address { get; set; }
            public string Category { get; set; }
            public string Name { get; set; }
            public decimal Amount { get; set; }
            public decimal ConvinienceFee { get; set; }
            public string Description { get; set; }
            public List<string> UploadedImageList { get; set; }

        }

        public class GasRefillDto
        {
            public string Category { get; set; }
            public string Name { get; set; }
            public decimal Amount { get; set; }
            public decimal ConvinienceFee { get; set; }
            public List<string> UploadedImageList { get; set; }
            public string Description { get; set; }

        }

        public class HotelDto
        {
            public string Address { get; set; }
            public string Category { get; set; }
            public string Name { get; set; }
            public decimal ConvinienceFee { get; set; }
            public string Description { get; set; }
            public List<ProductCategoryDto> HotelCategories { get; set; }
            public List<string> Images { get; set; }

        }

        public class EventTicketDto
        {
            public string Venue { get; set; }
            public string Category { get; set; }
            public string EventDate { get; set; } 
            public string Name { get; set; }
            public string EventTime { get; set; }
            public decimal ConvinienceFee { get; set; }
            public string Description { get; set; }
            public List<string> UploadedImageList { get; set; }
            public List<ProductCategoryDto> EventCategories { get; set; }
        
        }
        public class ProductCategoryDto
        {
            public string Category { get; set; }
            public decimal Amount { get; set; }
        }

    }

    
}
