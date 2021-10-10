using Intern.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer customerRepo;
        public CustomerController(ICustomer _customerRepo)
        {
            customerRepo = _customerRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetCustomer()
        {
            try
            { 
                return Ok(await customerRepo.GetCustomer());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            try
            {
                var result = await customerRepo.GetCustomer(id);
                if (result == null)
                    return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateEmployee(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest();
                }

                var createdCustomer = await customerRepo.AddCustomer(customer);
                return CreatedAtAction(nameof(GetCustomer),
                    new { id = createdCustomer.Id }, createdCustomer
                    );
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating new Customer record");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            try
            {
                var customerToDelete = await customerRepo.GetCustomer(id);
                if (customerToDelete == null)
                {
                    return NotFound($"Customer with Id={id} not found");
                }

                return await customerRepo.DeleteCustomer(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, Customer customer)
        {
            try
            {
                if (id != customer.Id)
                    return BadRequest("Customer ID mismatch");

                var customerToUpdate = await customerRepo.GetCustomer(id);

                if (customerToUpdate == null)
                    return NotFound($"Customer with Id = {id} not found");

                return await customerRepo.UpdateCustomer(customer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}
