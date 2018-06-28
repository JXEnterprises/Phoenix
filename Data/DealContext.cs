using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Phoenix.Models
{
    public class DealContext : DbContext
    {
        public DealContext (DbContextOptions<DealContext> options)
            : base(options)
        {
        }

        public DbSet<Phoenix.Models.Unit> Unit { get; set; }
    }
}
