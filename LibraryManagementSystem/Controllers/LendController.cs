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
            var availableBooks = new BookHandler().GetBookwithAuthorBorrower();
            if (availableBooks.Count == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(availableBooks);
            }

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
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            var book = new BookHandler().GetBookById(lendViewModel.Book.BookId);
            var customer = new CustomerHandler().GetCustomerById(lendViewModel.Book.Customer.CustomerId);
            book.Customer = customer;
            using (db)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}