using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data.Handlers
{
    public class CustomerHandler
    {
        public List<Customer> GetAllCustomer()
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();

            using (var db = new LibraryContext(builder.Options))
            {
                return (from c in db.Customers select c).ToList();
            }
        }

        public Customer GetCustomerById(int id)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from c in db.Customers where c.CustomerId == id select c).FirstOrDefault();
            }
        }
        public int GetCustomerCount()
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from o in db.Customers select o).Count();
            }
        }
    }
}
