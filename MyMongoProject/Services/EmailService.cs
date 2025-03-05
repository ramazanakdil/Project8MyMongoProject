

using MimeKit;
using MailKit.Net.Smtp;
using System.Net;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


namespace MyMongoProject.Services

{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("Ramazan Akdil", "ramazan@dijexa.com"));
                emailMessage.To.Add(new MailboxAddress("", to));
                emailMessage.Subject = subject;

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = body
                };

                emailMessage.Body = bodyBuilder.ToMessageBody();

                using (var smtpClient = new SmtpClient())
                {
                    await smtpClient.ConnectAsync("smtp.hostinger.com", 465, true);
                    await smtpClient.AuthenticateAsync("ramazan@dijexa.com", "R.u887526");
                    await smtpClient.SendAsync(emailMessage);
                    await smtpClient.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Mail gönderme hatası: {ex.Message}");
            }
        }
    }
}
