using System.ComponentModel.DataAnnotations;

namespace Spaceships.Web.Views.Account;

public class LoginVM
{
    [Required]
    public string? UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}
