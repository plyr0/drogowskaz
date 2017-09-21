﻿using DrogowskazSerwer.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1.Helpers
{
    public static class CyclesUtilitiess
    {
        public delegate void CycleFunc<Y, S, E>(Y year, out S start, out E end);

        public static Dictionary<string, CycleFunc<int, DateTime, DateTime>> cycleNamesToFuncs =
            new Dictionary<string, CycleFunc<int, DateTime, DateTime>>();

        static CyclesUtilitiess()
        {
            for(int i=0; i<cyclesNames.Length; i++)
            {
                cycleNamesToFuncs.Add(cyclesNames[i], functionsCycles[i]);
            }
        }
        
        public static string[] holidayNames = {
            "Świętej Bożej Rodzicielki",
            "Objawienie Pańskie",
            "Ofiarowanie Pańskie",
            "Środa Popielcowa",
            "Uroczystość św. Józefa",
            "Zwiastowanie Pańskie",
            "Święto św. Wojciecha",
            "Wielki Czwartek",
            "Wielki Piątek",
            "Wigilia Paschalna",
            "Niedziela Wielkanocna",
            "Poniedziałek Wielkanocny",
            "Wniebowstąpienie",
            "Zesłanie Ducha Świętego",
            "Najświętszej Maryi Panny, Matki Kościoła",
            "Najświętszego Ciała i Krwi Pańskiej",
            "Uroczystość Najświętszego Serca Pana Jezusa",
            "Najświętszej Maryi Panny Królowej Polski",
            "Uroczystość św. Piotra i Pawła",
            "Wniebowzięcie Najświętszej Maryi Panny",
            "Matki Boskiej Częstochowskiej",
            "Wszystkich Świętych",      
            "Zaduszki",
            "Uroczystość Niepokalanego Poczęcia Najświetszej Maryi Panny",
            "Wigilia Bożego Narodzenia",
            "Boże Narodzenie",
            "Św. Szczepana",
            "Sylwester", 
            "Pierwszy Dzień Szkoły",
            "Ostatni Dzień Szkoły"
        };

        public static string[] cyclesNames = {
            "Adwent",
            "Okres Bożonarodzeniowy",
            "Wielki Post",
            "Triduum Paschalne",
            "Okres Zmartwychwstania Pańskiego",
            "Czas letni",
            "Czas zimowy",
            "Wakacje",
            "Rok Szkolny",
            "Okres Zwykły",
        };
        
        public static Func<int, DateTime>[] functionsHoliday = {
            GenerateDate.NowyRok,
            GenerateDate.TrzechKroli,
            GenerateDate.Gromnicznej,
            GenerateDate.SrodaPopielcowa,
            GenerateDate.SwJozefa,
            GenerateDate.ZwiastowaniePanskie,
            GenerateDate.SwWojciecha,
            GenerateDate.WielkiCzwartek,
            GenerateDate.WielkiPiatek,
            GenerateDate.WigiliaPaschalna,
            GenerateDate.NiedzielaWielkanocna,
            GenerateDate.PoniedzialekWielkanocny,
            GenerateDate.Wniebowstapienie,
            GenerateDate.ZeslanieDuchaSwietego,
            GenerateDate.NmpMatkiKosciola,
            GenerateDate.BozeCialo,
            GenerateDate.NajswietszegoSercaPanaJezusa,
            GenerateDate.NmpKrolowejPolski,
            GenerateDate.PiotraiPawla,
            GenerateDate.Wniebowziecie,
            GenerateDate.MatkiBoskiejCzestochowskiej,
            GenerateDate.WszystkichSwietych,
            GenerateDate.Zaduszki,
            GenerateDate.NiepokalanegoPoczecia,
            GenerateDate.Wigilia,
            GenerateDate.BozeNarodzenie1,
            GenerateDate.BozeNarodzenie2,
            GenerateDate.Sylwester,            
            GenerateDate.PierwszyDzienRokuSzkolnego,
            GenerateDate.OstatniDzienRokuSzkolnego
        };
        
        public static CycleFunc<int, DateTime, DateTime>[] functionsCycles = {
            GenerateCycle.Adwent,
            GenerateCycle.OkresBozonarodzeniowy,
            GenerateCycle.WielkiPost,
            GenerateCycle.TriduumPaschalne,
            GenerateCycle.OkresZmartwychwstaniaPanskiego,
            GenerateCycle.CzasLetni,
            GenerateCycle.CzasZimowy,
            GenerateCycle.Wakacje,
            GenerateCycle.RokSzkolny,
            GenerateCycle.OkresZwykly2,
        };

        public static Dictionary<string, string> holidayCategories = new Dictionary<string, string>() {
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
            { "Pierwszy Dzień Szkoły", "Szkoła" },
            { "Ostatni Dzień Szkoły", "Szkoła" }
        };

        public static string GenerujSwieto(DateTime dateShift)
        {
            for (int i = 0; i < holidayNames.Length; i++)
            {
                if (functionsHoliday[i](dateShift.Year) == dateShift)
                {
                    return holidayNames[i];
                }
            }
            return null;
        }

        public static bool isInCycle(DateTime dateShift, string name)
        {
            DateTime start;
            DateTime end;
            if (name == "Okres Zwykły")
            {
                GenerateCycle.OkresZwykly1(dateShift.Year, out start, out end);
                if (dateShift >= start && dateShift < end)
                    return true;
                GenerateCycle.OkresZwykly2(dateShift.Year, out start, out end);
                if (dateShift >= start && dateShift < end)
                    return true;

                return false;
            }

            CycleFunc<int, DateTime, DateTime> func;
            cycleNamesToFuncs.TryGetValue(name, out func);
            if (name == "Okres Bożonarodzeniowy" && (dateShift.Month == 1 || dateShift.Month == 2))
            {
                func(dateShift.Year - 1, out start, out end);
            }
            else if (name == "Rok Szkolny" && dateShift.Month >= 1 && dateShift.Month <= 6)
            {
                func(dateShift.Year - 1, out start, out end);
            }
            else if (name == "Czas zimowy" && dateShift.Month >= 1 && dateShift.Month <= 3)
            {
                func(dateShift.Year - 1, out start, out end);
            }
            else 
            {
                func(dateShift.Year, out start, out end);
            }
            if (dateShift >= start && dateShift < end)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string holidaysAllToString(int year)
        {
            string sep = "</br>";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < holidayNames.Length; i++)
            {
                sb.Append(holidayNames[i]).Append(" : ").Append(functionsHoliday[i](year).ToString("d")).Append(sep);
            }
            return sb.ToString();
        }

        public static string cyclesAllToString(int year)
        {
            string sep = "</br>";
            StringBuilder sb = new StringBuilder();
            DateTime start;
            DateTime end;
            CycleFunc<int, DateTime, DateTime> cf;
            for (int i = 0; i < cyclesNames.Length-1; i++)
            {
                cf = functionsCycles[i];
                cf(year, out start, out end);
                sb.Append(cyclesNames[i]).Append(" : ").Append(start.ToString("d")).Append(" - ")
                    .Append(end.ToString("d")).Append(sep);
            }
            cf = GenerateCycle.OkresZwykly1;
            cf(year, out start, out end);
            sb.Append(" OkresZwykły: ").Append(start.ToString("d")).Append(" - ")
                .Append(end.ToString("d"));

            cf = GenerateCycle.OkresZwykly2;
            cf(year, out start, out end);
            sb.Append(" oraz ").Append(start.ToString("d")).Append(" - ")
                .Append(end.ToString("d")).Append(sep);

            cf = GenerateCycle.OkresZwykly1;
            cf(year+1, out start, out end);
            sb.Append(" OkresZwykły 2018: ").Append(start.ToString("d")).Append(" - ")
                .Append(end.ToString("d"));

            cf = GenerateCycle.OkresZwykly2;
            cf(year+1, out start, out end);
            sb.Append(" oraz ").Append(start.ToString("d")).Append(" - ")
                .Append(end.ToString("d"));

            return sb.ToString();
        }
    }
}