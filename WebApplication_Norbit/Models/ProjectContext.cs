using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Norbit.Models
{
    public class ProjectContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
