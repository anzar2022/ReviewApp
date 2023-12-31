﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewApp.Model
{
    [Table("UserRoles")]
    public class UserRole
    {
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserRoleId { get; set; }
        [Required(ErrorMessage = "Enter user role code")]
        [MaxLength(4)]
        public string RoleCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter user name")]
        public string RoleName { get; set; } = string.Empty;

        public virtual ICollection<User> Users { get; set; }
    }
}
