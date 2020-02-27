//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using Wema.CampusRunz.Core.DTOs;
//using Wema.CampusRunz.Core.Interfaces;
//using Wema.CampusRunz.Core.Models;
//using Wema.CampusRunz.Data.Data;

//namespace Wema.CampusRunz.Domain.Services
//{
//    public class CustomerServices : ICustomerService
//    {
//        private readonly ApplicationDbContext _context;

//        public CustomerServices(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        public Task<bool> DeleteOrder(int orderId)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<object> GetOrderById(int orderId)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<object> GetOrders()
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<CustomerOrder> OrderProduct(int productId, Guid userId,  OrderDTO.AggregateOderDto orderAggregate, OrderDTO.MediaOderDto mediaOrder)
//        {
//            var productToOrder = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
//            if(productToOrder != null)
//            {
//                CustomerOrder customerOrder = new CustomerOrder();
//                if(productToOrder.Category.ToLower() == "fast food" && orderAggregate.Quantity > 0)
//                {
//                    customerOrder.DeliveryAddress = mediaOrder.DeliveryAddress;
//                    customerOrder.Detail = productToOrder.Description;
//                    customerOrder.TotalAmount = productToOrder.ConvinienceFee + (productToOrder.Amount) * orderAggregate.Quantity;
//                    customerOrder.ProductId = productId;
//                    customerOrder.UserId = userId;
//                    customerOrder.Aggregate = new OrderCategory
//                    {
//                        Category = productToOrder.Category,
//                        Price = customerOrder.TotalAmount,
//                        Quantity = orderAggregate.Quantity
//                    };

//                    _context.CustomerOrders.Add(customerOrder);
//                    await _context.SaveChangesAsync();

//                }
                
//                else if(productToOrder.Category.ToLower() == "Event Tickect" && orderAggregate.Quantity > 0)
//                {

//                }
               

//            }
//        }

//        public Task<bool> UpdateOrder(int orderId)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
