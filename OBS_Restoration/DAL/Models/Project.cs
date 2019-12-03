using System.Collections.Generic;

namespace DAL.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public virtual ICollection<ProjectImage> Images { get; set; }
    }
}
