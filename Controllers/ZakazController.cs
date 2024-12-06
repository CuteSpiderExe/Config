using Config.Repository;
using Config.Repository.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Config.Controllers
{
    public class ZakazController : Controller
    {
        private MagazDbContext db = new MagazDbContext();

        [Authorize(Roles = "2,1")]
        public ActionResult Edit(int Id)
        {
            var zakaz = db.Zakaz.Where(s => s.IdZakaz == Id).FirstOrDefault();
            return View(zakaz);
        }

        [HttpPost]
        public ActionResult Edit(Zakaz zakaz)
        {
            var zak = db.Zakaz.Where(s => s.IdZakaz == zakaz.IdZakaz).FirstOrDefault();          

            //zakaz.Status = Request.Form["status"];
            db.Zakaz.Remove(zak);
            db.Zakaz.Add(zakaz);
            db.SaveChanges();

            return RedirectToAction("Index", "Zakaz");
        }

        public ActionResult IndexView()
        {
            List<ZakazModel> listZakazModel = new List<ZakazModel>();

            var userBD = db.User.Where(x => x.Login == User.Identity.Name).FirstOrDefault();

            var idUser = userBD.IdUser;

            var bb = db.Zakaz.ToList();
            foreach (Zakaz item in bb)
            {
                var smorka = db.Sborka.SingleOrDefault(s => s.IdSborka == item.IdSborka);
                if (smorka != null)
                {
                    item.IdSborkaNavigation = smorka;

                    var user = db.User.SingleOrDefault(s => s.IdUser == item.IdSborkaNavigation.IdUser);
                    if (user != null)
                    {
                        item.IdSborkaNavigation.IdUserNavigation = user;
                    }

                }

                if (item.IdSborkaNavigation.IdUser == idUser)
                {
                    listZakazModel.Add(new ZakazModel { zakaz = item });
                }
            }


            foreach (var item in listZakazModel)
            {
                var videoCarta = db.Videocard.SingleOrDefault(s => s.IdVideocard ==
                item.zakaz.IdSborkaNavigation.IdVideocard);

                if (videoCarta != null)
                {
                    item.Komplect += videoCarta.Name + ", ";
                }

                var cpu = db.Processor.SingleOrDefault(s => s.IdProcessor ==
               item.zakaz.IdSborkaNavigation.IdProcessor);

                if (cpu != null)
                {
                    item.Komplect += cpu.Name + ", ";
                }

                var motherboard = db.Motherboard.SingleOrDefault(s => s.IdMotherboard ==
               item.zakaz.IdSborkaNavigation.IdMotherboard);

                if (motherboard != null)
                {
                    item.Komplect += motherboard.Name + ", ";
                }

                var corpus = db.Corpus.SingleOrDefault(s => s.IdCorpus ==
               item.zakaz.IdSborkaNavigation.IdCorpus);

                if (corpus != null)
                {
                    item.Komplect += corpus.Name + ", ";
                }

                var ddr = db.Ddr.SingleOrDefault(s => s.IdDdr ==
               item.zakaz.IdSborkaNavigation.IdDdr);

                if (ddr != null)
                {
                    item.Komplect += ddr.Name + ", ";
                }

                var memory = db.Memory.SingleOrDefault(s => s.IdMemory ==
               item.zakaz.IdSborkaNavigation.IdMemory);

                if (memory != null)
                {
                    item.Komplect += memory.Name + ", ";
                }

                var ohlad = db.Ohlad.SingleOrDefault(s => s.IdOhlad ==
               item.zakaz.IdSborkaNavigation.IdOhlad);

                if (ohlad != null)
                {
                    item.Komplect += ohlad.Name + ", ";
                }

                var ohladwater = db.OhladWater.SingleOrDefault(s => s.IdOhladWater ==
               item.zakaz.IdSborkaNavigation.IdOhladWater);

                if (ohladwater != null)
                {
                    item.Komplect += ohladwater.Name + ", ";
                }

                var power = db.PowerBlock.SingleOrDefault(s => s.IdPowerblock ==
               item.zakaz.IdSborkaNavigation.IdPowerblock);

                if (power != null)
                {
                    item.Komplect += power.Name + ", ";
                }


                item.Komplect = item.Komplect.TrimEnd(' ').TrimEnd(',');
            }



            return View(listZakazModel);
        }

            // GET: Zakaz
            [Authorize(Roles = "2")]
        public ActionResult Index()
        {
            List<ZakazModel> listZakazModel = new List<ZakazModel>();

            

            var bb = db.Zakaz.ToList();
            foreach (Zakaz item in bb)
            {
                var smorka = db.Sborka.SingleOrDefault(s => s.IdSborka == item.IdSborka);
                if (smorka != null)
                {
                    item.IdSborkaNavigation = smorka;

                    var user = db.User.SingleOrDefault(s => s.IdUser == item.IdSborkaNavigation.IdUser);
                    if (user != null)
                    {
                        item.IdSborkaNavigation.IdUserNavigation = user;
                    }

                }

                listZakazModel.Add(new ZakazModel { zakaz = item });
            }
            

            foreach (var item in listZakazModel)
            {
                var videoCarta = db.Videocard.SingleOrDefault(s => s.IdVideocard ==
                item.zakaz.IdSborkaNavigation.IdVideocard);

                if(videoCarta != null)
                {
                    item.Komplect += videoCarta.Name + ", ";
                }

                var cpu = db.Processor.SingleOrDefault(s => s.IdProcessor ==
               item.zakaz.IdSborkaNavigation.IdProcessor);

                if (cpu != null)
                {
                    item.Komplect += cpu.Name + ", ";
                }

                var motherboard = db.Motherboard.SingleOrDefault(s => s.IdMotherboard ==
               item.zakaz.IdSborkaNavigation.IdMotherboard);

                if (motherboard != null)
                {
                    item.Komplect += motherboard.Name + ", ";
                }

                var corpus = db.Corpus.SingleOrDefault(s => s.IdCorpus ==
               item.zakaz.IdSborkaNavigation.IdCorpus);

                if (corpus != null)
                {
                    item.Komplect += corpus.Name + ", ";
                }

                var ddr = db.Ddr.SingleOrDefault(s => s.IdDdr ==
               item.zakaz.IdSborkaNavigation.IdDdr);

                if (ddr != null)
                {
                    item.Komplect += ddr.Name + ", ";
                }

                var memory = db.Memory.SingleOrDefault(s => s.IdMemory ==
               item.zakaz.IdSborkaNavigation.IdMemory);

                if (memory != null)
                {
                    item.Komplect += memory.Name + ", ";
                }

                var ohlad = db.Ohlad.SingleOrDefault(s => s.IdOhlad ==
               item.zakaz.IdSborkaNavigation.IdOhlad);

                if (ohlad != null)
                {
                    item.Komplect += ohlad.Name + ", ";
                }

                var ohladwater = db.OhladWater.SingleOrDefault(s => s.IdOhladWater ==
               item.zakaz.IdSborkaNavigation.IdOhladWater);

                if (ohladwater != null)
                {
                    item.Komplect += ohladwater.Name + ", ";
                }

                var power = db.PowerBlock.SingleOrDefault(s => s.IdPowerblock ==
               item.zakaz.IdSborkaNavigation.IdPowerblock);

                if (power != null)
                {
                    item.Komplect += power.Name + ", ";
                }

                item.Komplect = item.Komplect.TrimEnd(' ').TrimEnd(',');
            }



            return View(listZakazModel);
        }
        [Authorize(Roles = "2,1")]
        public ActionResult About()
        {
            return View();
        }

        [Authorize(Roles = "2,1")]
        public ActionResult Zakazadd()
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
            //sborka.Name = "";


            var currentUserId = db.User.Where(x => x.Login == User.Identity.Name).Select(x => x.IdUser).FirstOrDefault();
            sborka.IdUser = currentUserId;


            var sboName = "";

            sborka.Name = sboName;
            sborka.ZakazSborki = true;

            db.Sborka.Add(sborka);
            db.SaveChanges();


            Zakaz zakaz = new Zakaz();
            DateTime date = DateTime.Now;
            zakaz.IdSborka = sborka.IdSborka;
            zakaz.Status = "В обработке";
            zakaz.Date = DateTime.Parse(date.ToString("d"));
            zakaz.Adress = Request.Form["Adres"];
            db.Zakaz.Add(zakaz);
            db.SaveChanges();

            return RedirectToAction("Index", "Basket");
        }
    }
}