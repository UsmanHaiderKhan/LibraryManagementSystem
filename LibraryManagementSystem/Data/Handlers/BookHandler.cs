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
        public Book GetBookById(Customer customer)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from c in db.Books where c.BorrowerId == customer.CustomerId select c).FirstOrDefault();
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
    }
}
