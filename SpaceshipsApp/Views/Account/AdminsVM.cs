namespace Spaceships.Web.Views.Account;

public class AdminsVM
{
    public required string FirstName { get; set; }
    public required string Email { get; set; }
    public bool IsAdmin { get; set; }
}
