using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace Config.Repository.Models
{
    public class KorzinaView
    {
        public Videocard videocardKorzina { get; set; }
        public PowerBlock powerBlockKorzina { get; set; }
        public Processor processorKorzina { get; set; }
        public Motherboard motherboardKorzina { get; set; }
        public Memory memoryKorzina { get; set; }
        public Ddr ddrKorzina { get; set; }
        public Ohlad ohladKorzina { get; set; }
        public OhladWater ohladwaterKorzina { get; set; }
        public Corpus corpusKorzina { get; set; }

        public string ErrorVideocard { get; set; }
        public string ErrorPowerBlock { get; set; }
        public string ErrorProcessor { get; set; }
        public string ErrorMotherboard { get; set; }
        public string ErrorMemory { get; set; }
        public string ErrorDdr { get; set; }
        public string ErrorOhlad { get; set; }
        public string ErrorCorpus { get; set; }

        public string ErrorProcessorDdr { get; set; }
        public string ErrorDdrProcessor { get; set; }
        public string ErrorMotherboardDdr { get; set; }
        public string ErrorDdrMotherboard { get; set; }
        public string ErrorOhladProcessor { get; set; }
        public string ErrorProcessorOhlad { get; set; }
        public string ErrorOhladWaterProcessor { get; set; }
        public string ErrorProcessorOhladWater { get; set; }
        public string ErrorMemoryMotherboard { get; set; }
        public string ErrorMotherboardMemory { get; set; }
        public string ErrorProcessorOhladSocket { get; set; }
        public string ErrorOhladProcessorSocket { get; set; }
        public string ErrorProcessorOhladWaterSocket { get; set; }
        public string ErrorOhladWaterProcessorSocket { get; set; }
        public string ErrorOhladDuo { get; set; }
        public string ErrorVideoCorpus { get; set; }
        public string ErrorCorpusVideo { get; set; }
        public string ErrorPowerblockCorpus { get; set; }
        public string ErrorCorpusPowerblock { get; set; }
        public string ErrorMotherCorpus { get; set; }
        public string ErrorCorpusMother { get; set; }
        public string ErrorOhladCorpus { get; set; }
        public string ErrorCorpusOhlad { get; set; }
        public string ErrorOhladWaterCorpus { get; set; }
        public string ErrorCorpusOhladWater { get; set; }

        public decimal AllCost { get; set; }

        public List<Tuple<string,string>> ListSborki = new List<Tuple<string,string>>();

        public KorzinaView(string user ="")
        {
            MagazDbContext db = new MagazDbContext();
            var currentUserId = db.User.Where(x => x.Login == user).Select(x => x.IdUser).FirstOrDefault();

            var AllSborki = db.Sborka.Where(w => w.IdUser == currentUserId && w.ZakazSborki!=true).ToList();

            foreach (Sborka sborka in AllSborki )
            {
                ListSborki.Add(new Tuple<string, string>(sborka.Name != null ? sborka.Name : sborka.IdSborka.ToString(),
                    sborka.IdSborka.ToString()));
            }

            videocardKorzina = Korzina.videocardKorzina;
            powerBlockKorzina = Korzina.powerBlockKorzina;
            processorKorzina = Korzina.processorKorzina;
            motherboardKorzina = Korzina.motherboardKorzina;
            memoryKorzina = Korzina.memoryKorzina;
            ddrKorzina = Korzina.ddrKorzina;
            ohladKorzina = Korzina.ohladKorzina;
            ohladwaterKorzina = Korzina.ohladwaterKorzina;
            corpusKorzina = Korzina.corpusKorzina;

            if (videocardKorzina != null)
            {
                AllCost += videocardKorzina.Cost;
            }
            if (powerBlockKorzina != null)
            {
                AllCost += powerBlockKorzina.Cost;
            }
            if (processorKorzina != null)
            {
                AllCost += processorKorzina.Cost;
            }
            if (motherboardKorzina != null)
            {
                AllCost += motherboardKorzina.Cost;
            }
            if (memoryKorzina != null)
            {
                AllCost += memoryKorzina.Cost;
            }
            if (ddrKorzina != null)
            {
                AllCost += ddrKorzina.Cost;
            }
            if (ohladKorzina != null)
            {
                AllCost += ohladKorzina.Cost;
            }
            if (ohladwaterKorzina != null)
            {
                AllCost += ohladwaterKorzina.Cost;
            }
            if (corpusKorzina != null)
            {
                AllCost += corpusKorzina.Cost;
            }
            //Проверка мощности бп и видеокарты
            if (videocardKorzina != null && powerBlockKorzina != null)
            {
                if (powerBlockKorzina.Power < videocardKorzina.Power)
                {
                    ErrorVideocard = "Не достаточно мощности у блока питания";
                    ErrorPowerBlock = "Не достаточно мощности для видеокарты";
                }
            }
            //Проверка материнки и процессора
            if (processorKorzina != null && motherboardKorzina != null)
            {
                if (processorKorzina.Socket != motherboardKorzina.Socket)
                {
                    ErrorProcessor = "Сокет процессора не подходит к данной материнской платы";
                    ErrorMotherboard = "Сокет материнской платы не подходит к данному процессору";
                }
            }
            //Проверка охлаждения и процессора
            if (processorKorzina != null && ohladKorzina != null)
            {
                if (processorKorzina.Tdp > ohladKorzina.Tdp)
                {
                    ErrorProcessorOhlad = "Для выбранного процессора недостаточно мощное охлаждение";
                    ErrorOhladProcessor = "Выбрано недостаточно мощное охлаждение";
                }
            }

            //Проверка сокета процессора и охлаждения 
            if (processorKorzina != null && ohladKorzina != null)
            {
                if (processorKorzina.Socket != ohladKorzina.Socket)
                {
                    ErrorProcessorOhladSocket = "Для выбранного процесора не подходит сокет системы охлаждения";
                    ErrorOhladProcessorSocket = "Выбранная система охлаждения не подходит к сокету процессора";
                }
            }

            //Проверка водяной системы охлаждения и процессора
            if (processorKorzina != null && ohladwaterKorzina != null)
            {
                if (processorKorzina.Tdp > ohladwaterKorzina.Tdp)
                {
                    ErrorProcessorOhladWater = "Для выбранного процессора недостаточно мощное охлаждение";
                    ErrorOhladWaterProcessor = "Выбрано недостаточно мощное охлаждение";
                }
            }

            //Проверка сокета процессора и водяной системы охлаждения 
            if (processorKorzina != null && ohladwaterKorzina != null)
            {
                if (processorKorzina.Socket != ohladwaterKorzina.Socket)
                {
                    ErrorProcessorOhladWaterSocket = "Для выбранного процесора не подходит сокет системы охлаждения";
                    ErrorOhladWaterProcessorSocket = "Выбранная система охлаждения не подходит к сокету процессора";
                }
            }
            //Проверка Процессора и оперативной памяти
            if (processorKorzina != null && ddrKorzina != null)
            {
                if (processorKorzina.Ddr != ddrKorzina.Type)
                {
                    ErrorProcessorDdr = "Процессор не подходит для выбранной оперативной памяти";
                    ErrorDdrProcessor = "Оперативная память не подходит для выбранного процессора";
                }
            }
            //Проверка оперативной памяти и материнской платы
            if (motherboardKorzina != null && ddrKorzina != null)
            {
                if (motherboardKorzina.Ddr != ddrKorzina.Type || motherboardKorzina.DdrKol < ddrKorzina.Kol)
                {
                    ErrorDdr = "Оперативная память не подходит для выбранной материнской платы";
                    ErrorMotherboardDdr = "Материнская плата не подходит для выбранной оперативной памяти";
                }
            }
            //Проверка интерфейсов для хранилища данных
            //if (motherboardKorzina != null && memoryKorzina != null)
            //{
            //    if (memoryKorzina.Interface != motherboardKorzina.M2)
            //    {
            //        ErrorMemoryMotherboard = "Тип памяти не подходит к материнской плате";
            //        ErrorMotherboardMemory = "Тип хранилища данных не подходит";
            //    }
            //}
            //Проверка размера видеокарты
            if (corpusKorzina != null && videocardKorzina != null)
            {
                if (double.Parse(corpusKorzina.VideoSize) < videocardKorzina.VideoSize)
                {
                    ErrorVideoCorpus = "Длина выбранной видеокарты не подходит к выбранному корпусу";
                    ErrorCorpusVideo = "Данный корпус не подходит к выбранной видеокарте";
                }
            }
            //Проверка размера блока питания
            if (corpusKorzina != null && powerBlockKorzina != null)
            {
                if (corpusKorzina.PowerBlockSize != powerBlockKorzina.Size)
                {
                    ErrorPowerblockCorpus = "Размер блока питания не подходит к выбранному корпусу";
                    ErrorCorpusPowerblock = "Данный корпус не подходит к выбранному блоку питания";
                }
            }
            //Проверка размера материнской платы
            if (corpusKorzina != null && motherboardKorzina != null)
            {
                if (corpusKorzina.MotherSize != motherboardKorzina.Standart)
                {
                    ErrorMotherCorpus = "Размер материнской платы не подходит к выбранному корпусу";
                    ErrorCorpusMother = "Данный корпус не подходит к выбранной материнской плате";
                }
            }
            //Проверка системы охлаждения
            if (corpusKorzina != null && ohladKorzina != null)
            {
                if (corpusKorzina.CpuFunSize < ohladKorzina.Size)
                {
                    ErrorOhladCorpus = "Данная система охлажнеия не походит к выбранному корпусу";
                    ErrorCorpusOhlad = "Данный корпус не подходит для выбранной системы охлаждения";
                }
            }
            //Проверка системы охлаждения
            if (corpusKorzina != null && ohladwaterKorzina != null)
            {
                if (corpusKorzina.CpuWaterSize < ohladwaterKorzina.Size)
                {
                    ErrorOhladWaterCorpus = "Данная водяная система охлажнеия не походит к выбранному корпусу";
                    ErrorCorpusOhladWater = "Данный корпус не подходит для выбранной водяной системы охлаждения";
                }
            }
           
        }

    }
}