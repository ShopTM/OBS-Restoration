using BAL.Helpers;
using DAL;
using Models.Entities;
using Models.VM.Project;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace BAL.Managers
{
    public class ProjectManager
    {
        private const string IMAGE_FULL_URL = "/Content/Images/Projects/";
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
        public void UpdateProject(ProjectVM source)
        {
            using (var db = DbFactory.GetNotTrackingInstance())
            {
                var entityProject = source.ToEntity();
                foreach (var img in source.Images)
                {
                    var projectImageEntity = img.ToEntity();
                    projectImageEntity.Url = ImageSaveHelper.SaveImage(img.Image, IMAGE_FULL_URL);
                    entityProject.Images.Add(projectImageEntity);
                }
                if (entityProject.Id == 0)
                    db.ProjectRepository.Add(entityProject);
                else
                    db.ProjectRepository.Update(entityProject);
                db.Save();
            }
        }
        public void DeleteProject(int projectId)
        {
            using (var db = DbFactory.GetNotTrackingInstance())
            {
                DeleteProject(db, projectId);
            }
        }
        public void DeleteBatchProjects(int[] ids)
        {
            using (var db = DbFactory.GetNotTrackingInstance())
            {
                foreach (var id in ids)
                {
                    DeleteProject(db, id);
                }
                db.Save();
            }
        }
        private void DeleteProject(IUnitOfWork db, int id)
        {
            var project = db.ProjectRepository.Get(id);
            foreach (var img in project.Images)
            {
                File.Delete(IMAGE_FULL_URL + img.Url);
                db.ProjectImageRepository.Remove(img);
                db.Save();
            }
            db.ProjectRepository.Remove(project);
            db.Save();
        }
    }
}
