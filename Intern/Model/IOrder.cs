using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intern.Model
{
    public interface IOrder
    {
        //All Details
        Task<IEnumerable<Order>> GetOrder();
        //Single Details
        Task<Order> GetOrder(int orderId);
        //Add an Employee
        Task<Order> AddOrder(Order order);
        //Update an Employee
        Task<Order> UpdateOrder(Order order);
        //Delete an Employee
        Task<Order> DeleteOrder(int orderId);
    }
}
