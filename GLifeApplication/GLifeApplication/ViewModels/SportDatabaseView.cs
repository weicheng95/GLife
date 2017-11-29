using GLifeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GLifeApplication.ViewModels
{
    public class SportDatabaseView
    {
        public List<SportDatabase> SportDatabaseList { get; set; }

        public List<Article> Articles { get; set; }
    }
}