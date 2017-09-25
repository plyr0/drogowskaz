using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Events.Month;
using System.Data.Entity;
using System.Collections;
using DayPilot.Web.Mvc.Enums;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class CalendarController : Controller
    {
        [AllowAnonymous]
        public ActionResult Calendar(long? id, long? ruleId)
        {
            ViewBag.ruleId = ruleId;
            ViewBag.id = id;
            return View();
        }

        [AllowAnonymous]
        public ActionResult Backend(long? id, long? ruleId)
        {
            
            return new Dpm(id, ruleId).CallBack(this);
        }

        class Dpm : DayPilotMonth
        {
            long? IdChurch;
            long? ruleId;

            public Dpm(long? id, long? ruleId)
            {
                IdChurch = id;
                this.ruleId = ruleId;
            }

            protected override void OnInit(InitArgs e)
            {
                var db = new drogowskazEntities();
                Events = createEvents(db.Masses);
                DataIdField = "Id";
                DataTextField = "Text";
                DataStartField = "Start";
                DataEndField = "End";
                Update();
            }

            protected override void OnEventClick(EventClickArgs e)
            {
                Redirect("~/Rules/Details?massId=" + e.Id);
            }

            protected override void OnCommand(CommandArgs e)
            {
                switch (e.Command)
                {
                    case "previous":
                        StartDate = StartDate.AddMonths(-1);
                        break;
                    case "next":
                        StartDate = StartDate.AddMonths(1);
                        break;
                    case "today":
                        StartDate = DateTime.Today;
                        break;
                }
                var db = new drogowskazEntities();
                Events = createEvents(db.Masses);
                DataIdField = "Id";
                DataTextField = "Text";
                DataStartField = "Start";
                DataEndField = "End";
                Update(CallBackUpdateType.Full);
            }

            class IntermediateMass
            {
                public long Id { get; set; }
                public string Text { get; set; }
                public DateTime Start { get; set; }
                public DateTime End { get; set; }
            }

            private IEnumerable createEvents(DbSet<Mass> masses)
            {
                IQueryable<Mass> query;
                if(ruleId != null && IdChurch != null)
                {
                     query = masses.Where(m => m.ChurchId == IdChurch && m.RuleId == ruleId);

                }
                else if(ruleId != null )
                {
                    query = masses.Where(m => m.RuleId == ruleId);
                }
                else if (IdChurch != null)
                {
                     query = masses.Where(m => m.ChurchId == IdChurch);
                }
                else
                {
                    query = masses;
                }
                List<IntermediateMass> list = new List<IntermediateMass>();
                foreach (Mass m in query )
                {
                    IntermediateMass i = new IntermediateMass()
                    {
                        Id = m.Id,
                        Start = m.DateAndTime,
                        End = m.DateAndTime.AddHours(1),
                        Text = m.DateAndTime.ToString("HH:mm") + " " + m.Rule.MassType
                    };
                    list.Add(i);
                }
                return list;
            }
        }
    }
}
