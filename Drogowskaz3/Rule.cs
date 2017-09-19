//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Rule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rule()
        {
            this.Monday = false;
            this.Tuesday = false;
            this.Wednesday = false;
            this.Thursday = false;
            this.Friday = false;
            this.Saturday = false;
            this.Sunday = true;
            this.I = true;
            this.II = true;
            this.III = true;
            this.IV = true;
            this.V = true;
            this.VI = true;
            this.VII = true;
            this.VIII = true;
            this.IX = true;
            this.X = true;
            this.XI = true;
            this.XII = true;
            this.Week1 = true;
            this.Week2 = true;
            this.Week3 = true;
            this.Week4 = true;
            this.Week5 = true;
            this.WeekLast = true;
            this.Masses = new HashSet<Mass>();
            this.ExceptionsRules = new HashSet<ExceptionsRules>();
        }
    
        public long Id { get; set; }
        public string MassType { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public bool I { get; set; }
        public bool II { get; set; }
        public bool III { get; set; }
        public bool IV { get; set; }
        public bool V { get; set; }
        public bool VI { get; set; }
        public bool VII { get; set; }
        public bool VIII { get; set; }
        public bool IX { get; set; }
        public bool X { get; set; }
        public bool XI { get; set; }
        public bool XII { get; set; }
        public bool Week1 { get; set; }
        public bool Week2 { get; set; }
        public bool Week3 { get; set; }
        public bool Week4 { get; set; }
        public bool Week5 { get; set; }
        public bool WeekLast { get; set; }
        public string CycleType { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateBegin { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateEnd { get; set; }
        public System.TimeSpan Hour { get; set; }
        public Nullable<int> DateShift { get; set; }
        public Nullable<System.DateTime> RepeatDateFirst { get; set; }
        public Nullable<int> RepeatEveryDays { get; set; }
        public Nullable<int> RepeatEveryDayInMonth { get; set; }
        public string RepeatType { get; set; }
        public long ChurchId { get; set; }
        public long CycleId { get; set; }
        public long HolidayId { get; set; }
        public string Comment { get; set; }
    
        public virtual Church Church { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mass> Masses { get; set; }
        public virtual Cycle Cycle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExceptionsRules> ExceptionsRules { get; set; }
        public virtual Holiday Holiday { get; set; }
    }
}
