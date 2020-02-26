﻿using System;
using System.Collections.Generic;
using System.Text;

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
            public List<string> Images { get; set; }
            public string Description { get; set; }

        }

        public class GassRefillDto
        {
            public string Category { get; set; }
            public string Name { get; set; }
            public decimal Amount { get; set; }
            public decimal ConvinienceFee { get; set; }
            public List<string> Images { get; set; }
            public string Description { get; set; }

        }

        public class HotelDto
        {
            public string Address { get; set; }
            public string Category { get; set; }
            public string Name { get; set; }
            public decimal ConvinienceFee { get; set; }
            public List<string> Images { get; set; }
            public string Description { get; set; }
            public HotelCategory HotelCategory { get; set; }

        }

        public class EventTicketDto
        {
            public string Venue { get; set; }
            public string Category { get; set; }
            public string EventDate { get; set; } 
            public string Name { get; set; }
            public string EventTime { get; set; }
            public decimal ConvinienceFee { get; set; }
            public List<string> Images { get; set; }
            public string Description { get; set; }
            public EventCategory EventCategory { get; set; }

        }


        public class HotelCategory
        {
            public string Category { get; set; }
            public decimal Amount { get; set; }
        }
        public class EventCategory
        {
            public string Category { get; set; }
            public decimal Amount { get; set; }
        }

    }
}
