using System.ComponentModel.DataAnnotations;

namespace Spaceships.Web.Views.Account;

public class LoginVM
{
    [Required]
    [Display(Name = "User Email")]
    public required string UserEmail { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
