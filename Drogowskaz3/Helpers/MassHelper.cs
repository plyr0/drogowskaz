using System;
using System.Linq;

namespace WebApplication1.Helpers
{
    public class MassHelper
    {
        public const string CYCLE_TYPE_NONE = "(brak)";
        public const string CYCLE_TYPE_MONTH = "Miesiące";
        public const string CYCLE_TYPE_CYCLE = "Okres liturgiczny";
        public const string CYCLE_TYPE_HOLIDAY = "Święto";
        public const string CYCLE_TYPE_SUMMER_TIME = "Czas letni/zimowy";
        public const string CYCLE_TYPE_SCHOOL_YEAR = "Rok szkolny";
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
            DateTime dateAndTime = currentDate.AddMinutes(r.Hour.Value.TotalMinutes);
            if (db.Masses.Where(m => m.DateAndTime == dateAndTime && m.ChurchId == r.ChurchId).Any())
            {
                return;
            }
            DateTime? date = r.DateBegin;
            if (r.CycleType == CYCLE_TYPE_SINGULAR)
            {
                if( date != null && currentDate == date)
                {
                    AddMass(r, db, date);
                }
            }
            else 
            {
                int shift = r.DateShift ?? 0;
                DateTime dateShift = currentDate.AddDays(shift);

                if (r.CycleType == CYCLE_TYPE_HOLIDAY)
                {
                    string nazwaSwieta = CyclesUtilitiess.GenerujSwieto(dateShift);
                    if (nazwaSwieta != null && r.Cycle.Name == nazwaSwieta)
                    {
                        AddMass(r, db, currentDate);
                    }
                }
                else if(r.CycleType == CYCLE_TYPE_MONTH)
                {

                }
            }
        }

        private static void AddMass(Rule r, drogowskazEntities db, DateTime? date)
        {
            Mass msza = new Mass()
            {
                Church = r.Church,
                DateAndTime = ((DateTime)date).AddMinutes(r.Hour.Value.TotalMinutes),
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