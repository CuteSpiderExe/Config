using Config.Models;
using Config.Repository;
using Config.Repository.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;



namespace Config.Controllers
{
    public class CorpusController : Controller
    {

        private MagazDbContext db = new MagazDbContext();
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Get()
        {
            return View(db.Corpus);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository.Models.Corpus corpus = db.Corpus.Find(id);
            if (corpus == null)
            {
                return HttpNotFound();
            }
            return View(corpus);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Repository.Models.Corpus corpus = db.Corpus.Find(id);
            db.Corpus.Remove(corpus);
            db.SaveChanges();
            return RedirectToAction("Get", "Corpus");
        }

        public ActionResult Edit(int Id)
        {
            var corp = db.Corpus.Where(s => s.IdCorpus == Id).FirstOrDefault();
            return View(corp);
        }

        [HttpPost]
        public ActionResult Edit(Repository.Models.Corpus corpus, HttpPostedFileBase ImageFile)
        {
            var corp = db.Corpus.Where(s => s.IdCorpus == corpus.IdCorpus).FirstOrDefault();
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }

            corpus.Image = imageData;
            db.Corpus.Remove(corp);
            db.Corpus.Add(corpus);
            db.SaveChanges();

            return RedirectToAction("Get", "Corpus");
        }



        [HttpPost]
        public ActionResult Create(Repository.Models.Corpus corpus, HttpPostedFileBase ImageFile)
        {
            //if (ModelState.IsValid)
            //{
            //    if (img != null)
            //    {
            //        corpus.Image = new byte[img.ContentLength];
            //        img.InputStream.Read(corpus.Image, 0, img.ContentLength);
            //    }
            //    db.Corpus.Add(corpus);
            //    db.SaveChanges();
            //}          
            byte[] imageData = null;
            // считываем переданный файл в массив байтов

            using (var binaryReader = new BinaryReader(ImageFile.InputStream))
            {
                imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
            }
            // установка массива байтов
            corpus.Image = imageData;
            db.Corpus.Add(corpus);
            db.SaveChanges();
            ModelState.Clear();

            return View();
        }
    }
}