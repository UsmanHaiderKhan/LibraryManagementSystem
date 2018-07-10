using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string LoginId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        public string FullAddress { get; set; }
        [Required]
        public long PhoneNo { get; set; }
        [Required]
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
    }
}
