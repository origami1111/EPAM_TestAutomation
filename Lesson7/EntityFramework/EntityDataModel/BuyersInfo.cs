//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lesson7.EntityFramework.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class BuyersInfo
    {
        public int PersonID { get; set; }
        public int CarID { get; set; }
        public int CityID { get; set; }
        public Nullable<int> Year { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual City City { get; set; }
        public virtual Person Person { get; set; }
    }
}
