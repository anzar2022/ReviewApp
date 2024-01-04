using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.DTO
{
    public record CreateUserDto([Required(ErrorMessage = "Email address is required")]string EmailAddress, 
        [Required(ErrorMessage = "Is Active is required")]  bool IsActive, 
        [Required(ErrorMessage = "Password is required")] string Password,
        [Required(ErrorMessage = "User Role Id is required")] long UserRoleId);

    public record UpdateUserDto([Required(ErrorMessage = "Email address is required")] string EmailAddress,
        [Required(ErrorMessage = "Is Active is required")] bool IsActive,
        [Required(ErrorMessage = "Password is required")] string Password,
        [Required(ErrorMessage = "User Role Id is required")] long UserRoleId);

}
