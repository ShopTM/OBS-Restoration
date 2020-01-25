using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.VM.RequestForm
{
    public class ContactRequestFormVM
    {
        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("Message")]
        public string Message { get; set; }
    }
}