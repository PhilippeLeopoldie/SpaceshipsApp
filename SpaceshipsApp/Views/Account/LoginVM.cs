using System.ComponentModel.DataAnnotations;

namespace Spaceships.Web.Views.Account;

public class LoginVM
{
    [Required]
    [Display(Name = "Username")]
    public required string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
