using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Helpers
{
    public class SeedEntities : IDatabaseInitializer<drogowskazEntities>
    {
        private Dictionary<string, string> holidayCategories = new Dictionary<string, string>() {
            { "Świętej Bożej Rodzicielki", "Okres Bożonarodzeniowy" },
            { "Objawienie Pańskie", "Okres Bożonarodzeniowy" },
            { "Ofiarowanie Pańskie", "Okres Zwykły " },
            { "Środa Popielcowa", "Wielki Post" },
            { "Uroczystość św. Józefa", "Wielki Post" },
            { "Zwiastowanie Pańskie", "Wielki Post" },
            { "Święto św. Wojciecha", "Okres Zmartwychwstania Pańskiego" },
            { "Wielki Czwartek", "Okres Zmartwychwstania Pańskiego" },
            { "Wielki Piątek", "Okres Zmartwychwstania Pańskiego" },
            { "Wigilia Paschalna", "Okres Zmartwychwstania Pańskiego" },
            { "Niedziela Wielkanocna", "Okres Zmartwychwstania Pańskiego" },
            { "Poniedziałek Wielkanocny", "Okres Zmartwychwstania Pańskiego" },
            { "Wniebowstąpienie", "Okres Zmartwychwstania Pańskiego" },
            { "Zesłanie Ducha Świętego", "Okres Zmartwychwstania Pańskiego" },
            { "Najświętszej Maryi Panny, Matki Kościoła", "Okres Zwykły" },
            { "Najświętszego Ciała i Krwi Pańskiej", "Okres Zwykły" },
            { "Uroczystość Najświętszego Serca Pana Jezusa", "Okres Zwykły" },
            { "Najświętszej Maryi Panny Królowej Polski", "Okres Zwykły" },
            { "Uroczystość św. Piotra i Pawła", "Okres Zwykły" },
            { "Wniebowzięcie Najświętszej Maryi Panny", "Okres Zwykły" },
            { "Matki Boskiej Częstochowskiej", "Okres Zwykły" },
            { "Wszystkich Świętych", "Okres Zwykły" },
            { "Zaduszki", "Okres Zwykły" },
            { "Uroczystość Niepokalanego Poczęcia Najświetszej Maryi Panny", "Adwent" },
            { "Wigilia Bożego Narodzenia", "Adwent" },
            { "Boże Narodzenie",  "Okres Bożonarodzeniowy " },
            { "Św. Szczepana", "Okres Bożonarodzeniowy " },
            { "Sylwester", "Okres Bożonarodzeniowy " },
            { "Pierwszy Dzień Szkoły", "Inne" },
            { "Ostatni Dzień Szkoły", "Inne" },
            { "Święta wolne od pracy", "Inne" },
            { "Święta w dni robocze", "Inne"}
        };

        public void InitializeDatabase(drogowskazEntities context)
        {
            AddCycles(context);
            AddHolidays(context);
        }

        private void AddHolidays(drogowskazEntities context)
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
                        Category = holidayCategories[name]
                    };
                    context.Holidays.Add(holiday);
                    context.SaveChanges();
                }
            }
        }

        private void AddCycles(drogowskazEntities context)
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