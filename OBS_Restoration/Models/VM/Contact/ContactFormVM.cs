using System.ComponentModel.DataAnnotations;

namespace OBS_Restoration.Models.VM.Contact
{
    public class ContactFormVM
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Message { get; set; }
    }
}