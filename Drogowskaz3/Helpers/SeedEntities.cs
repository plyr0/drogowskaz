using System;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Helpers
{
    public class SeedEntities : IDatabaseInitializer<drogowskazEntities>
    {
        public void InitializeDatabase(drogowskazEntities context)
        {
            AddCycles(context);
            AddHolidays(context);
        }

        private static void AddHolidays(drogowskazEntities context)
        {
            for(int i=0; i<CyclesUtilitiess.holidayNames.Length; i++)
            {
                string name = CyclesUtilitiess.holidayNames[i];
                Holiday holiday = context.Holidays.FirstOrDefault(c => c.Name == name);
                if (holiday == null)
                {
                    holiday = new Holiday()
                    {
                        Name = name,                
                        Category = CyclesUtilitiess.holidayCategories[name]
                    };
                    context.Holidays.Add(holiday);
                    context.SaveChanges();
                }
            }
        }

        private static void AddCycles(drogowskazEntities context)
        {
            for (int i = 0; i < CyclesUtilitiess.cyclesNames.Length; i++)
            {
                string name = CyclesUtilitiess.cyclesNames[i];
                Cycle cycle = context.Cycles.FirstOrDefault(c => c.Name == name);
                if (cycle == null)
                {
                    cycle = new Cycle()
                    {
                        Name = name,
                      };
                    context.Cycles.Add(cycle);
                    context.SaveChanges();
                }
            }
        }
    }
}