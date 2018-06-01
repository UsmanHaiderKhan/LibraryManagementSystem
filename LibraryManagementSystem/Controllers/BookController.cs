using System;
using System.Collections.Generic;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Data.Handlers;
using LibraryManagementSystem.Data.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        // GET
        public IActionResult Index(int? authorId, int? borrowerId)
        {
            if (authorId == null && borrowerId == null)
            {
                //show All Books
                var books = new BookHandler().GetBookswithAuthor();
                return CheckBookCount(books);
            }
            else if (authorId != null)
            {
                //filter by Author By Id
                var author = new AuthorHandler().GetAuthorwithBooksById((int)authorId);
                if (author.Books.Count == 0)
                {
                    return View("AuthorEmpty", author);
                }
                else
                {
                    return View(author.Books);
                }
            }
            else if (borrowerId != null)
            {
                var books = new BookHandler().GetBookwithAuthorandBorrowerById((int)borrowerId);
                return CheckBookCount(books);
            }
            else
            {
                //through Exception
                throw new ArgumentException();
            }
            return View();
        }

        public IActionResult CheckBookCount(List<Book> books)
        {
            if (books.Count == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(books);
            }
        }
        [HttpGet]
        public IActionResult AddBooks()
        {
            var bookViewModel = new BookViewModel()
            {
                Authors = new AuthorHandler().GetAllAuthors()
            };
            return View(bookViewModel);
        }
        [HttpPost]
        public IActionResult AddBooks(BookViewModel bookViewModel)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                db.Books.Add(bookViewModel.Book);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateBooks(int id)
        {
            var bookViewModel = new BookViewModel()
            {
                Book = new BookHandler().GetBookById(id),
                Authors = new AuthorHandler().GetAllAuthors()
            };
            return View(bookViewModel);
        }

        [HttpPost]
        public IActionResult UpdateBooks(BookViewModel bookViewModel)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                db.Entry(bookViewModel.Book).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBook(int id)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);

            var book = new BookHandler().GetBookById(id);
            if (book != null)
            {
                db.Entry(book).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}