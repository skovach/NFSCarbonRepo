using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFSCarbonAppMvc4.Models;

namespace NFSCarbonAppMvc4.Controllers
{
    public class ReviewsController : Controller
    {
        private NFSCarbondb db = new NFSCarbondb();

        //
        // GET: /Reviews/

        public ActionResult Index([Bind(Prefix = "id")] int carId)
        {
            var car = db.Cars.Find(carId);
            if (car!=null)
            {
                return View(car);
            }
            return View(db.Reviews.ToList());
        }

        //
        // GET: /Reviews/Details/5

        public ActionResult Details(int id = 0)
        {
            CarReview carreview = db.Reviews.Find(id);
            if (carreview == null)
            {
                return HttpNotFound();
            }
            return View(carreview);
        }

        //
        // GET: /Reviews/Create

        public ActionResult Create(int carId = 0)
        {
            return View();
        }

        //
        // POST: /Reviews/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarReview carreview)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(carreview);
                db.SaveChanges();
                return RedirectToAction("Index", new{id = carreview.CarId});
            }

            return View(carreview);
        }

        //
        // GET: /Reviews/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CarReview carreview = db.Reviews.Find(id);
            if (carreview == null)
            {
                return HttpNotFound();
            }
            return View(carreview);
        }

        //
        // POST: /Reviews/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarReview carreview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carreview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new{id = carreview.CarId});
            }
            return View(carreview);
        }

        //
        // GET: /Reviews/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CarReview carreview = db.Reviews.Find(id);
            if (carreview == null)
            {
                return HttpNotFound();
            }
            return View(carreview);
        }

        //
        // POST: /Reviews/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarReview carreview = db.Reviews.Find(id);
            db.Reviews.Remove(carreview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}