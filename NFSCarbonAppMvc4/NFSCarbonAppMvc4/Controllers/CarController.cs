using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFSCarbonAppMvc4.Models;
using System.IO;

namespace NFSCarbonAppMvc4.Controllers
{
    public class CarController : Controller
    {
        private NFSCarbondb db = new NFSCarbondb();

        //
        // GET: /Car/

        public ActionResult Index()
        {
            var imageList = from i in db.Images
                select i.ImagePath;
                            
            return View(imageList);
        }

        //
        // GET: /Car/Details/5

        public ActionResult Details(int id = 0)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        //
        // GET: /Car/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Car/Create

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("UploadImage");
        }

        public ActionResult UploadImage(HttpPostedFileBase image, int id = 0)
        {
            if (image != null)
            {
                string imageName = Path.GetFileName(image.FileName);
                string path = Path.Combine(Server.MapPath("~/content/Images"), imageName);
                image.SaveAs(path);
                db.Images.Add(new Image{CarId = id,ImagePath = imageName});
                db.SaveChanges();
            }

            return View();
        }

        //
        // GET: /Car/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        //
        // POST: /Car/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        //
        // GET: /Car/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        //
        // POST: /Car/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
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