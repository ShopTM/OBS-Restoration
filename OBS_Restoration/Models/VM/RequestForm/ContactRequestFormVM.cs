using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Models.VM.RequestForm
{
    public class ContactRequestFormVM
    {
        [Required]
        [DisplayName("Full name")]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("Email address")]
        public string EmailAddress { get; set; }
        [DisplayName("Company")]
        public string Company { get; set; }
        [Phone]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("Message")]
        public string Message { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}