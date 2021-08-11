using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WatchTowerWebApp.Models;

namespace WatchTowerWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //Connects Models to the database
        public DbSet<Show> Shows { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<CoWatcher> CoWatchers { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
