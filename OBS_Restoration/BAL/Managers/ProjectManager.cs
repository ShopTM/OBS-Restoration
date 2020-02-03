using DAL;
using Models.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace BAL.Managers
{
    public class ProjectManager
    {
        private const string IMAGE_FULL_URL = "../../Content/Images/Projects/";
        public List<Project> All(bool isFullImgUrl = false)
        {
            using (var db = DbFactory.GetNotTrackingInstance())
            {
                var projects = db.ProjectRepository.All().Include(x => x.Images).ToList();
                if (isFullImgUrl)
                    projects.ForEach(x => x.Images.ForEach(y => y.Url = IMAGE_FULL_URL + y.Url));

                return projects;
            }
        }
        public Project GetProject(int id)
        {
            using (var db = DbFactory.GetNotTrackingInstance())
            {
                var proj = db.ProjectRepository.Get(id);
                proj.Images.ForEach(y => y.Url = IMAGE_FULL_URL + y.Url);
                return proj;
            }
        }
        public void UpdateProject(Project source)
        {
            using (var db = DbFactory.GetNotTrackingInstance())
            {
                db.ProjectRepository.Update(source);
            }
        }
        public void UploadProjectImage(int id, int order, HttpPostedFileBase img)
        {
            using (var db = DbFactory.GetInstance())
            {
                db.ProjectImageRepository.Add(new ProjectImage
                {
                    ProjectId = id,
                    Url = img.FileName,
                    Ordrer = order
                });
                img.SaveAs(IMAGE_FULL_URL + img.FileName);
                db.Save();
            }
        }
        public void DeleteProjectImage(int id)
        {
            using (var db = DbFactory.GetNotTrackingInstance())
            {
                var img = db.ProjectImageRepository.Get(id);
                File.Delete(IMAGE_FULL_URL + img.Url);
                //todo: update order
                db.ProjectImageRepository.Remove(img);
                db.Save();
            }
        }
    }
}
