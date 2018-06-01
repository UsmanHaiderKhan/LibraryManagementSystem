using System.Collections.Generic;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Data.Handlers;
using LibraryManagementSystem.Data.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Delete(int id)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            Customer customer = new CustomerHandler().GetCustomerById(id);
            using (db)
            {
                if (customer != null)
                {
                    db.Entry(customer).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var customer = new CustomerHandler().GetCustomerById(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}