using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intern.Model
{
    public interface ICustomer
    {
        //All Details
        Task<IEnumerable<Customer>> GetCustomer();
        //Single Details
        Task<Customer> GetCustomer(int customerId);
        //Add an Employee
        Task<Customer> AddCustomer(Customer customer);
        //Update an Employee
        Task<Customer> UpdateCustomer(Customer customer);
        //Delete an Employee
        Task<Customer> DeleteCustomer(int customerId);
    }
}
