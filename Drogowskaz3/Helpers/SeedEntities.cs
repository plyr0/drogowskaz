using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Helpers
{
    public class SeedEntities : IDatabaseInitializer<drogowskazEntities>
    {
        public void InitializeDatabase(drogowskazEntities context)
        {
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