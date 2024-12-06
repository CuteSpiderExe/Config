using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Config.Repository.Models
{
    public class Builder
    {
        public IEnumerable<Corpus> Corpus { get; set; }
        public IEnumerable<Processor> Processors { get; set; }
        public IEnumerable<Ddr> Ddrs { get; set; }
        public IEnumerable<Memory> Memorys { get; set; }
        public IEnumerable<Motherboard> Motherboards { get; set; }
        public IEnumerable<Ohlad> Ohlads { get; set; }
        public IEnumerable<OhladWater> OhladWaters { get; set; }
        public IEnumerable<PowerBlock> PowerBlocks { get; set; }
        public IEnumerable<Videocard> Videocards { get; set; }
    }
}