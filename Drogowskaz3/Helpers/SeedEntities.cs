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

            foreach (string name in CyclesUtilitiess.cyclesNames) {
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

            //***************

            Holiday holiday1 = context.Holidays.FirstOrDefault(c => c.Name == "(żadne)");
            if (holiday1 == null)
            {
                holiday1 = new Holiday()
                {
                    Name = "(żadne)"
                };
                context.Holidays.Add(holiday1);
                context.SaveChanges();
            }

            foreach (string name in CyclesUtilitiess.holidayNames)
            {
                Holiday holiday = context.Holidays.FirstOrDefault(c => c.Name == name);
                if (holiday == null)
                {
                    holiday = new Holiday()
                    {
                        Name = name
                    };
                    context.Holidays.Add(holiday);
                    context.SaveChanges();
                }
            }
        }
    }
}