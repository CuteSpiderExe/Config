using Config.Repository;
using Config.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Config.Controllers
{
    public class PcBuilderController : Controller
    {
        private MagazDbContext db = new MagazDbContext();
        // GET: PcBuilder
        [Authorize(Roles = "2,1")]
        public ActionResult Index()
        {
            var corpus = db.Corpus.ToList();
            var processors = db.Processor.ToList();
            var ddrs = db.Ddr.ToList();
            var memories = db.Memory.ToList();
            var motherboards = db.Motherboard.ToList();
            var ohlads = db.Ohlad.ToList();
            var ohladswater = db.OhladWater.ToList();
            var powerBlocks = db.PowerBlock.ToList();
            var videocards = db.Videocard.ToList();
            var model = new Builder { Corpus = corpus, Processors = processors, Ddrs = ddrs, Memorys = memories, Motherboards = motherboards, Ohlads = ohlads, OhladWaters= ohladswater, PowerBlocks = powerBlocks, Videocards = videocards };
            return View(model);
        }
        [HttpPost]
        public ActionResult AddToBuildVideokarta()
        {
            int id = int.Parse(Request.Form["id"]);

            var VK = db.Videocard.SingleOrDefault(s => s.IdVideocard == id);
            if (VK != null)
            {
                Korzina.videocardKorzina = VK;
            }

            return Redirect("~/Basket/Index");

        }

        [HttpPost]
        public ActionResult AddToBuildPowerblock()
        {
            int id = int.Parse(Request.Form["id"]);

            var VK = db.PowerBlock.SingleOrDefault(s => s.IdPowerblock == id);
            if (VK != null)
            {
                Korzina.powerBlockKorzina = VK;
            }

            return Redirect("~/Basket/Index");
        }

        [HttpPost]
        public ActionResult AddToBuildProcessor()
        {
            int id = int.Parse(Request.Form["id"]);

            var VK = db.Processor.SingleOrDefault(s => s.IdProcessor == id);
            if (VK != null)
            {
                Korzina.processorKorzina = VK;
            }

            return Redirect("~/Basket/Index");
        }

        [HttpPost]
        public ActionResult AddToBuildMotherboard()
        {
            int id = int.Parse(Request.Form["id"]);

            var VK = db.Motherboard.SingleOrDefault(s => s.IdMotherboard == id);
            if (VK != null)
            {
                Korzina.motherboardKorzina = VK;
            }

            return Redirect("~/Basket/Index");
        }

        [HttpPost]
        public ActionResult AddToBuildDdr()
        {
            int id = int.Parse(Request.Form["id"]);

            var VK = db.Ddr.SingleOrDefault(s => s.IdDdr == id);
            if (VK != null)
            {
                Korzina.ddrKorzina = VK;
            }

            return Redirect("~/Basket/Index");
        }

        [HttpPost]
        public ActionResult AddToBuildMemory()
        {
            int id = int.Parse(Request.Form["id"]);

            var VK = db.Memory.SingleOrDefault(s => s.IdMemory == id);
            if (VK != null)
            {
                Korzina.memoryKorzina = VK;
            }

            return Redirect("~/Basket/Index");
        }

        [HttpPost]
        public ActionResult AddToBuildOhlad()
        {
            int id = int.Parse(Request.Form["id"]);

            var VK = db.Ohlad.SingleOrDefault(s => s.IdOhlad == id);
            if (VK != null)
            {
                Korzina.ohladKorzina = VK;
                Korzina.ohladwaterKorzina = null;
            }

            return Redirect("~/Basket/Index");
        }

        [HttpPost]
        public ActionResult AddToBuildOhladWater()
        {
            int id = int.Parse(Request.Form["id"]);

            var VK = db.OhladWater.SingleOrDefault(s => s.IdOhladWater == id);
            if (VK != null)
            {
                Korzina.ohladwaterKorzina = VK;
                Korzina.ohladKorzina = null;
            }

            return Redirect("~/Basket/Index");
        }

        [HttpPost]
        public ActionResult AddToBuildCorpus()
        {
            int id = int.Parse(Request.Form["id"]);

            var VK = db.Corpus.SingleOrDefault(s => s.IdCorpus == id);
            if (VK != null)
            {
                Korzina.corpusKorzina = VK;
            }

            return Redirect("~/Basket/Index");
        }

        public ActionResult viewvideo()
        {
            var videocards = db.Videocard.ToList();
            var model = new Builder { Videocards = videocards };
            return View(model);
        }

        public ActionResult viewprocessor()
        {
            var processors = db.Processor.ToList();
            var model = new Builder { Processors = processors };
            return View(model);
        }
        public ActionResult viewmotherboard()
        {
            var motherboards = db.Motherboard.ToList();
            var model = new Builder { Motherboards = motherboards };
            return View(model);
        }
        public ActionResult viewpowerblock()
        {
            var powerblocks = db.PowerBlock.ToList();
            var model = new Builder { PowerBlocks = powerblocks };
            return View(model);
        }
        public ActionResult viewddr()
        {
            var ddrs = db.Ddr.ToList();
            var model = new Builder { Ddrs = ddrs };
            return View(model);
        }
        public ActionResult viewohlad()
        {
            var ohlads = db.Ohlad.ToList();
            var model = new Builder { Ohlads = ohlads };
            return View(model);
        }
        public ActionResult viewohladwater()
        {
            var ohladwaters = db.OhladWater.ToList();
            var model = new Builder { OhladWaters = ohladwaters };
            return View(model);
        }
        public ActionResult viewmemory()
        {
            var memorys = db.Memory.ToList();
            var model = new Builder { Memorys = memorys };
            return View(model);
        }
        public ActionResult viewcorpus()
        {
            var corpuss = db.Corpus.ToList();
            var model = new Builder { Corpus = corpuss };
            return View(model);
        }
    }
}