using System.ComponentModel.DataAnnotations;

namespace AuditForm.Dtos
{
    public class UserRegDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [Display(Name = "Username")]
        public string Username { get; set; } = "";
        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; } = "";
    }
}
