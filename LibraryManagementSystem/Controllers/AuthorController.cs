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
    public class AuthorController : Controller
    {
        // GET
        public IActionResult Index()
        {
            List<Author> authors = new AuthorHandler().GetAlAuthorsWithBooks();
            if (authors.Count == 0)
            {
                return View("Empty");
            }
            return View(authors);
        }
        [HttpGet]
        public IActionResult UpdateAuthor(int id)
        {
            var author = new AuthorHandler().GetAuthorById(id);
            return View(author);
        }
        [HttpPost]
        public IActionResult UpdateAuthor(Author author)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            if (author != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(author).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddAuthor()
        {
            var viewModel = new AuthorViewModel
            {
                Referer = Request.Headers["Referer"].ToString()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddAuthor(AuthorViewModel authorViewModel)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                if (authorViewModel != null)
                {
                    if (ModelState.IsValid)
                    {
                        db.Authors.Add(authorViewModel.Author);
                        db.SaveChanges();
                        if (!String.IsNullOrEmpty(authorViewModel.Referer))
                        {
                            return Redirect(authorViewModel.Referer);
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAuthor(int id)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            var author = new AuthorHandler().GetAuthorById(id);
            using (db)
            {
                if (author != null)
                {
                    db.Entry(author).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}