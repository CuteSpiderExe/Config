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
    public class OhladController : Controller
    {
        private MagazDbContext db = new MagazDbContext();

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Get()
        {
            return View(db.Ohlad);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository.Models.Ohlad ohlad = db.Ohlad.Find(id);
            if (ohlad == null)
            {
                return HttpNotFound();
            }
            return View(ohlad);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Repository.Models.Ohlad ohlad = db.Ohlad.Find(id);
            db.Ohlad.Remove(ohlad);
            db.SaveChanges();
            return RedirectToAction("Get", "Ohlad");
        }

        public ActionResult Edit(int Id)
        {
            var ohlad = db.Ohlad.Where(s => s.IdOhlad == Id).FirstOrDefault();
            return View(ohlad);
        }

        [HttpPost]
        public ActionResult Edit(Repository.Models.Ohlad ohlad, HttpPostedFileBase ImageFile)
        {
            var oh = db.Ohlad.Where(s => s.IdOhlad == ohlad.IdOhlad).FirstOrDefault();
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }

            ohlad.Image = imageData;
            db.Ohlad.Remove(oh);
            db.Ohlad.Add(ohlad);
            db.SaveChanges();

            return RedirectToAction("Get", "Ohlad");
        }



        [HttpPost]
        public ActionResult Create(Repository.Models.Ohlad ohlad, HttpPostedFileBase ImageFile)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }
            // установка массива байтов
            ohlad.Image = imageData;
            db.Ohlad.Add(ohlad);
            db.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("Get", "Ohlad");
        }
    }
}