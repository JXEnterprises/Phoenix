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

            var utcNow = DateTime.UtcNow;
            var offset = DateTimeOffset.Now.Hour;
            
            var units = new Unit[]
            {
                new Unit{CustomerName="Test, Bob",AppraiserName="Appraiser, Jim",CustomerAddress="100 Pigkicker Ln",ModelYear=1999,VIN="1M3P272K1XM001040"}
            };
            var deals = new Deal[]
            {
                new Deal{}
            };
            //units[0].Deals.Add(deals[0]);
            units[0].Deal = deals[0];
            deals[0].Units = new List<Unit>();
            deals[0].Units.Add(units[0]);
            
            context.Deal.AddRange(deals);
            context.Unit.AddRange(units);

            context.SaveChanges();
        }
    }
}