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
    public class DDRController : Controller
    {
        private MagazDbContext db = new MagazDbContext();

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Get()
        {
            return View(db.Ddr);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository.Models.Ddr ddr = db.Ddr.Find(id);
            if (ddr == null)
            {
                return HttpNotFound();
            }
            return View(ddr);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Repository.Models.Ddr ddr = db.Ddr.Find(id);
            db.Ddr.Remove(ddr);
            db.SaveChanges();
            return RedirectToAction("Get", "DDR");
        }

        public ActionResult Edit(int Id)
        {
            var ddr = db.Ddr.Where(s => s.IdDdr == Id).FirstOrDefault();
            return View(ddr);
        }

        [HttpPost]
        public ActionResult Edit(Repository.Models.Ddr ddr, HttpPostedFileBase ImageFile)
        {
            var dr = db.Ddr.Where(s => s.IdDdr == ddr.IdDdr).FirstOrDefault();
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }

            ddr.Image = imageData;
            db.Ddr.Remove(dr);
            db.Ddr.Add(ddr);
            db.SaveChanges();

            return RedirectToAction("Get", "DDR");
        }



        [HttpPost]
        public ActionResult Create(Repository.Models.Ddr ddr, HttpPostedFileBase ImageFile)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }
            // установка массива байтов
            ddr.Image = imageData;
            db.Ddr.Add(ddr);
            db.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("Get", "DDR");
        }
    }
}