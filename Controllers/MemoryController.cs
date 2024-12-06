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
    public class MemoryController : Controller
    {
        private MagazDbContext db = new MagazDbContext();

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Get()
        {
            return View(db.Memory);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository.Models.Memory memory = db.Memory.Find(id);
            if (memory == null)
            {
                return HttpNotFound();
            }
            return View(memory);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Repository.Models.Memory memory = db.Memory.Find(id);
            db.Memory.Remove(memory);
            db.SaveChanges();
            return RedirectToAction("Get", "Memory");
        }

        public ActionResult Edit(int Id)
        {
            var memory = db.Memory.Where(s => s.IdMemory == Id).FirstOrDefault();
            return View(memory);
        }

        [HttpPost]
        public ActionResult Edit(Repository.Models.Memory memory, HttpPostedFileBase ImageFile)
        {
            var mem = db.Memory.Where(s => s.IdMemory == memory.IdMemory).FirstOrDefault();
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }

            memory.Image = imageData;
            db.Memory.Remove(mem);
            db.Memory.Add(memory);
            db.SaveChanges();

            return RedirectToAction("Get", "Memory");
        }



        [HttpPost]
        public ActionResult Create(Repository.Models.Memory memory, HttpPostedFileBase ImageFile)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }
            // установка массива байтов
            memory.Image = imageData;
            db.Memory.Add(memory);
            db.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("Get", "Memory");
        }
    }
}
