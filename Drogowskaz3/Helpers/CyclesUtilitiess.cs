﻿using DrogowskazSerwer.Helpers;
using System;
using System.Text;

namespace WebApplication1.Helpers
{
    public static class CyclesUtilitiess
    {
        public static string[] holidayNames = {
            "Świętej Bożej Rodzicielki", //0
            "Objawienie Pańskie",
            "Ofiarowanie Pańskie",
            "Środa Popielcowa",
            "Uroczystość św. Józefa",
            "Zwiastowanie Pańskie",
            "Święto św. Wojciecha",
            "Wielki Czwartek",
            "Wielki Piątek",
            "Wigilia Paschalna",
            "Niedziela Wielkanocna",    //10
            "Poniedziałek Wielkanocny",
            "Wniebowstąpienie",
            "Zesłanie Ducha Świętego",
            "Najświętszej Maryi Panny, Matki Kościoła",
            "Najświętszego Ciała i Krwi Pańskiej",
            "Uroczystość Najświętszego Serca Pana Jezusa",
            "Najświętszej Maryi Panny Królowej Polski",
            "Uroczystość św. Piotra i Pawła",
            "Wniebowzięcie Najświętszej Maryi Panny",
            "Wszystkich Świętych",      //20
            "Uroczystość Niepokalanego Poczęcia Najświetszej Maryi Panny",
            "Wigilia Bożego Narodzenia",
            "Boże Narodzenie",
            "Św. Szczepana",
            "Sylwester", //25
        };

        public static string[] cyclesNames = {
            "Wakacje",  //0
            "Rok Szkolny",
            "Okres Zwykły",
            "Adwent",
            "Okres Bożonarodzeniowy",
            "Wielki Post", //5
            "Triduum Paschalne",
            "Okres Zmartwychwstania Pańskiego",
            "Czas letni",
            "Czas zimowy" //9
        };

        public static Func<int, DateTime>[] functionsFest = {
            GenerateDate.NowyRok,       //0
            GenerateDate.TrzechKroli,
            GenerateDate.Gromnicznej,
            GenerateDate.SrodaPopielcowa,
            GenerateDate.SwJozefa,
            GenerateDate.ZwiastowaniePanskie,
            GenerateDate.SwWojciecha,
            GenerateDate.WielkiCzwartek,
            GenerateDate.WielkiPiatek,
            GenerateDate.WigiliaPaschalna,
            GenerateDate.NiedzielaWielkanocna, //10
            GenerateDate.PoniedzialekWielkanocny,
            GenerateDate.Wniebowstapienie,
            GenerateDate.ZeslanieDuchaSwietego,
            GenerateDate.NmpMatkiKosciola,
            GenerateDate.BozeCialo,
            GenerateDate.NajswietszegoSercaPanaJezusa,
            GenerateDate.NmpKrolowejPolski,
            GenerateDate.PiotraiPawla,
            GenerateDate.Wniebowziecie,
            GenerateDate.WszystkichSwietych,    //20
            GenerateDate.NiepokalanegoPoczecia,
            GenerateDate.Wigilia,
            GenerateDate.BozeNarodzenie1,
            GenerateDate.BozeNarodzenie2,
            GenerateDate.Sylwester              //25
        };

        internal static string GenerujSwieto(DateTime dateShift)
        {
            for (int i = 0; i < 26; i++)
            {
                if(functionsFest[i](dateShift.Year) == dateShift)
                {
                    return holidayNames[i];
                }       
            }
            return null;
        }

        public delegate void CycleFunc<Y, S, E>(Y year, out S start, out E end);
        public static CycleFunc<int, DateTime, DateTime> nilFunc = (int year, out DateTime start, out DateTime end)=> {
            throw new Exception("Jeszcze nie zaimplementowano!");
        };
        public static CycleFunc<int, DateTime, DateTime>[] functionsCycles = {
            nilFunc, //Wakacje
            nilFunc, //Rok szkolny
            nilFunc, //okres zwykły
            GenerateCycle.Adwent,
            GenerateCycle.OkresBozonarodzeniowy,
            GenerateCycle.WielkiPost,
            GenerateCycle.TriduumPaschalne,
            GenerateCycle.OkresZmartwychwstaniaPanskiego,
            nilFunc, //czas letni
            nilFunc  //czas zimowy
        };

        public static string GenFests(int year)
        {
            string sep = "</br>";
            StringBuilder sb = new StringBuilder();
            for(int i=0; i<26; i++)
            {
                sb.Append(holidayNames[i]).Append(" : ").Append(functionsFest[i](year).ToString("d")).Append(sep);
            }
            return sb.ToString();
        }

        public static string GenCycles(int year)
        {
            string sep = "</br>";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                CycleFunc<int, DateTime, DateTime> cf = functionsCycles[i];
                if (cf != nilFunc)
                {
                    DateTime start;
                    DateTime end;
                    cf(year, out start, out end);
                    sb.Append(cyclesNames[i]).Append(" : ").Append(start.ToString("d")).Append(" - ")
                        .Append(end.ToString("d")).Append(sep);
                }
            }
            return sb.ToString();
        }
    }
}