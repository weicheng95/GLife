using GLifeApplication.Models;
using GLifeApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GLifeApplication.ViewModels
{
    public class FoodRecordView
    {
        [DisplayName("Search")]
        public string Search { get; set; }

        public List<FoodRecord>  FoodRecordList { get; set; }

        public List<TotalCaloriesResult> TotalCaloriesList { get; set; }

        public ForDateTime Date { get; set; }



    }
}