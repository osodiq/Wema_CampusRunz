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
            public List<ProductPhoto> Images { get; set; }
            
        }

        public class GassRefillDto
        {
            public string Category { get; set; }
            public string Name { get; set; }
            public decimal Amount { get; set; }
            public decimal ConvinienceFee { get; set; }
            public List<ProductPhoto> Images { get; set; }
            public string Description { get; set; }

        }

        public class HotelDto
        {
            public string Address { get; set; }
            public string Category { get; set; }
            public string Name { get; set; }
            public decimal ConvinienceFee { get; set; }
            public string Description { get; set; }
            public List<ProductPhoto> Images { get; set; }
            public List<ProductCategory> HotelCategories { get; set; }

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
            public List<ProductPhoto> Images { get; set; }
            public List<ProductCategory> EventCategory { get; set; }

        }


    }
}
