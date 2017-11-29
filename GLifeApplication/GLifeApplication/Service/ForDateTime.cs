using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GLifeApplication.Services
{
    public class ForDateTime
    {
        public DateTime CurrentDate { get; set; }
        public DateTime MaxDate { get; set; }

        

        public ForDateTime()
        {
            this.CurrentDate = DateTime.Today;
        }

        public ForDateTime(DateTime Date)
        {
            this.CurrentDate = Date;
        }

    }
}