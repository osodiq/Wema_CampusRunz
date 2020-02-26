using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wema.CampusRunz.Core.DTOs;
using Wema.CampusRunz.Core.Models;

namespace Wema.CampusRunz.Core.Interfaces
{
    public interface IProductManager
    {
        bool CreateProduct(Product product);
        Task<GetProductDTO> GetProductById(int productId, string category);
        Task<ProductCreationDto.FastFoodDto> CreatFastFood(ProductCreationDto.FastFoodDto model);
        Task<ProductCreationDto.GassRefillDto> CreateGassRefill(ProductCreationDto.GassRefillDto model);
        Task<ProductCreationDto.EventTicketDto> CreateEventTicket(ProductCreationDto.EventTicketDto model);
        Task<ProductCreationDto.HotelDto> CreateHotel(ProductCreationDto.HotelDto model);
        //Task<ProductDto> CreateMedia(ProductDto model);
        
    }
    
}
