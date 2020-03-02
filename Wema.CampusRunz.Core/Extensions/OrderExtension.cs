using System;
using System.Collections.Generic;
using System.Text;
using Wema.CampusRunz.Core.DTOs;
using Wema.CampusRunz.Core.Models;
using static Wema.CampusRunz.Core.DTOs.OrderDTO;

namespace Wema.CampusRunz.Core.Extensions
{
    public static class OrderExtension
    {
        public static MediaAndProductionOrder ToMediaAndProductionOrder(this MediaOrderDto mediaOrderDto)
        {
            return new MediaAndProductionOrder
            {
                PrintingType = mediaOrderDto.PrintingType,
                DeliveryAddress = mediaOrderDto.DeliveryAddress,
                DocumentPath = mediaOrderDto.DocumentPath,
                ExtraDetail = mediaOrderDto.ExtraDetail,
                NumberOfPages = mediaOrderDto.NumberOfPages,
               
            };
        }
        public static List<OrderCategory> ToOrderCtaegroryList(this List<OrderCategoryVm> model)
        {
            return model.ConvertAll(x => new OrderCategory
            {
                Category = x.Category,
                Quantity = x.Quantity,
                Price = x.Price
            });
        }
    }
}
