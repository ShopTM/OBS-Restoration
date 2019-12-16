using DAL.Models;
using OBS_Restoration.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OBS_Restoration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Suppliers()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Careers(ClientType type)
        {
            ViewBag.CareerType = type;
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }


        public JsonResult GetServices()
        {
            var buildingEnvelop = new List<Service>// test data
            {
                new Service
                {
                    Id = 1,
                    Name = "Building envelop restoration",
                    Description = " Including balcony slab repairs",
                    ImgUrl = "../../Content/Images/Services/building-envelop.jpg",
                    Order = 1
                },
           
                new Service
                {
                    Id = 2,
                    Name = "Masonry repairs",
                    Description = "Brick replacement, block, glass block, stone, tuck pointing...",
                    ImgUrl = "../../Content/Images/Services/masonry-repairs.jpg",
                    Order = 2
                },
                new Service
                {
                    Id = 3,
                    Name = "Concrete repairs",
                    Description = " Precast panel, underground garage slab, ramps, columns, canopies, patching...",
                    ImgUrl = "../../Content/Images/Services/concrete-repairs.jpg",
                    Order = 3
                },
                
                 new Service
                {
                    Id = 4,
                    Name = "Caulking, glazing, sealants",
                    Description = " ",
                    ImgUrl = "../../Content/Images/Services/glazing.jpg",
                    Order = 4
                },
                 
                 new Service
                {
                    Id = 5,
                    Name = "Waterproofing",
                    Description = "Cold applied, penetrating sealers, hot robber application",
                    ImgUrl = "../../Content/Images/Services/waterproofing.jpg",
                    Order = 5
                },
                   new Service
                {
                    Id = 6,
                    Name = "Metal railing replacement",
                    Description = " ",
                    ImgUrl = "../../Content/Images/Services/metal-railing.jpg",
                    Order = 6
                },
                   new Service
                {
                    Id = 7,
                    Name = "Wall coating",
                    Description = " ",
                    ImgUrl = "../../Content/Images/Services/wall-coating.jpg",
                    Order = 7
                },
                   new Service
                {
                    Id = 8,
                    Name = "Pressure washing",
                    Description = " ",
                    ImgUrl = "../../Content/Images/Services/washing.jpg",
                    Order = 8
                },
                   new Service
                {
                    Id = 9,
                    Name = "Flashing installation and replacement",
                    Description = " ",
                    ImgUrl = "../../Content/Images/Services/flashing.jpg",
                    Order = 9
                },
                   new Service
                {
                    Id = 10,
                    Name = "Insulation installation",
                    Description = " ",
                    ImgUrl = "../../Content/Images/Services/insulation.jpg",
                    Order = 10
                },
                   new Service
                {
                    Id = 11,
                    Name = "Insulation installation",
                    Description = " ",
                    ImgUrl = "../../Content/Images/Services/metal-siding.jpg",
                    Order = 11
                },




                  };

            return Json(buildingEnvelop, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProjects()
        {
            var projects = new List<Project> // test data
            {
                new Project
                {
                    Id = 1,
                    Name = "Project 1",
                    Description = "Project Description 1",
                    Order = 2,
                    Images = new List<ProjectImage>
                    {
                        new ProjectImage {
                            Id = 1,
                            ProjectId = 1,
                            Ordrer = 1,
                            Url = "Project1_1.png"
                        },
                        new ProjectImage {
                            Id = 2,
                            ProjectId = 1,
                            Ordrer = 3,
                            Url = "Project1_2.png"
                        },
                        new ProjectImage {
                            Id = 3,
                            ProjectId = 2,
                            Ordrer = 1,
                            Url = "Project1_3.png"
                        },
                    }
                },
                new Project
                {
                    Id = 2,
                    Name = "Project 2",
                    Description = "Project Description 2",
                    Order = 1,
                     Images = new List<ProjectImage>
                    {
                        new ProjectImage {
                            Id = 1,
                            ProjectId = 2,
                            Ordrer = 1,
                            Url = "Project2_1.png"
                        },
                        new ProjectImage {
                            Id = 2,
                            ProjectId = 2,
                            Ordrer = 3,
                            Url = "Project2_2.png"
                        },
                        new ProjectImage {
                            Id = 3,
                            ProjectId = 2,
                            Ordrer = 1,
                            Url = "Project2_3.png"
                        },
                    }
                },
                new Project
                {
                    Id = 3,
                    Name = "Project 3",
                    Description = "Project Description 3",
                    Order = 3,
                     Images = new List<ProjectImage>
                    {
                        new ProjectImage {
                            Id = 1,
                            ProjectId = 3,
                            Ordrer = 1,
                            Url = "Project3_1.png"
                        },
                        new ProjectImage {
                            Id = 2,
                            ProjectId = 3,
                            Ordrer = 3,
                            Url = "Project3_2.png"
                        },
                        new ProjectImage {
                            Id = 3,
                            ProjectId = 3,
                            Ordrer = 1,
                            Url = "Project3_3.png"
                        },
                    }
                }
            };
            return Json(projects, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ContactUs(ContactFormVM model)
        {
            if (ModelState.IsValid)
            {
                return Json("Message was send successfuly", JsonRequestBehavior.AllowGet);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}