using Phoenix.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Data
{
    /// <summary> Initialized the database if needed. </summary>
    public class DbInitializer
    {
        /// <summary> Initializes the DB Context. </summary>
        /// <param name="context"> The DB Context to initialize. </param>
        public static void InitializeContext(DealContext context)
        {
            context.Database.EnsureCreated(); //* Use during development, then get rid of this in favor of Migrations

            if (context.Deal.Any())
            {
                return;   // DB has been seeded
            }

            var units = new Unit[]
            {
                new Unit{ModelYear=1999,VIN="1M3P272K1XM001040"}
            };
            var deals = new Deal[]
            {
                new Deal{}
            };
            foreach (var deal in deals) deal.UpdateAuditFields(1);
            foreach (var unit in units) unit.UpdateAuditFields(1);
            var dealUnits = new DealUnit[]
            {
                new DealUnit{Deal = deals[0], Unit = units[0]}
            };
            //deals[0].DealUnits = dealUnits;
            
            context.Unit.AddRange(units);
            context.Deal.AddRange(deals);
            context.DealUnit.AddRange(dealUnits);

            context.SaveChanges();
        }
    }
}