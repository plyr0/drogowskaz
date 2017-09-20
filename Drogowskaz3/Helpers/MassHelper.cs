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

        public static void GenerateMasses(drogowskazEntities db, DateTime currentDate)
        {
            foreach(Rule r in db.Rules.ToList())
            {
                GenerateMassesFromOneRule(r,db,currentDate);
            }
        }

        private static void GenerateMassesFromOneRule(Rule r, drogowskazEntities db, DateTime currentDate)
        {
            DateTime dateAndTime = currentDate.AddMinutes(r.Hour.TotalMinutes);
            if (db.Masses.Where(m => m.DateAndTime == dateAndTime && m.ChurchId == r.ChurchId).Any())
            {
                return;
            }

            int shift = r.DateShift ?? 0;
            DateTime dateShift = currentDate.AddDays(shift);
            DateTime? date = r.DateBegin;
            switch (r.CycleType)
            {
                case CYCLE_TYPE_SINGULAR:
                    if (r.CycleType == CYCLE_TYPE_SINGULAR)
                    {
                        if (date != null && currentDate == date)
                        {
                            AddMass(r, db, date);
                            return;
                        }
                    }
                    break;
                case CYCLE_TYPE_HOLIDAY:
                    string nazwaSwieta = CyclesUtilitiess.GenerujSwieto(dateShift);
                    if (nazwaSwieta != null && r.Holiday.Name == nazwaSwieta)
                    {
                        AddMass(r, db, currentDate);
                        return;
                    }
                    
                    break;
                case CYCLE_TYPE_MONTH:
                    if (r.CycleType == CYCLE_TYPE_MONTH)
                    {
                        int msc = dateShift.Month;
                        bool[] czyMiesiac = { false, r.I, r.II, r.III, r.IV , r.V, r.VI, r.VII, r.VIII, r.IX, r.X,
                                        r.XI, r.XII };
                        if (false == czyMiesiac[msc])
                            return;

                    }
                    bool[] czyTydzien = { r.Sunday, r.Monday, r.Tuesday, r.Wednesday, r.Thursday,
                                    r.Friday, r.Saturday };
                    if (false == czyTydzien[Convert.ToInt32(dateShift.DayOfWeek)])
                        return;

                    int dniWmiesiacu = DateTime.DaysInMonth(dateShift.Year, dateShift.Month);
                    int dzienMiesiaca = dateShift.Day;
                    if (dniWmiesiacu - dzienMiesiaca < 7 && r.WeekLast == true)
                    {
                        AddMass(r, db, currentDate);
                        return;
                    }

                    int weekOfMonth = dateShift.Day / 7 + 1;
                    switch (weekOfMonth)
                    {
                        case 1:
                            if (r.Week1 == false)
                                return;
                            break;
                        case 2:
                            if (r.Week2 == false)
                                return;
                            break;
                        case 3:
                            if (r.Week3 == false)
                                return;
                            break;
                        case 4:
                            if (r.Week4 == false)
                                return;
                            break;
                        case 5:
                            if (r.Week5 == false)
                                return;
                            break;

                    }

                    break;
                case CYCLE_TYPE_CYCLE:
                    String nazwaCyklu;
                    if (r.Cycle.Name == "Rok Szkolny")
                    {
                        
                        nazwaCyklu = CyclesUtilitiess.GenerujRokSzkolny(dateShift);
                    }
                    else
                    {
                        nazwaCyklu = CyclesUtilitiess.GenerujCykl(dateShift);
                    }
                   
                    if (nazwaCyklu != null && r.Cycle.Name == nazwaCyklu)
                    {
                        AddMass(r, db, currentDate);
                        return;
                    }
                    break;
                default:
                    throw new Exception("Nieznany typ mszy");
            }
        }

        
            
            
                

                //TODO: okresy, 
                //TODO: powtarzalna, 
                //TODO: 2 msze o tej samej godz w tym samym kościele - nowa regułakasuje starą mszę
                //TODO: okres kolędowy
                //TODO: święta dni wolne od pracy
                //TODO: święta dni robocze
                //TODO: dzień zaduszny
                //TODO: zaznacz pon-pt
                //TODO: kopiowanie reguły do kilku kościołów


      
        private static void AddMass(Rule r, drogowskazEntities db, DateTime? date)
        {
            Mass msza = new Mass()
            {
                Church = r.Church,
                DateAndTime = ((DateTime)date).AddMinutes(r.Hour.TotalMinutes),
                ChurchId = r.ChurchId,
                MassType = r.MassType,
                RuleId = r.Id,
                Rule = r
            };
            db.Masses.Add(msza);
            db.SaveChanges();
        }
    }
}