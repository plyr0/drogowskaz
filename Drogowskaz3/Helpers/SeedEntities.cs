using System;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Helpers
{
    public class SeedEntities : IDatabaseInitializer<drogowskazEntities>
    {
        public void InitializeDatabase(drogowskazEntities context)
        {
            for (int i = DateTime.Today.Year; i < DateTime.Today.Year + 3; i++)
            {
                AddCycles(context, i);
                AddHolidays(context, i);
            }
        }

        private static void AddHolidays(drogowskazEntities context, int year)
        {
            for(int i=0; i<CyclesUtilitiess.holidayNames.Length; i++)
            {
                string name = CyclesUtilitiess.holidayNames[i];
                Holiday holiday = context.Holidays.FirstOrDefault(c => c.Name == name && c.Year == year);
                if (holiday == null)
                {
                    holiday = new Holiday()
                    {
                        Name = name,
                        Year = year,
                        Date = CyclesUtilitiess.functionsHoliday[i](year)                        
                    };
                    context.Holidays.Add(holiday);
                    context.SaveChanges();
                }
            }
        }

        private static void AddCycles(drogowskazEntities context, int year)
        {
            for (int i = 0; i < CyclesUtilitiess.cyclesNames.Length; i++)
            {
                string name = CyclesUtilitiess.cyclesNames[i];
                Cycle cycle = context.Cycles.FirstOrDefault(c => c.Name == name && c.Year == year);
                if (cycle == null)
                {
                    DateTime start;
                    DateTime end;
                    CyclesUtilitiess.functionsCycles[i](year, out start, out end);
                    cycle = new Cycle()
                    {
                        Name = name,
                        Year = year,
                        DateStart = start,
                        DateEnd = end
                    };
                    context.Cycles.Add(cycle);
                    context.SaveChanges();
                }
            }
        }
    }
}