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
    }
}
