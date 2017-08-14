using ShortLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShortLink.Controllers
{
    public class HomeController : Controller
    {
        private SiteContext db = new SiteContext();

        public ActionResult Index()
        {
            var allLinks = db.Urls.OrderBy(x => x.GenerationDate);
            return View(allLinks);
        }

        [Route("{url}")]
        public ActionResult GoTo(string url)
        {
            var link = db.Urls.Where(x => x.ShortUrl == url).FirstOrDefault();
            if (link != null)
            {
                link.ClickCount += 1;
                db.SaveChanges();
                return Redirect(link.LongUrl);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult AddUrl(string longUrl)
        {
            if (!String.IsNullOrEmpty(longUrl))
            {
                var shortUrl = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("+", "").Replace("/", "").Substring(0, 5);
                if (!db.Urls.Any(x => x.ShortUrl == shortUrl))
                {
                    var link = new Url
                    {
                        LongUrl = longUrl,
                        ShortUrl = shortUrl,
                        GenerationDate = DateTime.Now
                    };
                    db.Urls.Add(link);
                    db.SaveChanges();
                    var newLink = new List<Url>();
                    newLink.Add(link);
                    return PartialView("_Links", newLink);
                }
            }
            var allLinks = db.Urls.OrderBy(x => x.GenerationDate);
            return PartialView("_Links", allLinks);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}