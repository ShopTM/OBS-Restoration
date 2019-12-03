﻿using DAL.Models;
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


        public JsonResult GetServices()
        {
            var services = new List<Service>// test data
            {
                new Service
                {
                    Id = 1,
                    Name = "Service 1",
                    Description = "Service Description 1",
                    ImgUrl = "Service1.png",
                    Order = 2
                },
                new Service
                {
                    Id = 2,
                    Name = "Service 2",
                    Description = "Service Description 2",
                    ImgUrl = "Service2.png",
                    Order = 1
                },
                new Service
                {
                    Id = 3,
                    Name = "Service 3",
                    Description = "Service Description 3",
                    ImgUrl = "Service3.png",
                    Order = 3
                }
            };
            return Json(services, JsonRequestBehavior.AllowGet);
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
        public ActionResult ContactUs(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                return Json("Message was send successfuly", JsonRequestBehavior.AllowGet);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}