using System.ComponentModel.DataAnnotations;

namespace SklepHkr2025.Model.Auth
{
    public class RegisterInputVm
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasła nie są takie same !")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public bool RecaptchaOk { get; set; } = false;

    }
}
