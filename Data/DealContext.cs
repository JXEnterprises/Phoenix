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

        /// <summary> Used to furthered configure the discovered model. </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Deal>(
                d =>
                {
                    d.HasKey("_id");
                    d.HasMany(typeof(Unit));
                    d.Property(e => e.AddDate)
                     .HasDefaultValue(DateTime.UtcNow)
                     .ValueGeneratedOnAdd();
                    d.Property(e => e.AddDateTimeZone)
                     .HasColumnType("decimal(4, 2)")
                     .HasDefaultValue((decimal)DateTimeOffset.Now.Hour) //! [AddDate] datetime2 NOT NULL DEFAULT '2018-07-03T20:03:50.7636865Z',
                     .ValueGeneratedOnAdd();
                    //TODO: tie AddUserID to auth
                    d.Property(e => e.AddUserID)
                     .HasDefaultValue(1)
                     .ValueGeneratedOnAdd();
                    d.Property(e => e.UpdateDate)
                     .HasDefaultValue(DateTime.UtcNow)
                     .ValueGeneratedOnAddOrUpdate();
                    d.Property(e => e.LastUpdateTimeZone)
                     .HasColumnType("decimal(4, 2)")
                     .HasDefaultValue((decimal)DateTimeOffset.Now.Hour)
                     .ValueGeneratedOnAddOrUpdate();
                    //TODO: tie UpdateUserID to auth
                    d.Property(e => e.UpdateUserID)
                        .HasDefaultValue(1)
                        .ValueGeneratedOnAddOrUpdate();
                }
            );
            builder.Entity<Unit>(
                u =>
                {
                    u.HasKey("ID");
                    //! EF Core doesn't support many-to-many relationships right now!
                    //u.HasMany(typeof(Deal));
                    u.HasOne(e => e.Deal)
                     .WithMany(d => d.Units);
                    u.Property(e => e.AddDate)
                     .HasDefaultValue(DateTime.UtcNow)
                     .ValueGeneratedOnAdd();
                    u.Property(e => e.AddDateTimeZone)
                     .HasColumnType("decimal(4, 2)")
                     .HasDefaultValue((decimal)DateTimeOffset.Now.Hour)
                     .ValueGeneratedOnAdd();
                    //TODO: tie AddUserID to auth
                    u.Property(e => e.AddUserID)
                     .HasDefaultValue(1)
                     .ValueGeneratedOnAdd();
                    u.Property(e => e.UpdateDate)
                     .HasDefaultValue(DateTime.UtcNow)
                     .ValueGeneratedOnAddOrUpdate();
                    u.Property(e => e.LastUpdateTimeZone)
                     .HasColumnType("decimal(4, 2)")
                     .HasDefaultValue((decimal)DateTimeOffset.Now.Hour)
                     .ValueGeneratedOnAddOrUpdate();
                    //TODO: tie UpdateUserID to auth
                    u.Property(e => e.UpdateUserID)
                     .HasDefaultValue(1)
                     .ValueGeneratedOnAddOrUpdate();
                }
            );  
        }
    }
}
