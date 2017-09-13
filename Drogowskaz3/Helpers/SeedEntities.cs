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
            foreach(string name in CyclesUtilitiess.names) {
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