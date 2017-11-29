using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GLifeApplication.ViewModels
{
    public class AnalysisView
    {
        public IQueryable<FoodView>FoodView { get; set; }

        public IQueryable SportView { get; set; }

        public IQueryable<TotalCaloriesResultViewCustom>FoodResultView { get; set; }

        public String day { get; set; }
    }
}