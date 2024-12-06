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
    public class ProcessorController : Controller
    {
        private MagazDbContext db = new MagazDbContext();

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Get()
        {
            return View(db.Processor);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository.Models.Processor processor = db.Processor.Find(id);
            if (processor == null)
            {
                return HttpNotFound();
            }
            return View(processor);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Repository.Models.Processor processor = db.Processor.Find(id);
            db.Processor.Remove(processor);
            db.SaveChanges();
            return RedirectToAction("Get", "Processor");
        }

        public ActionResult Edit(int Id)
        {
            var processor = db.Processor.Where(s => s.IdProcessor == Id).FirstOrDefault();
            return View(processor);
        }

        [HttpPost]
        public ActionResult Edit(Repository.Models.Processor processor, HttpPostedFileBase ImageFile)
        {
            var proc = db.Processor.Where(s => s.IdProcessor == processor.IdProcessor).FirstOrDefault();
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }

            processor.Image = imageData;
            db.Processor.Remove(proc);
            db.Processor.Add(processor);
            db.SaveChanges();

            return RedirectToAction("Get", "Processor");
        }



        [HttpPost]
        public ActionResult Create(Repository.Models.Processor processor, HttpPostedFileBase ImageFile)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }
            // установка массива байтов
            processor.Image = imageData;
            db.Processor.Add(processor);
            db.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("Get", "Processor");
        }
    }
}