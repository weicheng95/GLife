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
    
    public partial class FoodDatabase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FoodDatabase()
        {
            this.FoodRecord = new HashSet<FoodRecord>();
        }
    
        public string FoodName { get; set; }
        public long Barcode { get; set; }
        public int Calories { get; set; }
        public int Food_Id { get; set; }
        public string FoodType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FoodRecord> FoodRecord { get; set; }
    }
}
