using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service_Logging
{
    public class EmailService : IEmailService
    {

        private readonly EmailSettings _emailSettings;
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _logger = logger;
            _configuration = configuration;
            _emailSettings = new EmailSettings();
            _configuration.GetSection("EmailSettings").Bind(_emailSettings);
        }
        public TaskTask SendEmailAsync(EmailData emailData)
        {
            SmtpClient emailClient = new SmtpClient(_emailSettings.Host, _emailSettings.Port);
            try
            {
                emailClient.EnableSsl = _emailSettings.UseSSL;
                if (_emailSettings.UseAuthentication)
                {
                    emailClient.Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password);

                    _logger.LogInformation($"Preparing to send email to: {emailData.ToEmail}, with subject {emailData.Subject}");
                }

                var fromEmail = new MailAddress(_emailSettings.Email, _emailSettings.Name);
                var toEmail = new MailAddress(emailData.ToEmail, emailData.ToName);

                var emailMessage = new MailAddress(fromEmail, toEmail);
                if(emailData.CCs != null)
                {
                    foreach (var cc in emailData.CCs)
                    {
                        var adresa = new MailAddress(cc.Key, cc.Value);
                        emailMessage.Add(adresa);
                        
                    }
                }

            }

        }

    }
   }
}
