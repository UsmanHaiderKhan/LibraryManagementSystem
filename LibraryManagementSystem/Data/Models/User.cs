using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FullAddress { get; set; }
        public long PhoneNo { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
    }
}
