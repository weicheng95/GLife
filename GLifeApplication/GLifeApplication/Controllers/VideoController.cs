using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GLifeApplication.Controllers
{
    public class VideoController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }
    }
}