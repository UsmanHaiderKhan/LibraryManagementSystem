using System.Collections.Generic;
using LibraryManagementSystem.Data.Handlers;
using LibraryManagementSystem.Data.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var customerViewModel = new List<CustomerViewModel>();
            List<Customer> customers = new CustomerHandler().GetAllCustomer();
            if (customers.Count == 0)
            {
                return View("Empty");
            }

            foreach (var customer in customers)
            {
                customerViewModel.Add(new CustomerViewModel
                {
                    Customer = customer,
                    BookCount = new BookHandler().BookCount(customer)
                });

            }
            return View(customerViewModel);
        }
    }
}