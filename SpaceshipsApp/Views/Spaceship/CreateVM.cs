using System.ComponentModel.DataAnnotations;
using Spaceships.Domain.Entities.Enums;

namespace Spaceships.Web.Views.Spaceship;

public class CreateVM
{
    [Display(Name = "Spaceship Name")]
    [Required(ErrorMessage = "You must enter a name")]
    public string? SpaceshipName { get; set; }


    [Required(ErrorMessage = "You must enter a description")]
    public string? Description { get; set; }


    [Display(Name = "Company Name")]
    [Required(ErrorMessage = "You must enter a company")]
    public string? CompanyName { get; set; }


    [Display(Name = "Transport Type")]
    [Required(ErrorMessage = "You must select a transport type")]
    public TransportType TransportType { get; set; }


    [Display(Name = "Image URL")]
    [Required(ErrorMessage = "You must enter an image url")]
    public string? ImageUrl { get; set; }
}
