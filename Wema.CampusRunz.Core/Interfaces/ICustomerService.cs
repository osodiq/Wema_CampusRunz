using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wema.CampusRunz.Core.Models;

namespace Wema.CampusRunz.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerOrder> OrderProduct(int productId);
        Task<object> GetOrderById(int orderId);
        Task<object> GetOrders();
        Task<bool> UpdateOrder(int orderId);
        Task<bool> DeleteOrder(int orderId);
        
    }
}
