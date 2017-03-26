using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jot.Models;

namespace Jot.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home
        public ActionResult Card(CardPropertyModel cpm)
        {
            if (ModelState.IsValid)
            {
                if ((cpm.maxJotLength > CardPropertyModel.ultimateJotLength) || (cpm.maxJotLength==0))
                {
                    cpm.maxJotLength = CardPropertyModel.ultimateJotLength;
                }

                cpm.ReferrerURL = Request.UrlReferrer.AbsoluteUri;
                return View("Card", cpm);
            }

            return View("Card");
        }
    }
}