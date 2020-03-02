using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wema.CampusRunz.Core.DTOs;
using Wema.CampusRunz.Core.Models;
using static Wema.CampusRunz.Core.DTOs.OrderDTO;

namespace Wema.CampusRunz.Core.Interfaces
{
    public interface ICustomerService
    {
        #region Fast Food
        Task<FastFoodOrder> OrderFastFood(int productId, string userId, OrderDTO.FastFood fastFoodDto);
        Task<object> GetFastFoodOrderById(int orderId);
        Task<List<object>> GetFastFoodOrders();

        #endregion
        #region Hotel
        Task<HotelOrder> CreateHotelOrder(int productId, string userId, Category OrderCategory);
        Task<object> GetHotelOrderById(int orderId);
        Task<List<object>> GetHotelOrders();

        #endregion
        #region Event Ticket
        Task<EventTicketOrder> CreateEventTicketOrder(int productId, string userId, Category OrderCategory);
        Task<object> GetEventTicketOrderById(int orderId);
        Task<List<object>> GetEventTicketOrders();

        #endregion
        #region Media And Production
        Task<MediaAndProductionOrder> CreateMediaOrder(int productId, string userId, MediaOrderDto mediaOrderDto);
        Task<object> GetMediaOrderById(int orderId);
        Task<List<object>> GetMediaOrders();

        #endregion
        #region Gass Refill
        Task<GassRefillOrder> CreateGassRefillOrder(int productId, string userId, string deliveryAddress);
        Task<object> GetGassRefillOrderById(int orderId);
        Task<List<object>> GetGassRefillOrders();

        #endregion
    }
}
