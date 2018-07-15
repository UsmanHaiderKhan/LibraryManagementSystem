using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data.Handlers
{
    public class UserHandler
    {
        public User GetUser(string Loginid, string Password)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from v in db.Users where v.LoginId.Equals(Loginid) && v.Password.Equals(Password) select v).FirstOrDefault();
            }
        }
    }
}
