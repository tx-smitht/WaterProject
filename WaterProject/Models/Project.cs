using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WaterProject.Models
{
    public partial class Project
    {
        [Key]
        [Required]
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public string ProjectRegionalProgram { get; set; }
        public int ProjectImpact { get; set; } // ? means that it can be null. Typically we don't like
        public string ProjectPhase { get; set; }
        public string ProjectFunctionalityStatus { get; set; }
    }
}
