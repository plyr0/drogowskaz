//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Drogowskaz
{
    using System;
    using System.Collections.Generic;
    
    public partial class Church
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Church()
        {
            this.MassRules = new HashSet<MassRule>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Diocese { get; set; }
        public string Deanery { get; set; }
        public string Parish { get; set; }
        public System.Data.Entity.Spatial.DbGeography Location { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MassRule> MassRules { get; set; }
    }
}