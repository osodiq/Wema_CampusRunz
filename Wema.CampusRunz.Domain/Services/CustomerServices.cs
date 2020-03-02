using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wema.CampusRunz.Core.DTOs;
using Wema.CampusRunz.Core.Interfaces;
using Wema.CampusRunz.Core.Models;
using Wema.CampusRunz.Data.Data;
using static Wema.CampusRunz.Core.DTOs.OrderDTO;
using Wema.CampusRunz.Core.Extensions;

namespace Wema.CampusRunz.Domain.Services
{
    public class CustomerServices : ICustomerService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CustomerServices> _logger;

        public CustomerServices(ApplicationDbContext context, ILogger<CustomerServices> logger)
        {
            _context = context;
            _logger = logger;
            
        }

        #region Event Ticket

        public async Task<EventTicketOrder> CreateEventTicketOrder(int productId, string userId, Category OrderCategory)
        {
            try
            {
                var ticketToBeBooked = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
                if (ticketToBeBooked == null)
                {
                    return null;

                }
                if (OrderCategory.OrderCategoryVms.Count == 0)
                {
                    return null;
                }
                EventTicketOrder ticketOrder = new EventTicketOrder();
                ticketOrder.ProductId = ticketToBeBooked.Id;
                ticketOrder.UserId = userId;
                

                ticketOrder.OrderCategories  = new List<OrderCategory>();

                foreach (var item in OrderCategory.OrderCategoryVms)
                {
                    ticketOrder.OrderCategories.Add(new OrderCategory { Quantity = item.Quantity, Price = item.Price, Category = item.Category });
                    ticketOrder.TotalAmount = (item.Quantity) * item.Price + ticketToBeBooked.ConvinienceFee;

                }
                _context.EventTicketOrders.Add(ticketOrder);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return ticketOrder;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());
                return null;
            }

        }

        public Task<object> GetEventTicketOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<object>> GetEventTicketOrders()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Gass Refill

        public async Task<GassRefillOrder> CreateGassRefillOrder(int productId, string userId, string deliveryAddress)
        {
            try
            {
                Product gassRefillToBeOrdered = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
                if (gassRefillToBeOrdered != null)
                {
                    GassRefillOrder gassRefillOrder = new GassRefillOrder
                    {
                        DeliveryAddress = deliveryAddress,
                        TotalAmount = gassRefillToBeOrdered.Amount + gassRefillToBeOrdered.ConvinienceFee,
                        ProductId = productId,
                        UserId = userId,
                    };
                    _context.GassRefillOrders.Add(gassRefillOrder);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return gassRefillOrder;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }


        public Task<object> GetGassRefillOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<object>> GetGassRefillOrders()
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Hotel

        public async Task<HotelOrder> CreateHotelOrder(int productId, string userId, Category OrderCategory)
        {
            try
            {
                var hotelToBeBooked = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
                if (hotelToBeBooked == null)
                {
                    return null;

                }
                if (OrderCategory.OrderCategoryVms.Count == 0)
                {
                    return null;
                }
                HotelOrder hotelOrder = new HotelOrder();
                hotelOrder.ProductId = hotelToBeBooked.Id;
                hotelOrder.UserId = userId;

               hotelOrder.OrderCategories = new List<OrderCategory>();
                
                foreach (var item in OrderCategory.OrderCategoryVms)
                {
                    hotelOrder.OrderCategories.Add(new OrderCategory { Quantity = item.Quantity, Price = item.Price, Category = item.Category});
                    hotelOrder.TotalAmount = (item.Quantity)* item.Price + hotelToBeBooked.ConvinienceFee;
                  
                }
                _context.HotelOrders.Add(hotelOrder);
                await _context.SaveChangesAsync();
                if (await _context.SaveChangesAsync() > 0)
                {
                    return hotelOrder;
                }
                return null;

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.InnerException.ToString());
                return null;
            }
        }

        public Task<object> GetHotelOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<object>> GetHotelOrders()
        {
            throw new NotImplementedException();
        } 
        #endregion


        #region Fast Food

        public async Task<FastFoodOrder> OrderFastFood(int productId, string userId, FastFood fastFoodDto)
        {
            try
            {
                var foodToBeOrdered = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
                if (foodToBeOrdered == null)
                {
                    return null;
                }
                if (fastFoodDto.Quantity <= 0)
                {
                    return null;
                }
                FastFoodOrder fastFoodOrder = new FastFoodOrder
                {
                    DeliveryAddress = fastFoodDto.DeliveryAddress,
                    ProductId = productId,
                    UserId = userId,
                    Quantity = fastFoodDto.Quantity,
                    TotalAmount = (foodToBeOrdered.Amount * fastFoodDto.Quantity) + foodToBeOrdered.ConvinienceFee

                };
                _context.FastFoodOrders.Add(fastFoodOrder);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return fastFoodOrder;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());
                return null;
            }
        }
        public Task<object> GetFastFoodOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<object>> GetFastFoodOrders()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Media

        public async Task<MediaAndProductionOrder> CreateMediaOrder(int productId, string userId, MediaOrderDto mediaOrderDto)
        {
            try
            {
                Product productToBeOrdered = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
                if (productToBeOrdered != null)
                {
                    MediaAndProductionOrder mediaAndProductionOrder = mediaOrderDto.ToMediaAndProductionOrder();
                    _context.MediaAndProductionOrders.Add(mediaAndProductionOrder);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return mediaAndProductionOrder;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());
                return null;
            }
        }

        public Task<object> GetMediaOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<object>> GetMediaOrders()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
