//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Accounting.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccountingType
    {
        public AccountingType()
        {
            this.Accounting = new HashSet<Accounting>();
        }
    
        public int TypeID { get; set; }
        public string TypeTitle { get; set; }
    
        public virtual ICollection<Accounting> Accounting { get; set; }
    }
}
