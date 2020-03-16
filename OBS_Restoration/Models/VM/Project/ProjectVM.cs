using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ProjectEntity = Models.Entities.Project;
using ProjectImageEntity = Models.Entities.ProjectImage;

namespace Models.VM.Project
{
    public class ProjectVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        [Required]
        public List<ProjectImageVM> Images { get; set; } = new List<ProjectImageVM>();
        public ProjectEntity ToEntity()
        {
            return new ProjectEntity
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Order = Order,
            };
        }

    }
    public class ProjectImageVM
    {
        public int ProjectId { get; set; }
        public int Ordrer { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string Url { get; set; }

        public ProjectImageEntity ToEntity()
        {
            return new ProjectImageEntity
            {
                ProjectId = ProjectId,
                Ordrer = Ordrer,
                Url = Url,
            };
        }
    }
}
