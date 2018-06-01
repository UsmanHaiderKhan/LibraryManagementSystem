using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data.Handlers
{
    public class BookHandler
    {
        public List<Book> GetBookwithAuthorandBorrowerById(int id)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from c in db.Books.Include(m => m.Author).Include(m => m.Borrower) where c.BorrowerId == id select c).ToList();
            }
        }

        public int BookCount(Customer customer)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from c in db.Books where c.BorrowerId == customer.CustomerId select c).Count();
            }
        }

        public List<Book> GetBookswithAuthor()
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from c in db.Books.Include(m => m.Author) select c).ToList();
            }
        }

        public Book GetBookById(int id)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from c in db.Books where c.BookId == id select c).FirstOrDefault();
            }
        }

        public List<Book> GetBookwithAuthorBorrower(int num)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from c in db.Books.Include(m => m.Borrower) where c.BorrowerId == 0 select c)
                    .ToList();
            }
        }
    }
}
