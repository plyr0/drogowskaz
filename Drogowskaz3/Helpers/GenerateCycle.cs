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
           start = GenerateDate.PierwszaNiedzielaAdwentu(rok);
            end = GenerateDate.BozeNarodzenie1(rok);
        }

        public static void OkresBozonarodzeniowy(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.BozeNarodzenie1(rok);
            end = GenerateDate.TrzechKroli(rok);
        }

        public static void WielkiPost(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.SrodaPopielcowa(rok);
            end = GenerateDate.WielkiCzwartek(rok);
        }

        public static void TriduumPaschalne(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.WielkiCzwartek(rok);
            end = GenerateDate.NiedzielaWielkanocna(rok);
        }
        public static void OkresZmartwychwstaniaPanskiego(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.NiedzielaWielkanocna(rok);
            end = GenerateDate.Wniebowstapienie(rok);
        }
        public static void RokSzkolny(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.PierwszyDzienRokuSzkolnego(rok);
            end = GenerateDate.OstatniDzienRokuSzkolnego(rok).AddHours(24);
        }
        public static void Wakacje(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.OstatniDzienRokuSzkolnego(rok).AddHours(24);
            end = GenerateDate.PierwszyDzienRokuSzkolnego(rok);
        }
        public static void CzasLetni(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.OstatniaNiedzielaMarca(rok);
            end = GenerateDate.OstatniaNiedzielaPazdziernika(rok);
        }
        public static void CzasZimowy(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.OstatniaNiedzielaPazdziernika(rok);
            end = GenerateDate.OstatniaNiedzielaMarca(rok);
        }
        public static void OkresZwykly1(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.NiedzielaChrztuPanskiego(rok);
            end = GenerateDate.SrodaPopielcowa(rok);
        }
        public static void OkresZwykly2(int rok, out DateTime start, out DateTime end)
        {
            start = GenerateDate.ZeslanieDuchaSwietego(rok).AddDays(1);
            end = GenerateDate.PierwszaNiedzielaAdwentu(rok);
        }
    }
}