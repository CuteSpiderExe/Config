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
    public class VideocardController : Controller
    {
        private MagazDbContext db = new MagazDbContext();

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Get()
        {
            return View(db.Videocard);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository.Models.Videocard videocard = db.Videocard.Find(id);
            if (videocard == null)
            {
                return HttpNotFound();
            }
            return View(videocard);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Repository.Models.Videocard videocard = db.Videocard.Find(id);
            db.Videocard.Remove(videocard);
            db.SaveChanges();
            return RedirectToAction("Get", "Videocard");
        }

        public ActionResult Edit(int Id)
        {
            var videocard = db.Videocard.Where(s => s.IdVideocard == Id).FirstOrDefault();
            return View(videocard);
        }

        [HttpPost]
        public ActionResult Edit(Repository.Models.Videocard videocard, HttpPostedFileBase ImageFile)
        {
            var proc = db.Videocard.Where(s => s.IdVideocard == videocard.IdVideocard).FirstOrDefault();
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }

            videocard.Image = imageData;
            db.Videocard.Remove(proc);
            db.Videocard.Add(videocard);
            db.SaveChanges();

            return RedirectToAction("Get", "Videocard");
        }



        [HttpPost]
        public ActionResult Create(Repository.Models.Videocard videocard, HttpPostedFileBase ImageFile)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }
            // установка массива байтов
            videocard.Image = imageData;
            db.Videocard.Add(videocard);
            db.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("Get", "Videocard");
        }
    }
}