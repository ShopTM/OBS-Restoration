using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Models.VM.RequestForm
{
    public class JobEstimationRequestFormVM
    {
        [Required]
        [DisplayName("Type of project")]
        public string TypeOfProject { get; set; }
        [Required]
        [DisplayName("Building type")]
        public string BuildingType { get; set; }
        
        [Required]
        [DisplayName("Project summary")]
        public string ProjectSummary { get; set; }

        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Postal code")]
        public string PostalCode { get; set; }

        [DisplayName("Type of client")]
        public string TypeOfClient { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}
