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
                var target = db.ProjectRepository.Get(x => x.Id == source.Id, "Images");
                if (target == null) //Create new Project
                {
                    var entityProject = source.ToEntity();
                    foreach (var img in source.Images)
                    {
                        entityProject.Images.Add(new ProjectImage
                        {
                            Url = ImageHelper.SaveImage(img.Image, IMAGE_FULL_URL)
                        });
                    }
                    db.ProjectRepository.Add(entityProject);
                }
                else  //Update old Project
                {
                    target.Name = source.Name;
                    target.Description = source.Description;
                    foreach (var sourceImg in source.Images)
                    {
                        var dbImage = db.ProjectImageRepository.Get(sourceImg.Id);
                        if (dbImage == null)
                        {
                            //create new image
                            db.ProjectImageRepository.Add(new ProjectImage
                            {
                                ProjectId = target.Id,
                                Url = ImageHelper.SaveImage(sourceImg.Image, IMAGE_FULL_URL)
                            });
                        }
                    }
                    //delete images
                    foreach (var targetImage in target.Images)
                    {
                        if (!source.Images.Any(x => x.Id == targetImage.Id))
                        {
                            ImageHelper.DeleteImage(targetImage.Url, IMAGE_FULL_URL);
                        }
                    }
                    db.ProjectImageRepository.RemoveRange(target.Images.Where(x => source.Images.All(y => y.Id != x.Id)));
                    db.ProjectRepository.Update(target);
                }

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
            var project = db.ProjectRepository.Get(x => x.Id == id, "Images");
            foreach (var img in project.Images)
            {
                ImageHelper.DeleteImage(img.Url, IMAGE_FULL_URL);
            }
            db.ProjectImageRepository.RemoveRange(project.Images);
            db.ProjectRepository.Remove(project);
            db.Save();
        }
    }
}
