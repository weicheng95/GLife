using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GLifeApplication.Models
{
    [MetadataType(typeof(CaloriesResultMetadata))]
    public partial class TotalCaloriesResult
    {
        private class CaloriesResultMetadata
        {
            [DisplayName("總熱量")]
            public int TotalCalories { get; set; }

            [DisplayName("日期")]
            public DateTime CreateDate { get; set; }

            public int Calories_Id { get; set; }

            public String Username { get; set; }

        }
    }
}