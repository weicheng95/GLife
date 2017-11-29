using GLifeApplication.Models;
using GLifeApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GLifeApplication.ViewModels
{
    public class SportRecordView
    {
        [DisplayName("Search")]
        public string Search { get; set; }

        public List<SportRecord> SportRecordList { get; set; }

        //need this?? 
        public List<TotalCaloriesResult> TotalCaloriesList { get; set; }

        public ForDateTime Date { get; set; }

    }
}