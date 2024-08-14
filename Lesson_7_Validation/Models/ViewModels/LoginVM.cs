using System.ComponentModel.DataAnnotations;

namespace Lesson_7_Validation.Models.ViewModels;

public class LoginVM
{
    [Required]
    [StringLength(100, MinimumLength = 4)]
    public string Username { get; set; }


    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

}
