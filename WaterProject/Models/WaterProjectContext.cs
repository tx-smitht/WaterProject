﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WaterProject.Models
{
    public class WaterProjectContext : DbContext
    {
        public WaterProjectContext()
        {
        }

        public WaterProjectContext(DbContextOptions<WaterProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        // this is the file that coordinates the connection to the database, 
        // this is what tells migrations what to include. 
        public DbSet<Donation> Donations { get; set; }
    }
}
