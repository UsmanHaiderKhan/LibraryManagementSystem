using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Data.Handlers;
using LibraryManagementSystem.Data.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public class LendController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var availableBooks = new BookHandler().GetBookwithAuthorBorrower(x => x.Customer.CustomerId == 0);
            if (availableBooks.Count == 0)
            {
                return View("Empty");
            }

            return View(availableBooks);

        }
        [HttpGet]
        public IActionResult LendBook(int bookId)
        {
            var lendViewModel = new LendViewModel()
            {
                Book = new BookHandler().GetBookById(bookId),
                Customers = new CustomerHandler().GetAllCustomer()
            };
            return View(lendViewModel);
        }

        [HttpPost]
        public IActionResult LendBook(LendViewModel lendViewModel)
        {

            var book = new BookHandler().GetBookById(lendViewModel.Book.BookId);
            var customer = new CustomerHandler().GetCustomerById(lendViewModel.Book.Customer.CustomerId);
            book.Customer = customer;
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}