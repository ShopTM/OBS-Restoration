using System;
using Common;
using OBS_Restoration.Models.VM.Contact;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;

namespace BAL.Managers
{
    public class EmailManager
    {
        static EmailManager()
        {
            Configuration.Default.ApiKey.Add("api-key", ConfigHelper.SmtpApiKey);
        }
        public void SendContactUsEmail(ContactFormVM model)
        {
            var apiInstance = new AccountApi();

            try
            {
                // Get your account informations, plans and credits details
                
                //GetAccount result = apiInstance.GetAccount();
                //var a = result.Plan.Capacity;
            }
            catch (Exception e)
            {
            }
        }
    }
}
