using DrogowskazSerwer.Helpers;
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

        public delegate D HolidayFunc<Y, D>(Y year);
        public static Dictionary<string, HolidayFunc<int, DateTime>> holidayNameToFunc =
            new Dictionary<string, HolidayFunc<int, DateTime>>();

        static CyclesUtilitiess()
        {
            for(int i=0; i<cycleFunctions.Length; i++)
            {
                cycleNamesToFuncs.Add(cyclesNames[i], cycleFunctions[i]);
            }
            for (int i = 0; i < holidayFunctions.Length; i++)
            {
                holidayNameToFunc.Add(holidayNames[i], holidayFunctions[i]);
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
            "Ostatni Dzień Szkoły",
            "Święta wolne od pracy"
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
            "Okres Zwykły"
        };
        
        public static HolidayFunc<int, DateTime>[] holidayFunctions = {
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
        
        public static CycleFunc<int, DateTime, DateTime>[] cycleFunctions = {
            GenerateCycle.Adwent,
            GenerateCycle.OkresBozonarodzeniowy,
            GenerateCycle.WielkiPost,
            GenerateCycle.TriduumPaschalne,
            GenerateCycle.OkresZmartwychwstaniaPanskiego,
            GenerateCycle.CzasLetni,
            GenerateCycle.CzasZimowy,
            GenerateCycle.Wakacje,
            GenerateCycle.RokSzkolny
        };
        
        private static Dictionary<string, bool> holidayIsFree = new Dictionary<string, bool>() {
            { "Świętej Bożej Rodzicielki", true },
            { "Objawienie Pańskie", true },
            { "Niedziela Wielkanocna", true },
            { "Poniedziałek Wielkanocny", true },
            { "Wniebowstąpienie", true },
            { "Zesłanie Ducha Świętego", true },
            { "Najświętszej Maryi Panny, Matki Kościoła", true },
            { "Najświętszej Maryi Panny Królowej Polski", true },
            { "Wniebowzięcie Najświętszej Maryi Panny", true },
            { "Wszystkich Świętych", true },
            { "Boże Narodzenie",  true },
            { "Św. Szczepana", true },

            { "Ofiarowanie Pańskie", false },
            { "Środa Popielcowa", false },
            { "Uroczystość św. Józefa", false },
            { "Zwiastowanie Pańskie", false },
            { "Święto św. Wojciecha", false },
            { "Wielki Czwartek", false },
            { "Wielki Piątek", false },
            { "Wigilia Paschalna", false },
            { "Najświętszego Ciała i Krwi Pańskiej", false },
            { "Uroczystość Najświętszego Serca Pana Jezusa", false },
            { "Uroczystość św. Piotra i Pawła", false },
            { "Uroczystość Niepokalanego Poczęcia Najświetszej Maryi Panny", false },
            { "Matki Boskiej Częstochowskiej", false },
            { "Zaduszki", false },
            { "Wigilia Bożego Narodzenia", false },
            { "Sylwester", false },
            { "Pierwszy Dzień Szkoły", false },
            { "Ostatni Dzień Szkoły", false }
        };
        
        public static string GenerujSwieto(DateTime dateShift)
        {
            for (int i = 0; i < holidayNames.Length; i++)
            {
                if (holidayFunctions[i](dateShift.Year) == dateShift)
                {
                    return holidayNames[i];
                }
            }
            return null;
        }

        public static bool isInHoliday(DateTime dateShift, string name)
        {
            if (name == "Święta wolne od pracy")
            {
                foreach (var sw in holidayIsFree)
                {
                    if (sw.Value && isInHoliday(dateShift, sw.Key)) //TODO: czy niedziele?
                        return true;
                }
                return false;
            }
            return holidayNameToFunc[name](dateShift.Year) == dateShift;
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

            CycleFunc<int, DateTime, DateTime> func = cycleNamesToFuncs[name];
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
            for (int i = 0; i < holidayFunctions.Length; i++)
            {
                sb.Append(holidayNames[i]).Append(" : ").Append(holidayFunctions[i](year).ToString("d")).Append(sep);
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
            for (int i = 0; i < cycleFunctions.Length; i++)
            {
                cf = cycleFunctions[i];
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