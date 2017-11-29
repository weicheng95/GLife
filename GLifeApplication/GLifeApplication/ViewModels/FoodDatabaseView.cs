using GLifeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GLifeApplication.ViewModels
{
    public class FoodDatabaseView
    {
        public List<FoodDatabase> FoodDatabaseList { get; set; }

        public List<Article> Articles { get; set; }
    }
}