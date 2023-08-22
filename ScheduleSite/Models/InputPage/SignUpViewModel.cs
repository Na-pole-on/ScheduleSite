using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ScheduleSite.Models.InputPage
{
    public class SignUpViewModel
    {
        public string? Id { get; set; }

        [Required]
        [RegularExpression("(\\D{1,20})", ErrorMessage = "You can't use numbers!")]
        public string? UserName { get; set; }


        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [RegularExpression(@"\+\d{1,3}\(\d{1,3}\)\d{3}\-\d{2}\-\d{2}", ErrorMessage = "Enter the phone number in format +x(x)xxx-xx-xx")]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Compare("RepeatPassword", ErrorMessage = "Passwords don't match!")]
        public string? Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match!")]
        public string? RepeatPassword { get; set; }

        [Required]
        [Range(1, 2, ErrorMessage = "You didn't choose a role!")]
        public int Role { get; set; }
    }
}
