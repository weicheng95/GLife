using GLifeApplication.Models;
using GLifeApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GLifeApplication.ViewModels
{
    public class TotalCaloriesView
    {
        public List<TotalCaloriesResult> TotalCaloriesResultList { get; set; }

        public ForDateTime Date { get; set; }
    }
}