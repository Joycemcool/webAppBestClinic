using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorldBestClinic.Models;

namespace WorldBestClinic.Data
{
    public class WorldBestClinicContext : DbContext
    {
        public WorldBestClinicContext (DbContextOptions<WorldBestClinicContext> options)
            : base(options)
        {
        }

        public DbSet<WorldBestClinic.Models.Service> Service { get; set; } = default!;
    }
}
