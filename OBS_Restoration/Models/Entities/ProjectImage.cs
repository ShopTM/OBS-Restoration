using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Script.Serialization;

namespace Models.Entities
{
    public class ProjectImage
    {
        public int Id { get; set; }
        public int Ordrer { get; set; }
        public string Url { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        [ScriptIgnore]
        public virtual Project Project { get; set; }
    }
}
