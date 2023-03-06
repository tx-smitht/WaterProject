using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumProjects { get; set; }
        public int ProjectsPerPage { get; set; }
        public int CurrentPage { get; set; }
       
        // Tells us how many pages we need
        // Need to cast one of these numbers as a double so that result is an int. Ceiling so it has enough
        public int TotalPages => (int) Math.Ceiling((double) TotalNumProjects / ProjectsPerPage);
    }
}
