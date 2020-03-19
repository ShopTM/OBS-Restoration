using Models;
using Models.Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DbContext context)
        {
            SeedRoles(context);
            //SeedServices(context);
            //SeedProjects(context);
        }
        private static void SeedRoles(DbContext context)
        {
            if (!context.Roles.Any(x => x.Name == UserType.Admin.ToString()))
            {
                context.Roles.AddOrUpdate(new Role { Name = UserType.Admin.ToString() });
            }
            if (!context.Roles.Any(x => x.Name == UserType.LevelI.ToString()))
            {
                context.Roles.AddOrUpdate(new Role { Name = UserType.LevelI.ToString() });
            }
            if (!context.Roles.Any(x => x.Name == UserType.LevelII.ToString()))
            {
                context.Roles.AddOrUpdate(new Role { Name = UserType.LevelII.ToString() });
            }
            if (!context.Roles.Any(x => x.Name == UserType.LevelIII.ToString()))
            {
                context.Roles.AddOrUpdate(new Role { Name = UserType.LevelIII.ToString() });
            }
            context.SaveChanges();
        }
        private static void SeedServices(DbContext context)
        {
            var services = new List<Service>// test data
            {
                new Service
                {
                    Id = 1,
                    Name = "Building envelop restoration",
                    Description = " Including balcony slab repairs",
                    ImgUrl = "building-envelop.jpg",
                    Order = 1
                },

                new Service
                {
                    Id = 2,
                    Name = "Masonry repairs",
                    Description = "Brick replacement, block, glass block, stone, tuck pointing...",
                    ImgUrl = "masonry-repairs.jpg",
                    Order = 2
                },
                new Service
                {
                    Id = 3,
                    Name = "Concrete repairs",
                    Description = " Precast panel, underground garage slab, ramps, columns, canopies, patching...",
                    ImgUrl = "concrete-repairs.jpg",
                    Order = 3
                },

                 new Service
                {
                    Id = 4,
                    Name = "Caulking, glazing, sealants",
                    Description = " ",
                    ImgUrl = "glazing.jpg",
                    Order = 4
                },

                 new Service
                {
                    Id = 5,
                    Name = "Waterproofing",
                    Description = "Cold applied, penetrating sealers, hot robber application",
                    ImgUrl = "waterproofing.jpg",
                    Order = 5
                },
                   new Service
                {
                    Id = 6,
                    Name = "Metal railing replacement",
                    Description = " ",
                    ImgUrl = "metal-railing.jpg",
                    Order = 6
                },
                   new Service
                {
                    Id = 7,
                    Name = "Wall coating",
                    Description = " ",
                    ImgUrl = "wall-coating.jpg",
                    Order = 7
                },
                   new Service
                {
                    Id = 8,
                    Name = "Pressure washing",
                    Description = " ",
                    ImgUrl = "washing.jpg",
                    Order = 8
                },
                   new Service
                {
                    Id = 9,
                    Name = "Flashing installation and replacement",
                    Description = " ",
                    ImgUrl = "flashing.jpg",
                    Order = 9
                },
                   new Service
                {
                    Id = 10,
                    Name = "Insulation installation",
                    Description = " ",
                    ImgUrl = "insulation.jpg",
                    Order = 10
                },
                   new Service
                {
                    Id = 11,
                    Name = " Metal siding installation",
                    Description = " ",
                    ImgUrl = "metal-siding.jpg",
                    Order = 11
                }
            };
            foreach (var service in services)
            {
                context.Set<Service>().AddOrUpdate(service);
            }
        }
        private static void SeedProjects(DbContext context)
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
                            ProjectId = 1,
                            Ordrer = 1,
                            Url = "StClair_0.jpg",
                        },
                        new ProjectImage {
                            ProjectId = 2,
                            Ordrer = 2,
                            Url = "StClair_1.jpg",
                        },
                        new ProjectImage {
                            ProjectId = 3,
                            Ordrer = 3,
                            Url = "StClair_2.jpg",
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
                            Id = 4,
                            ProjectId = 2,
                            Ordrer = 1,
                            Url = "Darcle_0.jpg",
                        },
                        new ProjectImage {
                            Id = 5,
                            ProjectId = 2,
                            Ordrer = 2,
                            Url = "Darcle_1.jpg",
                        },
                        new ProjectImage {
                            Id = 6,
                            ProjectId = 2,
                            Ordrer = 3,
                            Url = "Darcle_2.jpg",
                        },
                        new ProjectImage {
                            Id = 7,
                            ProjectId = 2,
                            Ordrer = 4,
                            Url = "Darcle_3.jpg",
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
                            Id = 8,
                            ProjectId = 3,
                            Ordrer = 1,
                            Url = "RoeHampton_0.jpg",
                        },
                        new ProjectImage {
                            Id = 9,
                            ProjectId = 3,
                            Ordrer = 2,
                            Url = "RoeHampton_1.jpg",
                        },
                        new ProjectImage {
                            Id = 10,
                            ProjectId = 3,
                            Ordrer = 3,
                            Url = "RoeHampton_2.jpg",
                        },
                         new ProjectImage {
                            Id = 11,
                            ProjectId = 3,
                            Ordrer = 4,
                            Url = "RoeHampton_3.jpg",
                        },
                         new ProjectImage {
                            Id = 12,
                            ProjectId = 3,
                            Ordrer = 5,
                            Url = "RoeHampton_4.jpg",
                        },
                         new ProjectImage {
                            Id = 13,
                            ProjectId = 3,
                            Ordrer = 6,
                            Url = "RoeHampton_5.jpg",
                        },
                         new ProjectImage {
                            Id = 14,
                            ProjectId = 3,
                            Ordrer = 7,
                            Url = "RoeHampton_6.jpg",
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
                            Id = 15,
                            ProjectId = 4,
                            Ordrer = 1,
                            Url = "Cambridge_0.jpg",
                        },
                        new ProjectImage {
                            Id = 16,
                            ProjectId = 4,
                            Ordrer = 2,
                            Url = "Cambridge_1.jpg",
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
                            Id = 17,
                            ProjectId = 5,
                            Ordrer = 1,
                            Url = "StCatherine_0.jpg",
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
                            Id = 18,
                            ProjectId = 6,
                            Ordrer = 1,
                            Url = "fowler_0.jpg",
                        },
                          new ProjectImage {
                            Id = 19,
                            ProjectId = 6,
                            Ordrer = 2,
                            Url = "fowler_1.jpg",
                        },
                          new ProjectImage {
                            Id = 20,
                            ProjectId = 6,
                            Ordrer = 3,
                            Url = "fowler_2.jpg",
                        },
                           new ProjectImage {
                            Id = 21,
                            ProjectId = 6,
                            Ordrer = 4,
                            Url = "fowler_3.jpg",
                        },
                           new ProjectImage {
                            Id = 22,
                            ProjectId = 6,
                            Ordrer = 5,
                            Url = "fowler_4.jpg",
                        },
                           new ProjectImage {
                            Id = 23,
                            ProjectId = 6,
                            Ordrer = 6,
                            Url = "fowler_5.jpg",
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
                            Id = 24,
                            ProjectId = 7,
                            Ordrer = 1,
                            Url = "kannedy_0.jpg",
                        },
                        new ProjectImage {
                            Id = 25,
                            ProjectId = 7,
                            Ordrer = 2,
                            Url = "kannedy_1.jpg",
                        },
                        new ProjectImage {
                            Id = 26,
                            ProjectId = 7,
                            Ordrer = 3,
                            Url = "kannedy_2.jpg",
                        },
                        new ProjectImage {
                            Id = 27,
                            ProjectId = 7,
                            Ordrer = 4,
                            Url = "kannedy_3.jpg",
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
                            Id = 28,
                            ProjectId = 8,
                            Ordrer = 1,
                            Url = "walmer_0.jpg",
                        },
                         new ProjectImage {
                            Id = 29,
                            ProjectId = 8,
                            Ordrer = 2,
                            Url = "walmer_1.jpg",
                        },
                         new ProjectImage {
                            Id = 30,
                            ProjectId = 8,
                            Ordrer = 3,
                            Url = "walmer_2.jpg",
                        },
                         new ProjectImage {
                            Id = 31,
                            ProjectId = 8,
                            Ordrer = 4,
                            Url = "walmer_3.jpg",
                        },
                         new ProjectImage {
                            Id = 32,
                            ProjectId = 8,
                            Ordrer = 5,
                            Url = "walmer_4.jpg",
                        },
                     }
                    }
            };
            foreach (var project in projects)
            {
                context.Set<Project>().AddOrUpdate(project);
            }
        }
    }
}
