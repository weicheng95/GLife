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
    
    public partial class test
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public test()
        {
            this.FoodRecord = new HashSet<FoodRecord>();
        }
    
        public int Food_Id { get; set; }
        public string 食品分類 { get; set; }
        public string FoodName { get; set; }
        public string Calories { get; set; }
        public string 水分_成分值_g_ { get; set; }
        public string 粗蛋白_成分值_g_ { get; set; }
        public string 粗脂肪_成分值_g_ { get; set; }
        public string 飽和脂肪_成分值_g_ { get; set; }
        public string 總碳水化合物_成分值_g_ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FoodRecord> FoodRecord { get; set; }
    }
}
