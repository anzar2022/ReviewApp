using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.Model
{
    [Table("Users")]
    [Index(nameof(EmailAddress), IsUnique =true)]

    public class User
    {
        [Key]
        public int UserId {  get; set; }
        [Required(ErrorMessage = "Enter email address")]
        public string EmailAddress { get; set; } =string.Empty;
        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; } =  string.Empty;
        public bool IsActive { get; set; } = false;
    }
}
