using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GLifeApplication.ViewModels
{
    public class FoodView
    {
        public String FoodName { get; set; }

        public int Calories { get; set; }
        
        public int Count { get; set; }

        public DateTime Date { get; set; }
    }
}