using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intern.Model
{
    public class CustomerRepo : ICustomer
    {
        private readonly AppDbContext appDbContext;
        public CustomerRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
            var result = await appDbContext.Customers.AddAsync(customer);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Customer> DeleteCustomer(int customerId)
        {
            var result = await appDbContext.Customers.FirstOrDefaultAsync(c=>c.Id==customerId);
            if (result != null)
            {
                appDbContext.Customers.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
                return result;
        }

        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            return await appDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            return await appDbContext.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var result = await appDbContext.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id);
            if (result != null)
            {
                result.UserName = customer.UserName;
                result.PhoneNumber = customer.PhoneNumber;
                result.EmailId = customer.EmailId;
                result.Role = customer.Role;
                result.Address = customer.Address;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
