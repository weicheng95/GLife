//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GLifeApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SportRecord
    {
        public int SportRecord_Id { get; set; }
        public string SportName { get; set; }
        public int SportTime { get; set; }
        public int BurnCalories { get; set; }
        public string Username { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int Sport_Id { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual SportDatabase SportDatabase { get; set; }
    }
}
