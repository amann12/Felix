using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intern.Model
{
    public class OrderRepo : IOrder
    {
        private readonly AppDbContext appDbContext;
        public OrderRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Order> AddOrder(Order order)
        {
            var result = await appDbContext.Orders.AddAsync(order);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Order> DeleteOrder(int orderId)
        {
            var result = await appDbContext.Orders.FirstOrDefaultAsync(c => c.Id == orderId);
            if (result != null)
            {
                appDbContext.Orders.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<IEnumerable<Order>> GetOrder()
        {
            return await appDbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetOrder(int orderId)
        {
            return await appDbContext.Orders.FirstOrDefaultAsync(c => c.Id == orderId);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            var result = await appDbContext.Orders.FirstOrDefaultAsync(c => c.Id == order.Id);
            if (result != null)
            {
                result.RecieverName = order.RecieverName;
                result.PickLocation = order.PickLocation;
                result.DropLocation = order.DropLocation;
                result.OrderId = order.OrderId;
                result.Type = order.Type;
                result.Weight = order.Weight;
                result.Dimensions = order.Dimensions;
                result.TotalCost = order.TotalCost;
                result.Status = order.Status;
                result.RecieverPinCode = order.RecieverPinCode;
                result.RecieverPhoneNumber = order.RecieverPhoneNumber;
                result.ValueOfParcel = order.ValueOfParcel;
                result.UserName = order.UserName;
                result.SenderPhoneNumber = order.SenderPhoneNumber;
                result.PinCode = order.PinCode;
                result.PickUpDate = order.PickUpDate;
                result.PickUpTime = order.PickUpTime;
                result.OrderAssignId = order.OrderAssignId;
                

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
