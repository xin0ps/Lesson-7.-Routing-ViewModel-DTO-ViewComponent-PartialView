using System.ComponentModel.DataAnnotations;

namespace Lesson_7_Validation.Models.ViewModels;

public class RegisterViewModel
{
    [Required]
    [StringLength(100, MinimumLength = 4)]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}