using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace forma1Example.Models
{
    public class Account
    {
        [Key]
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string PasswordHash { get; set; }

    }
}
