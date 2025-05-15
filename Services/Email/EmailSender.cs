using Microsoft.AspNetCore.Identity;
using MimeKit;
using SklepHkr2025.Data;
using SklepHkr2025.Model.Email;

namespace SklepHkr2025.Services.Email
{
    public class EmailSender : IEmailSender<ApplicationUser>
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> SendEmail(EmailMessageVm emailMessage)
        {
            var emailConfiguration = await GetEmailSettings();
            if (emailConfiguration == null)
            {
                return false;
            }
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(emailConfiguration.EmailNameSettings, emailConfiguration.UserName));
            email.To.Add(new MailboxAddress(emailMessage.EmailTo, emailMessage.EmailTo));
            email.Subject = emailMessage.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailMessage.Body
            };
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(emailConfiguration.SmtpServer, emailConfiguration.Port, MailKit.Security.SecureSocketOptions.SslOnConnect);
                client.Authenticate(emailConfiguration.UserName, emailConfiguration.Password);
                await client.SendAsync(email);
                await client.DisconnectAsync(true);
            }
            return true;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var emailConfiguration = await GetEmailSettings();
            if (emailConfiguration == null)
            {
              throw new ArgumentNullException(nameof(emailConfiguration));
            }
            var emailMessage = new MimeMessage();
            emailMessage.Headers.Add("X-Mailer", "Sklep hkr24.pl widomosc");
            emailMessage.Headers.Add("X-Priority", "3");
            emailMessage.From.Add(new MailboxAddress(emailConfiguration.EmailNameSettings, emailConfiguration.UserName));
            emailMessage.To.Add(new MailboxAddress("mailbox", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = htmlMessage
            };
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync(emailConfiguration.SmtpServer, emailConfiguration.Port, MailKit.Security.SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(emailConfiguration.UserName, emailConfiguration.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

        public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
        {
            EmailMessageVm emailMessage = new EmailMessageVm
            {
                EmailTo = email,
                Subject = $"Potwierdź rejestracje na stronie Sklep hkr24.pl.",
                Body = $" <!DOCTYPE html>\r\n<html>\r\n<body>\r\n    <p>Witaj,</p>\r\n    <p>Proszę potwierdzić swoją rejestrację, klikając w poniższy link:</p>\r\n    <a href=\"{confirmationLink}\">Potwierdź rejestrację</a>\r\n    <p>Pozdrawiamy,<br>Zespół hkr24.pl</p>\r\n</body>\r\n</html>"
            };
            return SendEmail(emailMessage);
        }

        public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
        {
            EmailMessageVm emailMessage = new EmailMessageVm
            {
                EmailTo = email,
                Subject = $"Link do resetu hasła na stronie Sklep hkr24.pl.",
                Body = $" <!DOCTYPE html>\r\n<html>\r\n<body>\r\n    <p>Witaj,</p>\r\n    <p>Można zresetować hasło, klikając w poniższy link:</p>\r\n    <a href=\"{resetLink}\">resetuj hasło</a>\r\n    <p>Pozdrawiamy,<br>Zespół hkr24.pl</p>\r\n</body>\r\n</html>"
            };
            return SendEmail(emailMessage);
        }

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
        {
            throw new NotImplementedException();
        }
        private async Task<EmailSettingsForListVm> GetEmailSettings()
        {
            EmailSettingsForListVm emailSettings = new EmailSettingsForListVm
            {
                UserName = _configuration["EmailSettings:SmtpUsername"],
                Password = _configuration["EmailSettings:SmtpPassword"],
                SmtpServer = _configuration["EmailSettings:SmtpServer"],
                Port = int.Parse(_configuration["EmailSettings:SmtpPort"]),
                EnableSsl = bool.Parse(_configuration["EmailSettings:EnableSsl"]),
                EmailNameSettings = ""
            };
            return emailSettings;
        }
    }
}
