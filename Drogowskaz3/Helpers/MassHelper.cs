using System;
using System.Linq;

namespace WebApplication1.Helpers
{
    public class MassHelper
    {
        public const string MASS_TYPE_ALL = "Każdy";
        public const string MASS_TYPE_SINGULAR = "Pojedyncza";
        public const string MASS_TYPE_MONTH = "Miesiące";
        public const string MASS_TYPE_CYCLE = "Okres liturgiczny";
        
        public static void GenerateMasses(drogowskazEntities db)
        {
            foreach(Rule r in db.Rules.ToList())
            {
                GenerateMassesFromOneRule(r,db);
            }
        }

        private static void GenerateMassesFromOneRule(Rule r, drogowskazEntities db)
        {
            DateTime? date = r.SingularMass;
            if (r.CycleType == MASS_TYPE_SINGULAR && date!=null)
            {
                Mass msza = new Mass() {
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
            else if(r.CycleType == MASS_TYPE_MONTH)
            {

            }
        }
    }
}