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

        // 
        public ActionResult Card(CardPropertyModel cpm)
        {
            if (ModelState.IsValid)
            {
                if ((cpm.maxJotLength > CardPropertyModel.ultimateJotLength) || (cpm.maxJotLength == 0))
                {
                    cpm.maxJotLength = CardPropertyModel.ultimateJotLength;
                }

                if (null != Request.UrlReferrer)
                    cpm.ReferrerURL = Request.UrlReferrer.AbsoluteUri;

                TempData["CardAttributes"] = cpm;

                return View("Card", cpm);
            }

            return View("Card");
        }

        // 
        [HttpPost]
        public ActionResult JotDown(JotCardModel jcm)
        {
            int returnCode = 0;
            CardPropertyModel cp = new CardPropertyModel();

            if (ModelState.IsValid)
            {
                //validate that jot info is not more that the specified ultimate length
                if (jcm.jottedThought.Length > CardPropertyModel.ultimateJotLength)
                {
                    jcm.jottedThought = jcm.jottedThought.Remove(CardPropertyModel.ultimateJotLength);
                }

                if (null != Request.UrlReferrer)
                    jcm.ReferrerURL = Request.UrlReferrer.AbsoluteUri;

                cp = TempData.Peek("CardAttributes") as CardPropertyModel;

                try
                {
                    using (var db = new JotContext())
                    {
                        // Create and save a new Jot 
                        var jot = new JotCardModel();
                        jot.CardAttributes = cp;
                        jot.contactConsent = jcm.contactConsent;
                        jot.contactEmail = jcm.contactEmail;
                        jot.contactPhone = jcm.contactPhone;
                        jot.Created = DateTime.UtcNow;
                        jot.jottedThought = jcm.jottedThought;
                        jot.ReferrerContext = jcm.ReferrerContext;
                        jot.ReferrerURL = jcm.ReferrerURL;

                        db.JotCards.Add(jot);
                        db.SaveChanges();
                    }

                    returnCode = 1;
                }
                catch(Exception ex)
                {
                    Response.AppendToLog("JotDown() exception : " + ex.ToString());
                    Console.WriteLine("JotDown() exception : " + ex.ToString());

                    returnCode = -1;
                }
            }
            else
            {
                returnCode = -2;
            }

            ViewData["returnCode"] = returnCode;
            return View("Card", cp);
        }
    }
}