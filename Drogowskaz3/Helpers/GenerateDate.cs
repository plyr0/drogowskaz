using System;

namespace DrogowskazSerwer.Helpers
{
    public static class GenerateDate
    {

        static void EasterSunday(int year, ref int month, ref int day)
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

        public static DateTime NiedzielaWielkanocna(int year) //Niedziela Wielkanocna/Wielkanoc
        {
            int month = 0;
            int day = 0;
            EasterSunday(year, ref month, ref day);

            return new DateTime(year, month, day);
        }
        public static DateTime SrodaPopielcowa(int year) //Środa popielcowa
        {
            return NiedzielaWielkanocna(year).AddDays(-46);
        }
        public static DateTime WielkiCzwartek(int year) //Wielki czwartek (40 dni po Zmartwychwstaniu -> plus 3 dni do niedzieli)
        {
            return NiedzielaWielkanocna(year).AddDays(-3);
        }
        public static DateTime WielkiPiatek(int year) //Wielki Piatek (40 dni po Zmartwychwstaniu -> plus 3 dni do niedzieli)
        {
            return NiedzielaWielkanocna(year).AddDays(-2);
        }
        public static DateTime WigiliaPaschalna(int year) //Wigilia Paschalna
        {
            return NiedzielaWielkanocna(year).AddDays(-1);
        }
        public static DateTime PoniedzialekWielkanocny(int year) //Poniedziałek
        {
            return NiedzielaWielkanocna(year).AddDays(1);
        }
        public static DateTime Wniebowstapienie(int year) //Dzień Wniebowstąpienia (40 dni po Zmartwychwstaniu -> plus 3 dni do niedzieli)
        {
            return NiedzielaWielkanocna(year).AddDays(42);
        }

        public static DateTime ZeslanieDuchaSwietego(int year) //Zesłanie Ducha Świętego (7 tygodni po Wielkanocy Niedzieli)  W niedziele
        {
            return NiedzielaWielkanocna(year).AddDays(49);
        }
        public static DateTime NmpMatkiKosciola(int year) ////Najświętszej Maryi Panny, Matki Kościoła, 1 dzień po Zesłaniu Ducha Świętego
        {
            return NiedzielaWielkanocna(year).AddDays(50);
        }

        public static DateTime BozeCialo(int year) //Najświętszego Ciała i Krwi Pańskiej Boże Ciało
        {
            return NiedzielaWielkanocna(year).AddDays(60);
        }

        public static DateTime NajswietszegoSercaPanaJezusa(int year) ///Uroczystość Najświętszego Serca Pana Jezusa
        {
            return NmpMatkiKosciola(year).AddDays(18);
        }

        public static DateTime PierwszaNiedzielaAdwentu(int year) // Pierwsza Niedziela Adwentu
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

        public static DateTime NmpKrolowejPolski(int year)
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
        public static DateTime MatkiBoskiejCzestochowskiej(int year)
        {
            return new DateTime(year, 8, 26);
        }
        public static DateTime PierwszyDzienRokuSzkolnego(int year)
        {
            DateTime firstDay = new DateTime(year, 9, 1);
            if(firstDay.DayOfWeek == DayOfWeek.Friday)
            {
                return new DateTime(year, 9, 4);
            }
            else  if (firstDay.DayOfWeek == DayOfWeek.Saturday)
            {
                return new DateTime(year, 9, 3);
            }
            else if (firstDay.DayOfWeek == DayOfWeek.Sunday)
            {
                return new DateTime(year, 9, 2);
            }
            else
                return new DateTime(year,9,1);
        }
        public static DateTime OstatniDzienRokuSzkolnego(int year)
        {
            DateTime LastDay = new DateTime(year, 6, 21);
            for(int i = 0; i<7;i++)
            {
                
                if(LastDay.DayOfWeek==DayOfWeek.Friday)
                {
                    return LastDay;
                }
                LastDay = LastDay.AddDays(1);

            }
            throw new Exception("WTF");
        }

        public static DateTime OstatniaNiedzielaMarca(int year)
        {
            
            DateTime LastDay = new DateTime(year, 3, 31);
            for (int i = 0; i < 7; i++)
            {

                if (LastDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    return LastDay;
                }
                LastDay = LastDay.AddDays(-1);

            }
            throw new Exception("WTF");
        }

        public static DateTime OstatniaNiedzielaPazdziernika(int year)
        {
            DateTime LastDay = new DateTime(year, 10, 31);
            for (int i = 0; i < 7; i++)
            {

                if (LastDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    return LastDay;
                }
                LastDay = LastDay.AddDays(-1);

            }
            throw new Exception("WTF");
        }

        public static DateTime NiedzielaChrztuPanskiego(int year)
        {
            DateTime LastDay = TrzechKroli(year).AddDays(1);
            for (int i = 0; i < 7; i++)
            {

                if (LastDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    return LastDay;
                }
                LastDay = LastDay.AddDays(1);

            }
            throw new Exception("WTF");
        }

        public static void GetDate(int year2)       
        { //11 Świąt i Pierwsza Niedziela Adwentu
            Console.WriteLine("Środa Popielcowa : " + SrodaPopielcowa(year2).ToString("d"));
            Console.WriteLine("Wielki Czwartek : " + WielkiCzwartek(year2).ToString("d"));
            Console.WriteLine("Wielki Piątek : " + WielkiPiatek(year2).ToString("d"));
            Console.WriteLine("Wigilia Paschalna : " + WigiliaPaschalna(year2).ToString("d"));
            Console.WriteLine("Niedziela Wielkanocna : " + NiedzielaWielkanocna(year2).ToString("d"));
            Console.WriteLine("Poniedziałek Wielkanocny : " + PoniedzialekWielkanocny(year2).ToString("d"));
            Console.WriteLine("Wniebowstąpienie : " + Wniebowstapienie(year2).ToString("d"));
            Console.WriteLine("Zesłanie Ducha Świętego : " + ZeslanieDuchaSwietego(year2).ToString("d"));
            Console.WriteLine("Najświętszej Maryi Panny, Matki Kościoła : " + NmpMatkiKosciola(year2).ToString("d"));
            Console.WriteLine("Najświętszego Ciała i Krwi Pańskiej : " + BozeCialo(year2).ToString("d"));
            Console.WriteLine("Uroczystość Najświętszego Serca Pana Jezusa : " + NajswietszegoSercaPanaJezusa(year2).ToString("d"));
            Console.WriteLine("Pierwsza Niedziela Adwentu : " + PierwszaNiedzielaAdwentu(year2).ToString("d"));
        }
    }
}