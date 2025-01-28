using ASP.NET_CRM_System_Development.DAL;
using ASP.NET_CRM_System_Development.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ASP.NET_CRM_System_Development.BLL
{
    public class CustomerService
    {
        private readonly CustomerRepository _repository = new CustomerRepository();

        public async Task< IEnumerable<Customer>> GetAllCustomers()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task AddCustomer(Customer customer)
        {
            await _repository.AddAsync(customer);
        }
        public async Task UpdateCustomer(Customer customer)
        { 
            await _repository.UpdateAsync(customer);
        }
        public async Task DeleteCustomer(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}