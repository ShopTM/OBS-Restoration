using System.Linq;
using System.Net;
using System.Net.Mail;
using Common;
using Models.VM.RequestForm;
using System.ComponentModel;
using System.Collections.Generic;

namespace BAL.Managers
{
    public class EmailManager
    {
        private const string CONTACT_US_REQUEST_EMAIL_SUBJECT = "OBS contact request";
        private const string CAREER_REQUEST_EMAIL_SUBJECT = "OBS career request";
        private const string JOB_ESTIMATION_EMAIL_SUBJECT = "OBS job estimation request";

        public void SendJobEstimationEmail(JobEstimationRequestFormVM model)
        {
            var attachments = new List<Attachment>();
            if (model.Files != null && model.Files.Any())
                foreach (var file in model.Files)
                    if (file != null)
                        attachments.Add(new Attachment(file.InputStream, file.FileName));
            SendEmail(model, JOB_ESTIMATION_EMAIL_SUBJECT, attachments);
        }
        public void SendCareerEmail(CareerRequestFormVM model)
        {
            var attachments = new List<Attachment>();
            if (model.Resume != null)
                attachments.Add(new Attachment(model.Resume.InputStream, model.Resume.FileName));
            SendEmail(model, CAREER_REQUEST_EMAIL_SUBJECT, attachments);
        }
        public void SendContactUsEmail(ContactRequestFormVM model)
        {
            var attachments = new List<Attachment>();
            if (model.Files != null && model.Files.Any())
                foreach (var file in model.Files)
                    if (file != null)
                        attachments.Add(new Attachment(file.InputStream, file.FileName));
            SendEmail(model, CONTACT_US_REQUEST_EMAIL_SUBJECT, attachments);
        }
        private void SendEmail(object model, string subject, List<Attachment> attachments = null)
        {
            var from = new MailAddress(ConfigHelper.SmtpFromEmail, subject);
            var to = new MailAddress(ConfigHelper.SmtpToEmail);
            var message = new MailMessage(from, to)
            {
                Subject = subject,
                Body = ToBodyMessage(model),
                IsBodyHtml = false,
            };
            if (attachments != null)
                attachments.ForEach(x => message.Attachments.Add(x));

            var smtpClient = new SmtpClient(ConfigHelper.SmtpHost, ConfigHelper.SmtpPort ?? 25)
            {
                Credentials = new NetworkCredential(ConfigHelper.SmtpFromEmail, ConfigHelper.SmtpPassword)
            };
            smtpClient.Send(message);
        }
        private string ToBodyMessage(object obj)
        {
            var message = "";
            var type = obj.GetType();
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                var attrName = (prop.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault() as DisplayNameAttribute)?.DisplayName;
                if (string.IsNullOrWhiteSpace(attrName)) continue;
                message += $"{attrName}: {prop.GetValue(obj)}\r\n";
            }
            return message;
        }
    }
}
