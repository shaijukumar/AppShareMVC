using AppShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppShare.Controllers
{
    public class pController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: p
        public ActionResult Index(string title)
        {
            if (String.IsNullOrWhiteSpace(title))
            {
                title = "Home";
            }

            SiteContent pageTempalte = db.SiteContents.SingleOrDefault(c => c.TitleURL == "PageTeplate");
            if (pageTempalte == null)
                return HttpNotFound();

            SiteContent pageContent = db.SiteContents.SingleOrDefault(c => c.TitleURL == title);
            if (pageContent == null)
                return HttpNotFound();

            pageTempalte.DocumentHTML = pageTempalte.DocumentHTML.Replace("##PageTitle##", pageContent.Title );
            pageTempalte.DocumentHTML = pageTempalte.DocumentHTML.Replace("##PageContent##", pageContent.DocumentHTML);

            return Content(pageTempalte.DocumentHTML );
            
        }
               
    }
}
