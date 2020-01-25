using System;
using System.Configuration;

namespace Common
{
    public class ConfigHelper
    {
        private const string SMTP_TO_EMAIL = "SmtpToEmail";
        private const string SMTP_FROM_EMAIL = "SmtpFromEmail";
        private const string SMTP_PASSWORD = "SmtpPassword";
        private const string SMTP_HOST = "SmtpHost";
        private const string SMTP_PORT = "SmtpPort";

        public static string SmtpToEmail
        {
            get
            {
                return GetString(SMTP_TO_EMAIL);
            }
        }
        public static string SmtpFromEmail
        {
            get
            {
                return GetString(SMTP_FROM_EMAIL);
            }
        }
        public static string SmtpPassword
        {
            get
            {
                return GetString(SMTP_PASSWORD);
            }
        }
        public static string SmtpHost
        {
            get
            {
                return GetString(SMTP_HOST);
            }
        }
        public static int? SmtpPort
        {
            get
            {
                return GetInteger(SMTP_PORT);
            }
        }
        private static int? GetInteger(string key)
        {
            string value = ConfigurationManager.AppSettings[key];

            if (!string.IsNullOrWhiteSpace(value))
            {
                int answer;
                if (int.TryParse(value, out answer))
                {
                    return answer;
                }
            }

            return null;
        }
        private static bool GetBoolean(string key)
        {
            string value = ConfigurationManager.AppSettings[key];

            if (!string.IsNullOrWhiteSpace(value))
            {
                bool answer;
                if (bool.TryParse(value, out answer))
                {
                    return answer;
                }
            }

            return false;
        }
        private static DateTime? GetDateTime(string key)
        {
            string value = ConfigurationManager.AppSettings[key];

            if (!string.IsNullOrWhiteSpace(value))
            {
                DateTime answer;
                if (DateTime.TryParse(value, out answer))
                {
                    return answer;
                }
            }

            return null;
        }
        private static TimeSpan? GetTimeSpan(string key)
        {
            string value = ConfigurationManager.AppSettings[key];

            if (!string.IsNullOrWhiteSpace(value))
            {
                TimeSpan answer;
                if (TimeSpan.TryParse(value, out answer))
                {
                    return answer;
                }
            }

            return null;
        }
        private static string GetString(string key)
        {
            string value = ConfigurationManager.AppSettings[key];

            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            return null;
        }

    }
}

