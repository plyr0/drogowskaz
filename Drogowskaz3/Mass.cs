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
    
    public partial class Mass
    {
        public long Id { get; set; }
        public System.DateTime DateAndTime { get; set; }
        public long RuleId { get; set; }
        public string MassType { get; set; }
        public long ChurchId { get; set; }
    
        public virtual Rule Rule { get; set; }
        public virtual Church Church { get; set; }
    }
}
