using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewApp.Model
{
    [Table("Users")]
    [Index(nameof(EmailAddress), IsUnique = true)]

    public class User
    {
        [Key]
        public long UserId { get; set; }
        [Required(ErrorMessage = "Enter email address")]
        public string EmailAddress { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public string? RefreshToken { get; set; }  // Field to store the refresh token
        public DateTime RefreshTokenExpiryDate { get; set; } // Field to store the refresh token expiration date
        [ForeignKey("UserRole")]
        public long UserRoleId { get; set; }
        public UserRole Role { get; set; }
    }
}
