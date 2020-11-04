using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnouncementWebSite.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementWebSite.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        :base(options)
        {
            
        }

        public DbSet<Announcement> Announcements { get; set; }
    }
}
