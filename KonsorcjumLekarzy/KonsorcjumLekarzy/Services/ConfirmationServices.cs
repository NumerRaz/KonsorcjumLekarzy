using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using KonsorcjumLekarzy.Interfaces;

namespace KonsorcjumLekarzy.Services
{
    public class ConfirmationServices : IConfirmationEmail
    {
        public bool SendEmail(EmailStructure emainStructure)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            try
            {
                message.From = new MailAddress("unknowlocaladdress@gmail.com");
                message.To.Add(new MailAddress(emainStructure.To));
                message.Subject = emainStructure.Subject;
                message.IsBodyHtml = true;
                message.Body = emainStructure.Messages;

                // We use gmail as our smtp client
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("unknowlocaladdress@gmail.com", "123test123");
                smtpClient.Send(message);
                
                return true; 
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}