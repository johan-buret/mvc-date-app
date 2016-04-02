using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace Mvc_date_app.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(DateTime? date)
        {
            if (!date.HasValue) { date = DateTime.Now; }
            return View(date);
        }
    }
}