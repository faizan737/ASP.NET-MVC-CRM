using ASP.NET_CRM_System_Development.BLL;
using ASP.NET_CRM_System_Development.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_CRM_System_Development.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;
        //Unity will automatically Inject CustomerServices into the controller constructor
        public CustomerController(CustomerService services)
        {
            _customerService = services;
        }
        

        // GET: Customer
        public async Task<ActionResult> Index()
        {
            var customer =  await _customerService.GetAllCustomers();
            return View(customer);
        }
        /// <summary>
        /// GET: Create Action - Shows the create view
        /// </summary>
        /// <returns></returns>
        public ActionResult Create() => View();

        /// <summary>
        /// POST: Create Action - Handles form submission asynchronously
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        /// <summary>
        /// GET: Edit Action - Shows the edit view with customer data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        public async Task<ActionResult> Edit(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return HttpNotFound();  // If no customer found, show 404 error
            }
            return View(customer);
        }
        /// <summary>
        /// POST: Edit Acion - Handles the form sbmission asynchronously
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        /// <summary>
        /// GET: Delete Action - Delete a Customer asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);   //Render the delete view
        }
        /// <summary>
        /// POST: Delete Action - Handles the form sbmission asynchronously for delete
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Delete(Customer customer)
        {
            if (customer.Id > 0) // Ensure the Id is valid
            {
                await _customerService.DeleteCustomer(customer.Id);
            }

            return RedirectToAction("Index");
        }
    }
}