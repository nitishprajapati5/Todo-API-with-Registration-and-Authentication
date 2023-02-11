using APIServices.Models;
using APIServices.Models.Config;
using MailKit;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Services
{
    public class MailService
    {
        private readonly AppConfig _appConfig;
        public MailService(IOptions<AppConfig> appconfig)
        {
            _appConfig = appconfig.Value;
        }

        public async Task SendMailAsync(MailRequest mailRequest)
        {

            MailAddress Receiver = new MailAddress(mailRequest.ToEmail);
            MailAddress Sender = new MailAddress(_appConfig.MailServiceConfig.Mail);
            MailMessage message = new MailMessage(Sender, Receiver);
            message.Subject = mailRequest.Subject;
            message.Body = mailRequest.Body;
            message.Priority = MailPriority.High;
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;

                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        message.Attachments.Add((Attachment)file);
                    }
                }

            }

            SmtpClient client = new SmtpClient(_appConfig.MailServiceConfig.Host, _appConfig.MailServiceConfig.Port)
            {
                Credentials = new NetworkCredential(_appConfig.MailServiceConfig.Mail, _appConfig.MailServiceConfig.Password),
                EnableSsl = true
            };

            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            client.Dispose();
        }
    }
}


