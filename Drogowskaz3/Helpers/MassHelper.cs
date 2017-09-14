using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Helpers
{
    public class MassHelper
    {
        public static void Generate_Mass(drogowskazEntities db)
        {
                foreach(Rule r in db.Rules)
                {
                    OneDirection(r,db);  
                }
        }

        private static void OneDirection(Rule r, drogowskazEntities d)
        {
            DateTime? date = r.SingularMass;
            if (date!=null)
            {
                Mass msza = new Mass() {
                    Church = r.Church,
                    DateAndTime = (DateTime)date,
                    ChurchId = r.ChurchId,
                    MassType = r.MassType,
                    RuleId = r.Id,
                    Rule = r
                    
                    
                };
                d.Masses.Add(msza);
                d.SaveChanges();
            }
            else
            {
                if(r.CycleType == "miesiąc")
                {

                }
            }
        }
    }
}