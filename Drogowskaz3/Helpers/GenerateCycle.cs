using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DrogowskazSerwer.Helpers;

namespace WebApplication1.Helpers
{
    public static class GenerateCycle 
    {
        public static void Adwent(int rok, out DateTime start, out DateTime end)
        {
           start = GenerateDate.PierwszaNiedzielaAdwentu(rok);//TODO
            end = GenerateDate.BozeNarodzenie1(rok);
        }

        public static void OkresBozonarodzeniowy(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.BozeNarodzenie1(rok);
            end = GenerateDate.Gromnicznej(rok);//TODO
        }

        public static void WielkiPost(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.SrodaPopielcowa(rok);
            end = GenerateDate.WielkiCzwartek(rok);
        }

        public static void TriduumPaschalne(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.WielkiCzwartek(rok);
            end = GenerateDate.NiedzielaWielkanocna(rok);//TODO
        }
        public static void OkresZmartwychwstaniaPanskiego(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.NiedzielaWielkanocna(rok);
            end = GenerateDate.Wniebowstapienie(rok);
        }
    }
}