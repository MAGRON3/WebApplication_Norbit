using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Norbit.Models
{
    public class WiringContext : DbContext
    {
        public DbSet<Wiring> Wirings { get; set; }
        public WiringContext(DbContextOptions<WiringContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
