using Foolproof;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ServiceEntity = Models.Entities.Service;

namespace Models.VM.Service
{
    public class ServiceVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int Order { get; set; }
        [RequiredIf(nameof(Id), Operator.EqualTo, 0)]
        public HttpPostedFileBase Image { get; set; }

        public ServiceEntity ToEntity()
        {
            return new ServiceEntity
            {
                Id = Id,
                Description = Description,
                ImgUrl = ImgUrl,
                Name = Name,
                Order = Order
            };
        }
    }
}
