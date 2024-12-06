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
    public class PowerBlockController : Controller
    {
        private MagazDbContext db = new MagazDbContext();

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Get()
        {
            return View(db.PowerBlock);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository.Models.PowerBlock powerblock = db.PowerBlock.Find(id);
            if (powerblock == null)
            {
                return HttpNotFound();
            }
            return View(powerblock);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Repository.Models.PowerBlock powerblock = db.PowerBlock.Find(id);
            db.PowerBlock.Remove(powerblock);
            db.SaveChanges();
            return RedirectToAction("Get", "PowerBlock");
        }

        public ActionResult Edit(int Id)
        {
            var power = db.PowerBlock.Where(s => s.IdPowerblock == Id).FirstOrDefault();
            return View(power);
        }

        [HttpPost]
        public ActionResult Edit(Repository.Models.PowerBlock powerblock, HttpPostedFileBase ImageFile)
        {
            var pow = db.PowerBlock.Where(s => s.IdPowerblock == powerblock.IdPowerblock).FirstOrDefault();
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }

            powerblock.Image = imageData;
            db.PowerBlock.Remove(pow);
            db.PowerBlock.Add(powerblock);
            db.SaveChanges();

            return RedirectToAction("Get", "PowerBlock");
        }



        [HttpPost]
        public ActionResult Create(Repository.Models.PowerBlock powerblock, HttpPostedFileBase ImageFile)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }
            // установка массива байтов
            powerblock.Image = imageData;
            db.PowerBlock.Add(powerblock);
            db.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("Get", "PowerBlock");
        }
    }
}