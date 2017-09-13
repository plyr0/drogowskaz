using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DrogowskazSerwer.Function;

namespace WebApplication1.Functions
{
    public static class GenerateCycle 
    {
        public static void Adwent(int rok, out DateTime start, out DateTime end)
        {
           start = GenerateDate.FirstSundayOfAdvent(rok);//TODO
            end = GenerateDate.BozeNarodzenie1(rok);
        }

        public static void OkresBozonarodzeniowy(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.BozeNarodzenie1(rok);
            end = GenerateDate.Gromnicznej(rok);//TODO
        }

        public static void WielkiPost(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.AshWednesday(rok);
            end = GenerateDate.ThursdayDay(rok);
        }

        public static void TriduumPaschalne(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.ThursdayDay(rok);
            end = GenerateDate.EasterSunday(rok);//TODO
        }
        public static void OkresZmartwychwstaniaPanskiego(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.EasterSunday(rok);
            end = GenerateDate.AscensionDay(rok);
        }
    }
}