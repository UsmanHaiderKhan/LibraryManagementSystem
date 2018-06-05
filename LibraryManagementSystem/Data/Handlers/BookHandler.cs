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
                return (from c in db.Books.Include(m => m.Author).Include(m => m.Customer)
                        where c.Customer.CustomerId == id
                        select c).ToList();
            }
        }

        public int BookCount(Customer customer)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from c in db.Books where c.Customer.CustomerId == customer.CustomerId select c).Count();
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
                return (from c in db.Books.Include(m => m.Customer).Include(m => m.Author)
                        where c.BookId == id
                        select c).FirstOrDefault();
            }
        }

        public List<Book> GetBookwithAuthorBorrower(Func<Book, bool> predicate)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from c in db.Books
                            .Include(m => m.Author)
                            .Include(m => m.Customer)
                            .Where(predicate)
                        select c)
                    .ToList();
            }
        }
        public int GetBookCount()
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from o in db.Books select o).Count();
            }
        }
        public int GetLendCount(Func<Book, bool> predicate)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from o in db.Books
                    .Include(m => m.Customer)
                    .Where(predicate)
                        select o).Count();
            }
        }
    }
}