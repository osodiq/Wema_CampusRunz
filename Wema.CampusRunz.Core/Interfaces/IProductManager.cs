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
        Task<GetProductDTO> GetProductById(int productId, string category);


        Task<ProductCreationDto.GasRefillDto> CreateGasRefill(ProductCreationDto.GasRefillDto model, string userId);
        Task<ProductCreationDto.EventTicketDto> CreateEventTicket(ProductCreationDto.EventTicketDto model, string userId);
        Task<ProductCreationDto.HotelDto> CreateHotel(ProductCreationDto.HotelDto model, string userId);

        Task<ProductCreationDto.FastFoodDto> CreatFastFood(ProductCreationDto.FastFoodDto model, string userId);
        Task<List<GetFastFoodDto>> GetGasRefill();
        Task<GetFastFoodByIdDto> GetFastFoodById(int productId);

        //Task<ProductDto> CreateMedia(ProductDto model);

    }

}
