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

        public RuleViewModel() { }

        public RuleViewModel(Rule r)
        {
            Church = r.Church;
            ChurchId = r.ChurchId;
            Comment = r.Comment;
            Cycle = r.Cycle;
            CycleId = r.CycleId;
            CycleType = r.CycleType;
            DateBegin = r.DateBegin;
            DateEnd = r.DateEnd;
            DateShift = r.DateShift;
            ExceptionsRules = r.ExceptionsRules;
            Friday = r.Friday;
            Holiday = r.Holiday;
            HolidayId = r.HolidayId;
            Hour = r.Hour;
            I = r.I;
            Id = r.Id;
            II = r.II;
            III = r.III;
            IV = r.IV;
            IX = r.IX;
            Masses = r.Masses;
            MassType = r.MassType;
            Monday = r.Monday;
            Repeat = r.Repeat;
            Saturday = r.Saturday;
            Sunday = r.Sunday;
            Thursday = r.Thursday;
            Tuesday = r.Tuesday;
            V = r.V;
            VI = r.VI;
            VII = r.VII;
            VIII = r.VIII;
            Wednesday = r.Wednesday;
            Week1 = r.Week1;
            Week2 = r.Week2;
            Week3 = r.Week3;
            Week4 = r.Week4;
            Week5 = r.Week5;
            WeekLast = r.WeekLast;
            X = r.X;
            XI = r.XI;
            XII = r.XII;
        }

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