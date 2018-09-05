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
                    d.HasKey("Id");
                    //d.HasMany(typeof(Unit));
                    d.Property(e => e.ControlBranch)
                    .HasColumnType("nvarchar(max)");
                    d.Property(e => e.DateOfSubmission)
                     .HasColumnType("datetime");
                    d.Property(e => e.CustomerName)
                    .HasColumnType("nvarchar(255");
                    d.Property(e => e.AddDateTimeZone)
                     .HasColumnType("decimal(4, 2)");
                    d.Property(e => e.LastUpdateTimeZone)
                     .HasColumnType("decimal(4, 2)");
                    d.Property(e => e.UpdateUserID);
                    d.HasMany(e => e.Appraisals)
                     .WithOne(e => e.Deal);
                }
            );
            builder.Entity<Unit>(
                u =>
                {
                    u.HasKey(e => e.UnitId);
                    u.Property(e => e.Make)
                    .HasColumnType("nvarchar(125)");
                    u.Property(e => e.Model)
                    .HasColumnType("nvarchar(125)");
                    u.Property(e => e.ModelYear)
                    .HasColumnType("int");
                    u.Property(e => e.VIN)
                    .HasColumnType("nvarchar(max)");
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
                    a.HasKey("Id");
                    a.HasOne(e => e.Deal)
                    .WithMany(e => e.Appraisals);
                    a.HasOne(e => e.Unit);
                    a.Property(e => e.AppraisedBy)
                    .HasColumnType("nvarchar(125)");
                    /* d.Property(e => e.AddDateTimeZone))
                     .HasColumnType("decimal(4, 2)");
                    d.Property(e => e.LastUpdateTimeZone)
                     .HasColumnType("decimal(4, 2)"); */
                }
            );

            builder.Entity<AppraisalCharacteristicValue>(
                a => 
                {
                    a.HasKey("AppraisalCharacteristicValueId");
                    a.HasOne(e => e.Appraisal)
                    .WithMany(e => e.Values);
                    a.Property(e => e.CharacteristicName)
                    .HasColumnType("nvarchar(50)");
                    a.Property(e => e.IntValue)
                    .HasColumnType("int");
                    a.Property(e => e.StringValue)
                    .HasColumnType("nvarchar(max)");
                    a.Ignore(e => e.AppraisalCharacteristicId);
                }
            );
        }

        public bool UnitExists(int id)
        {
            return Unit.Any(u => u.UnitId == id);
        }

        public bool DealExists(int id)
        {
            return true;//Deal.Any(d => d._id == id);
        }

        public bool AppraisalExists(int id)
        {
            return true;//Appraisal.Any(a => a._id == id);
        }
    }
}
