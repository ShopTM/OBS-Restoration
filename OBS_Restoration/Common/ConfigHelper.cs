using System;
using System.Configuration;

namespace Common
{
    public class ConfigHelper
    {
        private const string SEND_TO_EMAIL = "SendToEmail";
        private const string SMTP_API_KEY = "SmtpApiKey";

        public static string SmtpApiKey
        {
            get
            {
                return GetString(SMTP_API_KEY);
            }
        }
        public static string SendToEmail
        {
            get
            {
                return GetString(SEND_TO_EMAIL);
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

