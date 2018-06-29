using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Phoenix.Models
{
    /// <summary> Represents the database session backing Phoenix. </summary>
    public class DealContext : DbContext
    {
        /// <summary> The constructor for DealContext. </summary>
        /// <param name="options"> DealContext options. </param>
        public DealContext (DbContextOptions<DealContext> options)
            : base(options)
        {
        }

        /// <summary> Used to query and save instances of Deal. </summary>
        public DbSet<Deal> Deal { get; set; }

        /// <summary> Used to query and save instances of Unit. </summary>
        public DbSet<Unit> Unit { get; set; }
    }
}
