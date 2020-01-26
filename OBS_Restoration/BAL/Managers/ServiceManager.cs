using DAL;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BAL.Managers
{
    public class ServiceManager
    {
        private const string IMAGE_FULL_URL = "../../Content/Images/Services/";
        public List<Service> All(bool isFullImgUrl = false)
        {
            using (var db = DbFactory.GetNotTrackingInstance())
            {
                var services = db.ServiceRepository.All().ToList();
                if(isFullImgUrl)
                    services.ForEach(x => x.ImgUrl = IMAGE_FULL_URL + x.ImgUrl);
                return services;
            }
        }
    }
}
