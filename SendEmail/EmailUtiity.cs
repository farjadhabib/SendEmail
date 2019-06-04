using System;
using System.Net;
using System.Net.Mail;

namespace SendEmail
{
    public class EmailUtiity
    {
		SmtpClient smtp;

		public EmailUtiity(string mailServer, int? port, string username, string password)
		{
			smtp = (port != null && port > 0) ? new SmtpClient(mailServer, port.Value) : new SmtpClient(mailServer);
			smtp.Credentials = new NetworkCredential(username, password);
		}

		public void SendEmailNotification(string to, string from, string subject, string body)
		{
			try
			{
				
				MailMessage mail = new MailMessage();
				mail.To.Add(to);
				mail.Subject = subject;
				mail.Body = body;
				mail.IsBodyHtml = true;
				mail.From = new MailAddress(from);
				smtp.Send(mail);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
