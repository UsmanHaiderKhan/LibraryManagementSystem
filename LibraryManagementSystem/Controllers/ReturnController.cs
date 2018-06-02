﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Data.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public class ReturnController : Controller
    {
        public IActionResult Index()
        {
            var bookhandler = new BookHandler().GetBookwithAuthorBorrower(x => x.BorrowerId != 0);
            if (bookhandler == null || bookhandler.ToList().Count == 0)
            {
                return View("Empty");
            }
            return View(bookhandler);
        }

        public IActionResult ReturnBook(int bookId)
        {
            var book = new BookHandler().GetBookById(bookId);

            book.Borrower = null;
            book.BorrowerId = 0;

            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("index");
        }
    }
}