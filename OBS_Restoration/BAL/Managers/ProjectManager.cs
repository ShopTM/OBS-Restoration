using DAL;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BAL.Managers
{
    public class ProjectManager
    {
        private const string IMAGE_FULL_URL = "../../Content/Images/Projects/";
        public List<Project> All(bool isFullImgUrl = false)
        {
            using (var db = DbFactory.GetNotTrackingInstance())
            {
                var services = db.ProjectRepository.All().ToList();
                if (isFullImgUrl)
                    services.ForEach(x => x.Images.ForEach(y => y.Url = IMAGE_FULL_URL + y.Url));

                return services;
            }
        }
    }
}
