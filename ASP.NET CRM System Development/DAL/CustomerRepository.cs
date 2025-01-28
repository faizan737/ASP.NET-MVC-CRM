using ASP.NET_CRM_System_Development.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ASP.NET_CRM_System_Development.DAL
{
    public class CustomerRepository
    {
        private readonly CustomerDbContext  _context = new CustomerDbContext();

        /*
         * I am using Async approach of EntityFrameWork methods
         * This will help avoid blocking threads while accessing the database
         * especially for long-running operations.
         * */


        /// <summary>
        /// For getting all of the customers from table
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        /// <summary>
        /// For Getting the Customer data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }
        /// <summary>
        /// For Adding the new customer in the database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task AddAsync(Customer customer)
        {
             _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// For Updating the customer data in database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        /// <summary>
        /// For Deleting the Customer data from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
               await _context.SaveChangesAsync();
            }
        }
    }
}