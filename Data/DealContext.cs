using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Phoenix.Models.DealViewModels;

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

        /// <summary> Used to query and save instances of DealUnit. </summary>
        public DbSet<DealUnit> DealUnit { get; set; }
        /// <summary>
        /// Used to query and save instances of AppraisalData. </summary>
        public DbSet<Appraisal> Appraisal {get; set; }

        /// <summary> Used to furthered configure the discovered model. </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Deal>(
                d =>
                {
                    d.HasKey("_id");
                    //d.HasMany(typeof(Unit));
                    d.Property(e => e.AddDateTimeZone)
                     .HasColumnType("decimal(4, 2)");
                    d.Property(e => e.LastUpdateTimeZone)
                     .HasColumnType("decimal(4, 2)");
                    d.Property(e => e.UpdateUserID);
                }
            );
            builder.Entity<Unit>(
                u =>
                {
                    //u.HasKey("ID");
                    //! EF Core doesn't support many-to-many relationships right now!
                    //u.HasMany(typeof(Deal));
                    //u.HasOne(e => e.Deal)
                    // .WithMany(d => d.Units);
                    u.Property(e => e.AddDateTimeZone)
                     .HasColumnType("decimal(4, 2)");
                    u.Property(e => e.LastUpdateTimeZone)
                     .HasColumnType("decimal(4, 2)");
                }
            );  
            builder.Entity<DealUnit>(
                d =>
                {
                    d.HasKey(du => new {du.DealId, du.UnitId});
                }
            );
            builder.Entity<Appraisal>(
                a => 
                {
                    a.HasKey("_id");
                    /* d.Property(e => e.AddDateTimeZone)
                     .HasColumnType("decimal(4, 2)");
                    d.Property(e => e.LastUpdateTimeZone)
                     .HasColumnType("decimal(4, 2)"); */
                }
            );
        }

        public bool UnitExists(int id)
        {
            return Unit.Any(u => u.UnitId == id);
        }

        public bool AppraisalExists(int id)
        {
            return Appraisal.Any(a => a._id == id);
        }
    }
}
