using DrogowskazSerwer.Helpers;
using System;
using System.Text;

namespace WebApplication1.Helpers
{
    public static class CyclesUtilitiess
    {
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
            "Okres Zwykły (I)",
            "Wielki Post",
            "Triduum Paschalne",
            "Okres Zmartwychwstania Pańskiego",
            "Okres Zwykły (II)",
            "Czas letni",
            "Czas zimowy",
            "Rok Szkolny",
            "Wakacje",
        };

        public static Func<int, DateTime>[] functionsFest = {
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

        internal static string GenerujSwieto(DateTime dateShift)
        {
            for (int i = 0; i < holidayNames.Length; i++)
            {
                if(functionsFest[i](dateShift.Year) == dateShift)
                {
                    return holidayNames[i];
                }       
            }
            return null;
        }

        public delegate void CycleFunc<Y, S, E>(Y year, out S start, out E end);

        public static CycleFunc<int, DateTime, DateTime>[] functionsCycles = {
            GenerateCycle.Adwent,
            GenerateCycle.OkresBozonarodzeniowy,
            GenerateCycle.OkresZwykly1,
            GenerateCycle.WielkiPost,
            GenerateCycle.TriduumPaschalne,
            GenerateCycle.OkresZmartwychwstaniaPanskiego,
            GenerateCycle.OkresZwykly2,
            GenerateCycle.CzasLetni,
            GenerateCycle.CzasZimowy,
            GenerateCycle.RokSzkolny,
            GenerateCycle.Wakacje
        };

        public static string holidaysAllToString(int year)
        {
            string sep = "</br>";
            StringBuilder sb = new StringBuilder();
            for(int i=0; i<holidayNames.Length; i++)
            {
                sb.Append(holidayNames[i]).Append(" : ").Append(functionsFest[i](year).ToString("d")).Append(sep);
            }            
            return sb.ToString();
        }

        public static string cyclesAllToString(int year)
        {
            string sep = "</br>";
            StringBuilder sb = new StringBuilder();
            DateTime start;
            DateTime end;
            for (int i = 0; i < cyclesNames.Length; i++)
            {
                CycleFunc<int, DateTime, DateTime> cf = functionsCycles[i];
                cf(year, out start, out end);
                sb.Append(cyclesNames[i]).Append(" : ").Append(start.ToString("d")).Append(" - ")
                    .Append(end.ToString("d")).Append(sep);
            }
            return sb.ToString();
        }
    }
}