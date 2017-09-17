using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Helpers
{
    public class SeedEntities : IDatabaseInitializer<drogowskazEntities>
    {
        public void InitializeDatabase(drogowskazEntities context)
        {
            Cycle cycle1 = context.Cycles.FirstOrDefault(c => c.Name == "(żaden)");
            if (cycle1 == null) {
                cycle1 = new Cycle()
                {
                    Name = "(żaden)"
                };
                context.Cycles.Add(cycle1);
                context.SaveChanges();
            }

            foreach (string name in CyclesUtilitiess.names) {
                Cycle cycle = context.Cycles.FirstOrDefault(c => c.Name == name);
                if (cycle == null)
                {
                    cycle = new Cycle()
                    {
                        Name = name
                    };
                    context.Cycles.Add(cycle);
                    context.SaveChanges();
                }
            }
        }
    }
}