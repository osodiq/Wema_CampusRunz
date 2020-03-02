using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wema.CampusRunz.Core.DTOs
{
    public static class OrderDTO
    {
       public class MediaOrderDto
       {
            public string DocumentPath { get; set; }
            public string DeliveryAddress { get; set; }
            public string PrintingType { get; set; }
            public string ExtraDetail { get; set; }
            public int NumberOfPages { get; set; }

       }

        public class OrderCategoryVm
        {
            public string Category { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }

        }
        public class FastFood
        {
            [Required]
            public int Quantity { get; set; }
            [Required]
            public string DeliveryAddress { get; set; }
        }

        public class Category
        {
            public List<OrderCategoryVm> OrderCategoryVms { get; set; }
            
        }
    }
}
