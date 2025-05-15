using System.ComponentModel.DataAnnotations;

namespace SklepHkr2025.Model.Email
{
    public class EmailSettingsForListVm
    {
        public int? Id { get; set; }
        [Required]
        public string EmailNameSettings { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string SmtpServer { get; set; } = string.Empty;
        [Required]
        public int Port { get; set; }
        public string AdminEmail { get; set; } = string.Empty;
        public bool EnableSsl { get; set; } = false;
    }
}
