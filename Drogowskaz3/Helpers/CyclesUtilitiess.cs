using DrogowskazSerwer.Helpers;
using System;

namespace WebApplication1.Helpers
{
    public static class CyclesUtilitiess
    {
        public static string[] names = {
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

        public delegate void CycleFunc<Y, S, E>(Y year, out S start, out E end);
        public static CycleFunc<int, DateTime, DateTime> nilFunc = (int year, out DateTime start, out DateTime end)=>{ start = new DateTime(); end = new DateTime(); };
        public static CycleFunc<int, DateTime, DateTime>[] functionsCycles = {
            nilFunc, //Wakacje
            nilFunc, //Rok szkolny
            nilFunc, //okres zwykły
            GenerateCycle.Adwent,
            GenerateCycle.OkresBozonarodzeniowy,
            GenerateCycle.WielkiPost,
            GenerateCycle.TriduumPaschalne,
            GenerateCycle.OkresZmartwychwstaniaPanskiego,
            nilFunc,
            nilFunc
        };
    }
}