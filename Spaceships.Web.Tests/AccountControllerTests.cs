using Microsoft.AspNetCore.Mvc;
using Moq;
using Spaceships.Application.Dtos;
using Spaceships.Application.Users;
using Spaceships.Web.Controllers;
using Spaceships.Web.Views.Account;


namespace Spaceships.Web.Tests;

public class AccountControllerTests
{
    public readonly Mock<IUserService> mockUserService ;
    public readonly AccountController controller;
    public static readonly string password = "Password123!";
   

    public AccountControllerTests()
    {
        mockUserService = new Mock<IUserService>();
        controller = new AccountController(mockUserService.Object);
    }


    [Theory]
    [InlineData(nameof(AccountController.MembersAsync), false, null)] //is not admin registered successfully
    [InlineData(nameof(AccountController.View), false, "error message")]//is not admin registered fails
    [InlineData(nameof(AccountController.AdminsAsync), true, null)]//is admin registered successfully
    [InlineData(nameof(AccountController.View), true, "error message")]//is admin registered fails
    public async Task RegisterAsync_ShouldRedirectOrReturnView_BasedOnRegistrationResult(
        string expectedAction,
        bool isAdmin,
        string errorMessage)
    {
        // Arrange
        RegisterVM viewModel = new RegisterVM
        {
            Email = "test@example.com",
            FirstName = "John",
            LastName = "Doe",
            Password = password,
            PasswordRepeat = password,
            IsAdmin = isAdmin
        };
        var successResult = new UserResultDto(errorMessage);

        mockUserService.Setup(mockService => mockService.CreateUserAsync(It.IsAny<UserProfileDto>(), viewModel.Password))
            .ReturnsAsync(successResult);
        mockUserService.Setup(mockService => mockService.SignInAsync(viewModel.Email, viewModel.Password))
            .ReturnsAsync(successResult);

        // Act
        var result = await controller.RegisterAsync(viewModel);

        // Assert
        if (errorMessage == null)
        {
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(expectedAction.Replace("Async", ""), redirect.ActionName);
        }
        else
        {
            var redirect = Assert.IsType<ViewResult>(result);
            Assert.False(controller.ModelState.IsValid);
            var error = controller.ModelState[string.Empty].Errors.FirstOrDefault()?.ErrorMessage;
            Assert.Equal(errorMessage, error);
        }
    }

    [Theory]
    [InlineData(nameof(AccountController.MembersAsync), false, null, "john@hotmail.com")] //is not admin Log In successfully
    [InlineData(nameof(AccountController.View), false, "error message", "john@hotmail.com")]//is not admin Log In fails
    [InlineData(nameof(AccountController.AdminsAsync), true, null, "john@hotmail.com")]//is admin Log In successfully
    [InlineData(nameof(AccountController.View), true, "error message", "john@hotmail.com")]//is admin Log In fails
    public async Task LoginAsync_ShouldRedirectOrReturnView_BasedOnLogInResult(
        string expectedAction,
        bool isAdmin,
        string errorMessage,
        string email)
    {
        // Arrange
        LoginVM viewModel = new LoginVM
        {
            UserEmail = email,           
            Password = password,   
        };
       
        var user = new UserProfileDto(email, "John", "Doe", isAdmin);
        var successResult = new UserResultDto(errorMessage);
        mockUserService.Setup(mockService => mockService.SignInAsync(email, viewModel.Password))
            .ReturnsAsync(successResult);
        mockUserService.Setup(mockService => mockService.GetUserByEmailAsync(viewModel.UserEmail))
            .ReturnsAsync(user);
        
        // Act
        var result = await controller.LoginAsync(viewModel);

        // Assert
        if (errorMessage == null)
        {
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(expectedAction.Replace("Async", ""), redirect.ActionName);
        }
        else
        {
            var redirect = Assert.IsType<ViewResult>(result);
            Assert.False(controller.ModelState.IsValid);
            var error = controller.ModelState[string.Empty].Errors.FirstOrDefault()?.ErrorMessage;
            Assert.Equal(errorMessage, error);
        }
    }
}
