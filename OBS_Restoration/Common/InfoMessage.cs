namespace Common
{
    public static class InfoMessage
    {
        public static class Error
        {
            public const string GENERAL_ERROR_MESSAGE = "An error has occurred during the processing of your request, please try again later.";
            public const string FAILED_VALIDATION_ERROR_MESSAGE = "Form validation is failed";
        }
        public static class Success
        {
            public const string SUCCESS_REQUEST = "The request was processed successfully";
            public const string SUCCESS_SENT_EMAIL_MESSAGE = "Your message has been sent successfully";
        }
    }
}
