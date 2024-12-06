using Config.Models;
using Config.Repository;
using Config.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sborka = Config.Repository.Models.Sborka;

namespace Config.Controllers
{
    public class BasketController : Controller
    {
        //GET: Basket
        [Authorize(Roles = "2,1")]
        public ActionResult Index()
        {
            return View(new KorzinaView(User.Identity.Name));
        }
        
        public ActionResult Clear()
        {
            Korzina.memoryKorzina = null;
            Korzina.videocardKorzina = null;
            Korzina.powerBlockKorzina = null;
            Korzina.processorKorzina = null;
            Korzina.motherboardKorzina = null;
            Korzina.ddrKorzina = null;
            Korzina.ohladKorzina = null;
            Korzina.ohladwaterKorzina = null;
            Korzina.corpusKorzina = null;
            return RedirectToAction("Index", "Basket");
        }


        public ActionResult Loading()
        {            
            var IdSborka =  Request.Form["selectSborka"];
            if(IdSborka=="-1")
            {                
                return RedirectToAction("Index", "Basket");
            }

            Korzina.memoryKorzina = null;
            Korzina.videocardKorzina = null;
            Korzina.powerBlockKorzina = null;
            Korzina.processorKorzina = null;
            Korzina.motherboardKorzina = null;
            Korzina.ddrKorzina = null;
            Korzina.ohladKorzina = null;
            Korzina.ohladwaterKorzina = null;
            Korzina.corpusKorzina = null;

            int intSborka = int.Parse(IdSborka);
            MagazDbContext db = new MagazDbContext();
            var sborka = db.Sborka.Single(s=>s.IdSborka== intSborka);
            
            if (sborka.IdVideocard!=null)
            {
                Korzina.videocardKorzina = db.Videocard.Single(s => s.IdVideocard == sborka.IdVideocard);
            }

            if (sborka.IdPowerblock != null)
            {
                Korzina.powerBlockKorzina = db.PowerBlock.Single(s => s.IdPowerblock == sborka.IdPowerblock);
            }

            if (sborka.IdProcessor != null)
            {
                Korzina.processorKorzina = db.Processor.Single(s => s.IdProcessor == sborka.IdProcessor);
            }

            if (sborka.IdMotherboard != null)
            {
                Korzina.motherboardKorzina = db.Motherboard.Single(s => s.IdMotherboard == sborka.IdMotherboard);
            }

            if (sborka.IdMemory != null)
            {
                Korzina.memoryKorzina = db.Memory.Single(s => s.IdMemory == sborka.IdMemory);
            }

            if (sborka.IdDdr != null)
            {
                Korzina.ddrKorzina = db.Ddr.Single(s => s.IdDdr == sborka.IdDdr);
            }

            if (sborka.IdOhladWater != null)
            {
                Korzina.ohladwaterKorzina= db.OhladWater.Single(s => s.IdOhladWater == sborka.IdOhladWater);
            }

            if (sborka.IdOhlad != null)
            {
                Korzina.ohladKorzina = db.Ohlad.Single(s => s.IdOhlad == sborka.IdOhlad);
            }

            if (sborka.IdCorpus != null)
            {
                Korzina.corpusKorzina = db.Corpus.Single(s => s.IdCorpus == sborka.IdCorpus);
            }          
            return RedirectToAction("Index", "Basket");
        }

            public ActionResult Save()
        {

            MagazDbContext db = new MagazDbContext();
            var korzinaView = new KorzinaView(User.Identity.Name);

            int quantity = 0;
            //Korzina

            Sborka sborka = new Sborka();

            if (Korzina.processorKorzina != null)
            {
                sborka.IdProcessor = Korzina.processorKorzina.IdProcessor;
                quantity++;
            }
            if (Korzina.motherboardKorzina != null)
            {
                sborka.IdMotherboard = Korzina.motherboardKorzina.IdMotherboard;
                quantity++;
            }

            if (Korzina.corpusKorzina != null)
            {
                sborka.IdCorpus = Korzina.corpusKorzina.IdCorpus;
                quantity++;
            }

            if (Korzina.ohladKorzina != null)
            {
                sborka.IdOhlad = Korzina.ohladKorzina.IdOhlad;
                quantity++;
            }

            if (Korzina.ohladwaterKorzina != null)
            {
                sborka.IdOhladWater = Korzina.ohladwaterKorzina.IdOhladWater;
                quantity++;
            }

            if (Korzina.ddrKorzina != null)
            {
                sborka.IdDdr = Korzina.ddrKorzina.IdDdr;
                quantity++;
            }

            if (Korzina.memoryKorzina != null)
            {
                sborka.IdMemory = Korzina.memoryKorzina.IdMemory;
                quantity++;
            }

            if (Korzina.powerBlockKorzina != null)
            {
                sborka.IdPowerblock = Korzina.powerBlockKorzina.IdPowerblock;
                quantity++;
            }

            if (Korzina.videocardKorzina != null)
            {
                sborka.IdVideocard = Korzina.videocardKorzina.IdVideocard;
                quantity++;
            }

            sborka.Quantity = quantity;
            sborka.Cost = korzinaView.AllCost;
            sborka.Name = "";

            
            var currentUserId = db.User.Where(x => x.Login == User.Identity.Name).Select(x => x.IdUser).FirstOrDefault();
            sborka.IdUser = currentUserId;

            var sboName = Request.Form["NameSborka"];
            sborka.Name = sboName;

            db.Sborka.Add(sborka);
            db.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("Index", "Basket");
        }
    }
}