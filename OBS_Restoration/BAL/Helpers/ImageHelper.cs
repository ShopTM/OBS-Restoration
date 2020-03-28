using ImageResizer;
using System;
using System.IO;
using System.Web;

namespace BAL.Helpers
{
    public static class ImageHelper
    {
        public static string SaveImage(HttpPostedFileBase image, string imgPath)
        {
            if (image == null) return default;
            var imgName = DateTime.UtcNow.Ticks.ToString() + "_" + image.FileName;
            var fullPathImage = HttpContext.Current.Server.MapPath(imgPath) + imgName;
            image.SaveAs(fullPathImage);

            var imgJob = new ImageJob(fullPathImage, fullPathImage, new Instructions
            {
                Mode = FitMode.Max,
                Width = 600,
                Height = 600
            });
            ImageBuilder.Current.Build(imgJob);
            return imgName;
        }
        public static void DeleteImage(string imgName, string imgPath)
        {
            File.Delete(HttpContext.Current.Server.MapPath(imgPath) + imgName);
        }
    }
}
