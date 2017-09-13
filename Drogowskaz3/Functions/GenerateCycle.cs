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
           start = GenerateDate.FirstSundayOfAdvent(rok);
            end = GenerateDate.BozeNarodzenie1(rok);
        }
    }
}