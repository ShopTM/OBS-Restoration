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

        public ActionResult Careers()
        {
            
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }
        public ActionResult Clints(ClientType type)
        {
            ViewBag.ClientType = type;
            return View();
        }
        public ActionResult Gallery()
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
                    Name = "St. Chair",
                    Description = "",
                    Order = 1,
                    Images = new List<ProjectImage>
                    {
                        new ProjectImage {
                            Id = 1,
                            ProjectId = 1,
                            Ordrer = 1,
                            Url = "../../Content/Images/Projects/StClair_0.jpg",
                        },
                        new ProjectImage {
                            Id = 1,
                            ProjectId = 1,
                            Ordrer = 2,
                            Url = "../../Content/Images/Projects/StClair_1.jpg",
                        },
                        new ProjectImage {
                            Id = 1,
                            ProjectId = 1,
                            Ordrer = 3,
                            Url = "../../Content/Images/Projects/StClair_2.jpg",
                        },
                    }
                },
                new Project
                {
                    Id = 2,
                    Name = "Darcel",
                    Description = "",
                    Order = 2,
                     Images = new List<ProjectImage>
                    {
                        new ProjectImage {
                            Id = 1,
                            ProjectId = 2,
                            Ordrer = 1,
                            Url = "../../Content/Images/Projects/Darcle_0.jpg",
                        },
                        new ProjectImage {
                            Id = 2,
                            ProjectId = 2,
                            Ordrer = 2,
                            Url = "../../Content/Images/Projects/Darcle_1.jpg",
                        },
                        new ProjectImage {
                            Id = 3,
                            ProjectId = 2,
                            Ordrer = 3,
                            Url = "../../Content/Images/Projects/Darcle_2.jpg",
                        },
                        new ProjectImage {
                            Id = 4,
                            ProjectId = 2,
                            Ordrer = 4,
                            Url = "../../Content/Images/Projects/Darcle_3.jpg",
                        },
                    }
                },
                new Project
                {
                    Id = 3,
                    Name = "Roe hampton",
                    Description = "",
                    Order = 3,
                     Images = new List<ProjectImage>
                    {
                        new ProjectImage {
                            Id = 1,
                            ProjectId = 3,
                            Ordrer = 1,
                            Url = "../../Content/Images/Projects/RoeHampton_0.jpg",
                        },
                        new ProjectImage {
                            Id = 2,
                            ProjectId = 3,
                            Ordrer = 2,
                            Url = "../../Content/Images/Projects/RoeHampton_1.jpg",
                        },
                        new ProjectImage {
                            Id = 3,
                            ProjectId = 3,
                            Ordrer = 3,
                            Url = "../../Content/Images/Projects/RoeHampton_2.jpg",
                        },
                         new ProjectImage {
                            Id = 4,
                            ProjectId = 3,
                            Ordrer = 4,
                            Url = "../../Content/Images/Projects/RoeHampton_3.jpg",
                        },
                         new ProjectImage {
                            Id = 5,
                            ProjectId = 3,
                            Ordrer = 5,
                            Url = "../../Content/Images/Projects/RoeHampton_4.jpg",
                        },
                         new ProjectImage {
                            Id = 6,
                            ProjectId = 3,
                            Ordrer = 6,
                            Url = "../../Content/Images/Projects/RoeHampton_5.jpg",
                        },
                         new ProjectImage {
                            Id = 7,
                            ProjectId = 3,
                            Ordrer = 7,
                            Url = "../../Content/Images/Projects/RoeHampton_6.jpg",
                        },
                    }

                },

                 new Project
                {
                    Id = 4,
                    Name = "Cambridge",
                    Description = "",
                    Order = 4,
                     Images = new List<ProjectImage>
                    {
                        new ProjectImage {
                            Id = 1,
                            ProjectId = 4,
                            Ordrer = 1,
                            Url = "../../Content/Images/Projects/Cambridge_0.jpg",
                        },
                        new ProjectImage {
                            Id = 2,
                            ProjectId = 4,
                            Ordrer = 2,
                            Url = "../../Content/Images/Projects/Cambridge_1.jpg",
                        },
                       
                    }

                },
                     new Project
                {
                    Id = 5,
                    Name = "St. Catherine",
                    Description = "",
                    Order = 5,
                     Images = new List<ProjectImage>
                    {
                        new ProjectImage {
                            Id = 1,
                            ProjectId = 5,
                            Ordrer = 1,
                            Url = "../../Content/Images/Projects/StCatherine_0.jpg",
                        },
                     
                    }

                },

                    new Project
                {
                    Id = 6,
                    Name = "Fowler",
                    Description = "",
                    Order = 6,
                     Images = new List<ProjectImage>
                    {
                        new ProjectImage {
                            Id = 1,
                            ProjectId = 6,
                            Ordrer = 1,
                            Url = "../../Content/Images/Projects/fowler_0.jpg",
                        },
                          new ProjectImage {
                            Id = 2,
                            ProjectId = 5,
                            Ordrer = 2,
                            Url = "../../Content/Images/Projects/fowler_1.jpg",
                        },
                          new ProjectImage {
                            Id = 3,
                            ProjectId = 6,
                            Ordrer = 3,
                            Url = "../../Content/Images/Projects/fowler_2.jpg",
                        },
                           new ProjectImage {
                            Id = 3,
                            ProjectId = 6,
                            Ordrer = 4,
                            Url = "../../Content/Images/Projects/fowler_3.jpg",
                        },
                           new ProjectImage {
                            Id = 3,
                            ProjectId = 6,
                            Ordrer = 5,
                            Url = "../../Content/Images/Projects/fowler_4.jpg",
                        },
                           new ProjectImage {
                            Id = 3,
                            ProjectId = 6,
                            Ordrer = 6,
                            Url = "../../Content/Images/Projects/fowler_5.jpg",
                        },

                    }

                },
                    new Project
                {
                    Id = 7,
                    Name = "Kennedy",
                    Description = "",
                    Order = 7,
                     Images = new List<ProjectImage>
                    {
                        new ProjectImage {
                            Id = 1,
                            ProjectId = 7,
                            Ordrer = 1,
                            Url = "../../Content/Images/Projects/kannedy_0.jpg",
                        },
                        new ProjectImage {
                            Id = 2,
                            ProjectId = 7,
                            Ordrer = 2,
                            Url = "../../Content/Images/Projects/kannedy_1.jpg",
                        },
                        new ProjectImage {
                            Id = 3,
                            ProjectId = 7,
                            Ordrer = 3,
                            Url = "../../Content/Images/Projects/kannedy_2.jpg",
                        },
                        new ProjectImage {
                            Id = 4,
                            ProjectId = 7,
                            Ordrer = 4,
                            Url = "../../Content/Images/Projects/kannedy_3.jpg",
                        },
                     }
                    },
                    new Project
                {
                    Id = 8,
                    Name = "Walmer",
                    Description = "",
                    Order = 8,
                     Images = new List<ProjectImage>
                    {
                        new ProjectImage {
                            Id = 1,
                            ProjectId = 8,
                            Ordrer = 1,
                            Url = "../../Content/Images/Projects/walmer_0.jpg",
                        },
                         new ProjectImage {
                            Id = 2,
                            ProjectId = 5,
                            Ordrer = 2,
                            Url = "../../Content/Images/Projects/walmer_1.jpg",
                        },
                         new ProjectImage {
                            Id = 3,
                            ProjectId = 8,
                            Ordrer = 3,
                            Url = "../../Content/Images/Projects/walmer_2.jpg",
                        },
                         new ProjectImage {
                            Id = 4,
                            ProjectId = 8,
                            Ordrer = 4,
                            Url = "../../Content/Images/Projects/walmer_3.jpg",
                        },
                         new ProjectImage {
                            Id = 5,
                            ProjectId = 8,
                            Ordrer = 5,
                            Url = "../../Content/Images/Projects/walmer_4.jpg",
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