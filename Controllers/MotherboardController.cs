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
    public class MotherboardController : Controller
    {
        private MagazDbContext db = new MagazDbContext();

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Get()
        {
            return View(db.Motherboard);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository.Models.Motherboard motherboard = db.Motherboard.Find(id);
            if (motherboard == null)
            {
                return HttpNotFound();
            }
            return View(motherboard);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Repository.Models.Motherboard motherboard = db.Motherboard.Find(id);
            db.Motherboard.Remove(motherboard);
            db.SaveChanges();
            return RedirectToAction("Get", "Motherboard");
        }

        public ActionResult Edit(int Id)
        {
            var memory = db.Motherboard.Where(s => s.IdMotherboard == Id).FirstOrDefault();
            return View(memory);
        }

        [HttpPost]
        public ActionResult Edit(Repository.Models.Motherboard motherboard, HttpPostedFileBase ImageFile)
        {
            var mother = db.Motherboard.Where(s => s.IdMotherboard == motherboard.IdMotherboard).FirstOrDefault();
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }

            motherboard.Image = imageData;
            db.Motherboard.Remove(mother);
            db.Motherboard.Add(motherboard);
            db.SaveChanges();

            return RedirectToAction("Get", "Motherboard");
        }



        [HttpPost]
        public ActionResult Create(Repository.Models.Motherboard motherboard, HttpPostedFileBase ImageFile)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }
            // установка массива байтов
            motherboard.Image = imageData;
            db.Motherboard.Add(motherboard);
            db.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("Get", "Motherboard");
        }
    }
}
