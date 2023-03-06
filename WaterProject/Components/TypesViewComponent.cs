using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;

namespace WaterProject.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IWaterProjectRepository repo { get; set; }

        public TypesViewComponent( IWaterProjectRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["projectType"];
            // The list that we are builing here will come into
            // the "Default" component view as an IEnumerable.
            // We use var here, which allows ASP to detect that down the 
            // road it will be an IEnnumerable.
            var types = repo.Projects
                .Select(x => x.ProjectType)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
