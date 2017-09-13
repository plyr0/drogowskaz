using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrogowskazSerwer.Function
{
    public static class GenerateDate
    {

        public static void EasterSunday(int year, ref int month, ref int day)
        {
            int g = year % 19;
            int c = year / 100;
            int h = h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25)
                                                + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) *
                        (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            day = i - ((year + (int)(year / 4) +
                          i + 2 - c + (int)(c / 4)) % 7) + 28;
            month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }
        }

        public static DateTime EasterSunday(int year) //Niedziela Wielkanocna/Wielkanoc
        {
            int month = 0;
            int day = 0;
            EasterSunday(year, ref month, ref day);

            return new DateTime(year, month, day);
        }
        public static DateTime AshWednesday(int year) //Środa popielcowa
        {
            return EasterSunday(year).AddDays(-46);
        }
        public static DateTime ThursdayDay(int year) //Wielki czwartek (40 dni po Zmartwychwstaniu -> plus 3 dni do niedzieli)
        {
            return EasterSunday(year).AddDays(-3);
        }
        public static DateTime FridayDay(int year) //Wielki Piatek (40 dni po Zmartwychwstaniu -> plus 3 dni do niedzieli)
        {
            return EasterSunday(year).AddDays(-2);
        }
        public static DateTime PaschalDay(int year) //Wigilia Paschalna
        {
            return EasterSunday(year).AddDays(-1);
        }
        public static DateTime EasterMonday(int year) //Poniedziałek
        {
            return EasterSunday(year).AddDays(1);
        }
        public static DateTime AscensionDay(int year) //Dzień Wniebowstąpienia (40 dni po Zmartwychwstaniu -> plus 3 dni do niedzieli)
        {
            return EasterSunday(year).AddDays(42);
        }

        public static DateTime WhitSunday(int year) //Zesłanie Ducha Świętego (7 tygodni po Wielkanocy Niedzieli)  W niedziele
        {
            return EasterSunday(year).AddDays(49);
        }
        public static DateTime DayAfterWhitSunday(int year) ////Najświętszej Maryi Panny, Matki Kościoła, 1 dzień po Zesłaniu Ducha Świętego
        {
            return EasterSunday(year).AddDays(50);
        }

        public static DateTime BodyOfChrist(int year) //Najświętszego Ciała i Krwi Pańskiej Boże Ciało
        {
            return EasterSunday(year).AddDays(60);
        }

        public static DateTime SacredHeart(int year) ///Uroczystość Najświętszego Serca Pana Jezusa
        {
            return DayAfterWhitSunday(year).AddDays(18);
        }

        public static DateTime FirstSundayOfAdvent(int year) // Pierwsza Niedziela Adwentu
        {
            int weeks = 4;
            int correction = 0;
            DateTime christmas = new DateTime(year, 12, 25);

            if (christmas.DayOfWeek != DayOfWeek.Sunday)
            {
                weeks--;
                correction = ((int)christmas.DayOfWeek - (int)DayOfWeek.Sunday);
            }
            return christmas.AddDays(-1 * ((weeks * 7) + correction));
        }

        public static DateTime Wigilia(int year)
        {
            return new DateTime(year, 12, 24);
        }
        public static DateTime BozeNarodzenie1(int year)
        {
            return new DateTime(year, 12, 25);
        }

        public static DateTime BozeNarodzenie2(int year)
        {
            return new DateTime(year, 12, 26);
        }

        public static DateTime Sylwester(int year)
        {
            return new DateTime(year, 12, 31);
        }

        public static DateTime NowyRok(int year)
        {
            return new DateTime(year, 1, 1);
        }

        public static DateTime TrzechKroli(int year)
        {
            return new DateTime(year, 1, 6);
        }

        public static DateTime Gromnicznej(int year)
        {
            return new DateTime(year, 2, 2);
        }

        public static DateTime SwJozefa(int year)
        {
            return new DateTime(year, 3, 19);
        }

        public static DateTime ZwiastowaniePanskie(int year)
        {
            return new DateTime(year, 3, 25);
        }

        public static DateTime SwWojciecha(int year)
        {
            return new DateTime(year, 4, 23);
        }

        public static DateTime NMPKrolowejPolski(int year)
        {
            return new DateTime(year, 5, 3);
        }

        public static DateTime PiotraiPawla(int year)
        {
            return new DateTime(year, 6, 29);
        }

        public static DateTime Wniebowziecie(int year)
        {
            return new DateTime(year, 8, 15);
        }

        public static DateTime WszystkichSwietych(int year)
        {
            return new DateTime(year, 11, 1);
        }

        public static DateTime Zaduszki(int year)
        {
            return new DateTime(year, 11, 2);
        }

        public static DateTime NiepokalanegoPoczecia(int year)
        {
            return new DateTime(year, 12, 8);
        }
        /* Testowanie:
         
           funkcja GetDate(int year2) -> wypisuje wszystkie daty świąt (11) i datę Pierwszej Niedzieli adwentu
             
             wywołanie: GetDate(2018) lub GenerateDate.GetDate(2018)
             */

        public static void GetDate(int year2)       
        { //11 Świąt i Pierwsza Niedziela Adwentu
            Console.WriteLine("Środa Popielcowa : " + AshWednesday(year2).ToString("d"));
            Console.WriteLine("Wielki Czwartek : " + ThursdayDay(year2).ToString("d"));
            Console.WriteLine("Wielki Piątek : " + FridayDay(year2).ToString("d"));
            Console.WriteLine("Wigilia Paschalna : " + PaschalDay(year2).ToString("d"));
            Console.WriteLine("Niedziela Wielkanocna : " + EasterSunday(year2).ToString("d"));
            Console.WriteLine("Poniedziałek Wielkanocny : " + EasterMonday(year2).ToString("d"));
            Console.WriteLine("Wniebowstąpienie : " + AscensionDay(year2).ToString("d"));
            Console.WriteLine("Zesłanie Ducha Świętego : " + WhitSunday(year2).ToString("d"));
            Console.WriteLine("Najświętszej Maryi Panny, Matki Kościoła : " + DayAfterWhitSunday(year2).ToString("d"));
            Console.WriteLine("Najświętszego Ciała i Krwi Pańskiej : " + BodyOfChrist(year2).ToString("d"));
            Console.WriteLine("Uroczystość Najświętszego Serca Pana Jezusa : " + SacredHeart(year2).ToString("d"));
            Console.WriteLine("Pierwsza Niedziela Adwentu : " + FirstSundayOfAdvent(year2).ToString("d"));
        }
    }


}