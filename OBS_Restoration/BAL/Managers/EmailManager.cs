using System.Linq;
using System.Net;
using System.Net.Mail;
using Common;
using System.ComponentModel.DataAnnotations;
using Models.VM.RequestForm;

namespace BAL.Managers
{
    public class EmailManager
    {
        private const string CONTACT_US_REQUEST_EMAIL_SUBJECT = "OBS contact request";
        private const string CAREER_REQUEST_EMAIL_SUBJECT = "OBS career request";
        private const string JOB_ESTIMATION_EMAIL_SUBJECT = "OBS job estimation request";

        public void SendJobEstimationEmail(JobEstimationRequestFormVM model)
        {
            Attachment attachment = null;
            if (model.File!=null)
                attachment = new Attachment(model.File.InputStream, model.File.FileName);
            SendEmail(model, JOB_ESTIMATION_EMAIL_SUBJECT, attachment);
        }
        public void SendCareerEmail(CareerRequestFormVM model)
        {
            Attachment attachment = null;
            if (model.Resume != null)
                attachment = new Attachment(model.Resume.InputStream, model.Resume.FileName);
            SendEmail(model, CAREER_REQUEST_EMAIL_SUBJECT, attachment);
        }
        public void SendContactUsEmail(ContactRequestFormVM model)
        {
            SendEmail(model, CONTACT_US_REQUEST_EMAIL_SUBJECT);
        }
        private void SendEmail(object model,string subject, Attachment attachment = null)
        {
            var from = new MailAddress(ConfigHelper.SmtpFromEmail, subject);
            var to = new MailAddress(ConfigHelper.SmtpToEmail);
            var message = new MailMessage(from, to)
            {
                Subject = subject,
                Body = ToBodyMessage(model),
                IsBodyHtml = false,
            };
            if(attachment!=null)
                message.Attachments.Add(attachment);

            var smtpClient = new SmtpClient(ConfigHelper.SmtpHost, ConfigHelper.SmtpPort ?? 25);
            smtpClient.Credentials = new NetworkCredential(ConfigHelper.SmtpFromEmail, ConfigHelper.SmtpPassword);
            smtpClient.Send(message);
        }
        private string ToBodyMessage(object obj)
        {
            var message = "";
            var type = obj.GetType();
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                var attrName = (prop.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute)?.GetName();
                if (string.IsNullOrWhiteSpace(attrName))
                {
                    continue;
                    //attrName += prop.Name;
                }
                message += $"{attrName}: {prop.GetValue(obj)}\r\n";
            }
            return message;
        }
    }
}
