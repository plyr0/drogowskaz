using System;
using System.Linq;

namespace WebApplication1.Helpers
{
    public class MassHelper
    {
        public const string CYCLE_TYPE_ALL = "Każdy";
        public const string CYCLE_TYPE_SINGULAR = "Pojedyncza";
        public const string CYCLE_TYPE_MONTH = "Miesiące";
        public const string CYCLE_TYPE_CYCLE = "Okres liturgiczny";
        
        public static void GenerateMasses(drogowskazEntities db, DateTime currentDate)
        {
            foreach(Rule r in db.Rules.ToList())
            {
                GenerateMassesFromOneRule(r,db,currentDate);
            }
        }

        private static void GenerateMassesFromOneRule(Rule r, drogowskazEntities db, DateTime currentDate)
        {
            DateTime? date = r.SingularMass;
            if (r.CycleType == CYCLE_TYPE_SINGULAR)
            {
                if( date != null && currentDate == date)
                {
                    Mass msza = new Mass()
                    {
                        Church = r.Church,
                        DateAndTime = (DateTime)date,
                        ChurchId = r.ChurchId,
                        MassType = r.MassType,
                        RuleId = r.Id,
                        Rule = r
                    };
                    db.Masses.Add(msza);
                    db.SaveChanges();
                }
            }
            else 
            {
                int? shift = r.DateShift;
                DateTime dateShift;
                if (shift!=null)
                {
                     dateShift = currentDate.AddDays((int)shift);
                }
                else
                {
                    dateShift = currentDate;
                }
                string nazwaSwieta = CyclesUtilitiess.GenerujSwieto(dateShift);
                if(nazwaSwieta!=null)
                {
                    Mass msza = new Mass()
                    {
                        Church = r.Church,
                        DateAndTime = currentDate,
                        ChurchId = r.ChurchId,
                        MassType = r.MassType,
                        RuleId = r.Id,
                        Rule = r
                        
                    };
                    db.Masses.Add(msza);
                    db.SaveChanges();
                }
                if(r.CycleType == CYCLE_TYPE_MONTH)
                {

                }
            }
        }
    }
}