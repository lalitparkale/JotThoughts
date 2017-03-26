using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JotThoughts.Controllers
{
    public class JotCardController : Controller
    {
        // GET: JotCard
        public ActionResult Index()
        {
            return View("JotCard");
        }

        public ActionResult Submit()
        {
            return View("Submit");
        }
    }
}