using System;
using System.Linq;

namespace WebApplication1.Helpers
{
    public class MassHelper
    {
        public const string CYCLE_TYPE_MONTH = "Miesiące";
        public const string CYCLE_TYPE_CYCLE = "Okres";
        public const string CYCLE_TYPE_HOLIDAY = "Święto";
        public const string CYCLE_TYPE_SINGULAR = "Pojedyncza";
        public const string CYCLE_TYPE_REPEAT_DAYS = "Powtarzaj(co ile dni)";
        public const string CYCLE_TYPE_REPEAT_DAY_IN_MONTH = "Powtarzaj(dzień miesiąca)";

        public static void GenerateMasses(drogowskazEntities db, DateTime currentDate)
        {
            foreach(Rule r in db.Rules.ToList())
            {
                GenerateMassesFromOneRule(r,db,currentDate);
            }
        }

        private static void GenerateMassesFromOneRule(Rule r, drogowskazEntities db, DateTime currentDate)
        {
            if (r.DateBegin != null && currentDate < r.DateBegin)
                return;
            if (r.DateEnd != null && currentDate > r.DateEnd)
                return;
            DateTime dateAndTime = currentDate.AddMinutes(r.Hour.TotalMinutes); //TODO: przesunąć do switcha, kasować msze o niższym priorytecie
            if (db.Masses.Where(m => m.DateAndTime == dateAndTime && m.ChurchId == r.ChurchId).Any())
            {
                return;
            }
            int shift = r.DateShift ?? 0;
            DateTime dateShift = currentDate.AddDays(shift);
            DateTime? dateBegin = r.DateBegin;
            switch (r.CycleType)
            {
                case CYCLE_TYPE_SINGULAR:
                    ruleSingular(r, dateBegin, currentDate, db);
                    break;
                case CYCLE_TYPE_HOLIDAY:
                    ruleHoliday(r, dateShift, currentDate, db);
                    break;
                case CYCLE_TYPE_MONTH:
                    ruleMonth(r, dateShift, currentDate, db);
                    break;
                case CYCLE_TYPE_CYCLE:
                    ruleCycle(r, dateShift, currentDate, db);
                    break;
                case CYCLE_TYPE_REPEAT_DAYS:
                    //TODO:
                    break;
                case CYCLE_TYPE_REPEAT_DAY_IN_MONTH:
                    //TODO:
                    break;
                default:
                    throw new Exception("Nieznany typ mszy");
            }
        }

        private static void ruleSingular(Rule r, DateTime? date, DateTime currentDate, drogowskazEntities db)
        {
            if (date != null && currentDate == date)
            {
                AddMass(r, db, date);
            }
        }

        private static void ruleHoliday(Rule r, DateTime dateShift, DateTime currentDate, drogowskazEntities db)
        {
            //string nazwaSwieta = CyclesUtilitiess.GenerujSwieto(dateShift);
            //if (nazwaSwieta != null && r.Holiday.Name == nazwaSwieta)
            if(CyclesUtilitiess.isInHoliday(dateShift, r.Holiday.Name))
            {
                AddMass(r, db, currentDate);
            }
        }

        private static void ruleMonth(Rule r, DateTime dateShift, DateTime currentDate, drogowskazEntities db)
        {
            int msc = dateShift.Month;
            if (!czyDodacDlaMiesiaca(r, msc))
                return;
            
            int dzienTyg = (int)dateShift.DayOfWeek;
            if(!czyDodacDlaDniaTygodnia(r, dzienTyg))
                return;
             
            if (!czyDodacDlaTygodniaWMiesiacu(r, dateShift))
                return;

            AddMass(r, db, currentDate);
        }
        
        private static void ruleCycle(Rule r, DateTime dateShift, DateTime currentDate, drogowskazEntities db)
        {
            int dzienTyg = (int)dateShift.DayOfWeek;
            if (!czyDodacDlaDniaTygodnia(r, dzienTyg))
                return;

            if (!czyDodacDlaTygodniaWMiesiacu(r, dateShift))
                return;

            bool hit = CyclesUtilitiess.isInCycle(dateShift, r.Cycle.Name);
            if (hit)
                AddMass(r, db, currentDate);
        }

        private static bool czyDodacDlaDniaTygodnia(Rule r, int dzienTyg)
        {
            bool[] czyTydzien = { r.Sunday, r.Monday, r.Tuesday, r.Wednesday, r.Thursday, r.Friday, r.Saturday };
            return czyTydzien[dzienTyg];
        }

        private static bool czyDodacDlaMiesiaca(Rule r, int month)
        {
            bool[] czyMiesiac = { false, r.I, r.II, r.III, r.IV , r.V, r.VI, r.VII, r.VIII, r.IX, r.X,
                                        r.XI, r.XII };
            return czyMiesiac[month];
        }

        private static bool czyDodacDlaTygodniaWMiesiacu(Rule r, DateTime dateShift)
        {
            int dniWmiesiacu = DateTime.DaysInMonth(dateShift.Year, dateShift.Month);
            int dzienMiesiaca = dateShift.Day;
            bool ostatniTydzien = dniWmiesiacu - dzienMiesiaca < 7;
            if (ostatniTydzien && r.WeekLast == true)
                return true;

            int weekOfMonth = (int)Math.Ceiling(dzienMiesiaca / 7.0);
            switch (weekOfMonth)
            {
                case 1:
                    return r.Week1;
                case 2:
                    return r.Week2;
                case 3:
                    return r.Week3;
                case 4:
                    return r.Week4;
                case 5:
                    return r.Week5;
                default:
                    throw new Exception("Numer tygodnia w miesiącu spoza 1-5");
            }
        }

        private static void AddMass(Rule r, drogowskazEntities db, DateTime? date)
        {
            Mass msza = new Mass()
            {
                Church = r.Church,
                DateAndTime = ((DateTime)date).AddMinutes(r.Hour.TotalMinutes),
                ChurchId = r.ChurchId,
                RuleId = r.Id,
                Rule = r
            };
            db.Masses.Add(msza);
            db.SaveChanges();
        }
    }
}

//TODO: okresy
//TODO: powtarzalna
//TODO: kopiowanie reguły do kilku kościołów - zostawiam Ci
