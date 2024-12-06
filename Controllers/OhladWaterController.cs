using Config.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Config.Controllers
{
    public class OhladWaterController : Controller
    {
        private MagazDbContext db = new MagazDbContext();

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Get()
        {
            return View(db.OhladWater);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository.Models.OhladWater ohladw = db.OhladWater.Find(id);
            if (ohladw == null)
            {
                return HttpNotFound();
            }
            return View(ohladw);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Repository.Models.OhladWater ohladw = db.OhladWater.Find(id);
            db.OhladWater.Remove(ohladw);
            db.SaveChanges();
            return RedirectToAction("Get", "OhladWater");
        }

        public ActionResult Edit(int Id)
        {
            var ohladw = db.OhladWater.Where(s => s.IdOhladWater == Id).FirstOrDefault();
            return View(ohladw);
        }

        [HttpPost]
        public ActionResult Edit(Repository.Models.OhladWater ohladw, HttpPostedFileBase ImageFile)
        {
            var ohw = db.OhladWater.Where(s => s.IdOhladWater == ohladw.IdOhladWater).FirstOrDefault();
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }

            ohladw.Image = imageData;
            db.OhladWater.Remove(ohw);
            db.OhladWater.Add(ohladw);
            db.SaveChanges();

            return RedirectToAction("Get", "OhladWater");
        }



        [HttpPost]
        public ActionResult Create(Repository.Models.OhladWater ohladw, HttpPostedFileBase ImageFile)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }
            // установка массива байтов
            ohladw.Image = imageData;
            db.OhladWater.Add(ohladw);
            db.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("Get", "OhladWater");
        }
    }
}
