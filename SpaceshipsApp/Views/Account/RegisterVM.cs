using System.ComponentModel.DataAnnotations;

namespace Spaceships.Web.Views.Account;

public class RegisterVM
{
    [Required]
    [Display(Name = "First Name")]
    public required string FirstName { get; set; } 

    [Required]
    [Display(Name = "Last Name")]
    public required string LastName { get; set;} 

    [Required]
    [Display(Name = "E-mail")]
    public string Email { get; set; } 

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; } 

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Repeat password")]
    [Compare(nameof(Password))]
    public required string PasswordRepeat { get; set; }
    [Required]
    [Display(Name = "Administrator")]
    public bool IsAdmin { get; set; } = false;
}
