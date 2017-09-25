using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Envelope
    {
        public TimeSpan Hour { get; set; }
        public string MassType { get; set; }
    }

    public class RuleViewModel : Rule
    {
        public List<Envelope> AdditionalMasses { get; set; } = new List<Envelope>();

        public Rule ToRule()
        {
            Rule r = new Rule()
            {
                Church = Church,
                ChurchId = ChurchId,
                Comment = Comment,
                Cycle = Cycle,
                CycleId = CycleId,
                CycleType = CycleType,
                DateBegin = DateBegin,
                DateEnd = DateEnd,
                DateShift = DateShift,
                ExceptionsRules = ExceptionsRules,
                Friday = Friday,
                Holiday = Holiday,
                HolidayId = HolidayId,
                Hour = Hour,
                I = I,
                Id = Id,
                II = II,
                III = III,
                IV = IV,
                IX = IX,
                Masses = Masses,
                MassType = MassType,
                Monday = Monday,
                Repeat = Repeat,
                Saturday = Saturday,
                Sunday = Sunday,
                Thursday = Thursday,
                Tuesday = Tuesday,
                V = V,
                VI = VI,
                VII = VII,
                VIII = VIII,
                Wednesday = Wednesday,
                Week1 = Week1,
                Week2 = Week2,
                Week3 = Week3,
                Week4 = Week4,
                Week5 = Week5,
                WeekLast = WeekLast,
                X = X,
                XI = XI,
                XII = XII
            };
            return r;
        }
    }
}