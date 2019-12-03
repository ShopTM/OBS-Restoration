using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ProjectImage
    {
        public int Id { get; set; }
        public int Ordrer { get; set; }
        public string Url { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
