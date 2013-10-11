using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using NFSCarbonAppMvc4.Models;
using PagedList;

namespace NFSCarbonAppMvc4.Controllers
{
    
    public class HomeController : Controller
    {
        INFSCarbondb _db;

        public HomeController()
        {
            _db = new NFSCarbondb();
        }

        public HomeController(INFSCarbondb db)
        {
            _db = db;
        }

        public ActionResult Autocomplete(string term)
        {
            var model = _db.Query<Car>()
                           .Where(c => c.Vendor.StartsWith(term))
                           .Select(c => new {label = c.Vendor});
            return Json(model, JsonRequestBehavior.AllowGet);
        }



        [OutputCache(CacheProfile = "Long", VaryByHeader = "X-Requested-With; Accept-Language", Location = OutputCacheLocation.Server)]
        public ActionResult Index(string searchTerm = null, int page = 1)
        {

            var greeting = NFSCarbonAppMvc4.Views.Home.Resources.Greeting;

            var model = from c in _db.Query<Car>()
                         orderby c.Price
                         where (searchTerm == null || c.Vendor.StartsWith(searchTerm))
                         select new CarlistViewModel
                             {

                                 Id = c.Id,
                                 Name = c.Name,
                                 Vendor = c.Vendor,
                                 Info = c.CarInfo,
                                 RatingCount = c.CarReview.Count(),
                                 Price = c.Price,
                                 Type = c.Type,
                                 AvgRating = c.CarReview.Average(rating => rating.Rating)
                             };

            ICollection<CarlistViewModel> models = model.ToList();
            foreach (var item in models)
            {
                item.ImagePath = (from i in _db.Query<Image>()
                                  where (item.Id == i.CarId)
                                  select i.ImagePath).ToList();
                item.AvgRating = Math.Round(item.AvgRating, 2);

            }
            var modelsInPages = models.ToPagedList(page, 2);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Cars", modelsInPages);
            }

            ViewBag.QSearch = ConfigurationManager.AppSettings["QSearch"];

            return View(modelsInPages);
        }


        public ActionResult About()
        {

            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if(_db != null) _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
