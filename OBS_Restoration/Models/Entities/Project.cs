using System.Collections.Generic;

namespace Models.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public virtual List<ProjectImage> Images { get; set; }
    }
}
