using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Email
{
    public class EmailService : IEmailService
    {
        public Task Execute(string email, string body, string title)
        {
           SmtpClient client=new SmtpClient();

            client.Port = 587;
            client.Host = "smtp.gmail.com";

            client.EnableSsl = true;
            client.Timeout = 1000000;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            client.Credentials = new NetworkCredential("", "");
            MailMessage mail = new MailMessage("", email,title,body);

            mail.IsBodyHtml = true;
            mail.BodyEncoding = Encoding.UTF8;

            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
            client.Send(mail);

            return Task.CompletedTask;
        }
    }
}
