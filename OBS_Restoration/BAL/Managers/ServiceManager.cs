using BAL.Helpers;
using DAL;
using ImageResizer;
using Models.Entities;
using Models.VM.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BAL.Managers
{
    public class ServiceManager
    {
        private readonly string IMAGE_FULL_URL = "/Content/Images/Services/";

        public List<Service> All(bool isFullImgUrl = false)
        {
            using (var db = DbFactory.GetNotTrackingInstance())
            {
                var services = db.ServiceRepository.All().ToList();
                if (isFullImgUrl)
                    services.ForEach(x => x.ImgUrl = IMAGE_FULL_URL + x.ImgUrl);
                return services;
            }
        }
        public Service GetService(int id)
        {
            using (var db = DbFactory.GetNotTrackingInstance())
            {
                var serv = db.ServiceRepository.Get(id);
                serv.ImgUrl = IMAGE_FULL_URL + serv.ImgUrl;
                return serv;
            }
        }
        public void UpdateService(ServiceVM source)
        {
            source.ImgUrl = ImageSaveHelper.SaveImage(source.Image, IMAGE_FULL_URL);
            using (var db = DbFactory.GetNotTrackingInstance())
            {
                if (source.Id == 0)
                {
                    source.Order = db.ServiceRepository.Count(x => true) + 1;
                    db.ServiceRepository.Add(source.ToEntity());
                }
                else
                    db.ServiceRepository.Update(source.ToEntity());
                db.Save();
            }
        }
        public void DeleteService(int id)
        {
            using (var db = DbFactory.GetNotTrackingInstance())
            {
                DeleteService(db, id);
                db.Save();
            }
        }
        public void DeleteBatchServices(int[] ids)
        {
            using (var db = DbFactory.GetNotTrackingInstance())
            {
                foreach (var id in ids)
                {
                    DeleteService(db, id);
                }
                db.Save();
            }
        }
        private void DeleteService(IUnitOfWork db, int id)
        {
            var service = db.ServiceRepository.Get(id);
            File.Delete(HttpContext.Current.Server.MapPath(IMAGE_FULL_URL) + service.ImgUrl);
            db.ServiceRepository.Remove(service);
        }
    }
}
