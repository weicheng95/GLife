using GLifeApplication.Models;
using GLifeApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GLifeApplication.ViewModels
{
    public class ArticleView
    {
        [DisplayName("Search")]
        public string Search { get; set; }

        public List<Article> ArticleList { get; set; }

        public ForDateTime Date { get; set; }



    }
}