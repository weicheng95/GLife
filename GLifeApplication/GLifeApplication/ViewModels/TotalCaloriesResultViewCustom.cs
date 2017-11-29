using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GLifeApplication.ViewModels
{
    public class TotalCaloriesResultViewCustom
    {
        public int breakfastCalories { get; set; }

        public int lunchCalories { get; set; }

        public int dinnerCalories { get; set; }

        public DateTime date { get; set; }
    }
}