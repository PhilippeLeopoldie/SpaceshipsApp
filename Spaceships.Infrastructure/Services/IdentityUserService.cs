using Microsoft.AspNetCore.Identity;
using Spaceships.Application.Dtos;
using Spaceships.Application.Users;
using Spaceships.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Spaceships.Infrastructure.Services;

public class IdentityUserService(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    RoleManager<IdentityRole> roleManager) 
    : IIdentityUserService
{
    public async Task<UserResultDto> CreateUserAsync(UserProfileDto user, string password)
    {
        var applicationUser = new ApplicationUser
        {
            UserName = user.Email,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            IsAdmin = user.IsAdmin
        };
        var result = await userManager.CreateAsync(applicationUser, password);
        if(!result.Succeeded) 
        return new UserResultDto(result.Errors.FirstOrDefault()?.Description);

        // Add FirstName claim to database 
        await userManager.AddClaimAsync(applicationUser, new Claim("FirstName", applicationUser.FirstName));
        await userManager.AddClaimAsync(applicationUser, new Claim("IsAdmin", applicationUser.IsAdmin.ToString()));

        if (applicationUser.IsAdmin)
        {
            const string adminRoleName = "Administrator";
            // Skapa en ny roll
            if (!await roleManager.RoleExistsAsync(adminRoleName))
                await roleManager.CreateAsync(new IdentityRole(adminRoleName));

            // Lägg till en användare till en roll
            
                await userManager.AddToRoleAsync(applicationUser, adminRoleName);

            // Kontrollera huruvida en användare ingår i en roll
            bool isUserInRole = await userManager.IsInRoleAsync(applicationUser, adminRoleName);

        }

        return new UserResultDto(null);
    }

    

    public async Task<UserResultDto> SignInAsync(string email, string password)
    {
        var result = await signInManager.PasswordSignInAsync(email, password, false, false);
        return new UserResultDto(result.Succeeded ? null : "Invalid User credentials");
    }

    public async Task  SignOutAsync()
    {
        await signInManager.SignOutAsync();
    }
}
