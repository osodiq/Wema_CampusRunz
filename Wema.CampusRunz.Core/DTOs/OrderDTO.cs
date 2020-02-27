using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.DTOs
{
    public static class OrderDTO
    {
       public class MediaOderDto
       {
            public string DocumentPath { get; set; }
            public string DeliveryAddress { get; set; }
            public string PrintingType { get; set; }
            public string ExtraDetail { get; set; }

       }

        public class AggregateOderDto
        {
            public string Category { get; set; }
            public decimal Amount { get; set; }
            public int Quantity { get; set; }

        }
    }
}
