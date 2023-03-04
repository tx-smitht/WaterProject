using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;
using WaterProject.Models.ViewModels;

namespace WaterProject.Controllers
{
    public class HomeController : Controller
    {
        private IWaterProjectRepository repo;

        public HomeController (IWaterProjectRepository temp) => repo = temp;

        public IActionResult Index(int page_num = 1)
        {
            int results_per_page = 5;

            var x = new ProjectsViewModel
            {
                Projects = repo.Projects
                .OrderBy(p => p.ProjectName)
                .Skip((page_num - 1) * results_per_page)
                .Take(results_per_page),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = repo.Projects.Count(),
                    ProjectsPerPage = results_per_page,
                    CurrentPage = page_num
                }
            };

            return View(x);
        }
    }
}
