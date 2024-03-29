﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemperaturyAPI.Database;
using TemperaturyAPI.Models;
using TemperaturyAPI.Models.DTO;

namespace TemperaturyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalmaController : Controller
    {
        private readonly PgsqlDbContext _Db;
        public PalmaController (PgsqlDbContext pgsqlDbContext)
        {
            _Db = pgsqlDbContext;
        }
        // /api/Palma/all
        [HttpGet]
        [Route("all")]
        public ActionResult< IQueryable<DaneZPalmyModel>> GetAll()
        {
            var Temperatury = _Db.temperaturies.AsQueryable().OrderByDescending(t=>t.DataPomiaru);
            return Ok(Temperatury);
        }
        // /api/Palma/between?enddate={Data końca przedziału w formacie yyyy-mm-ddThh:mm:ss}&startdate={Data początku przedziału w formacie yyyy-mm-ddThh:mm:ss}
        [HttpGet("between")]
        public ActionResult<IQueryable<DaneZPalmyModel>> GetBetween(DateTime enddate,DateTime startdate)
        {
            
            IQueryable Temperatury = _Db.temperaturies.Where(t => t.DataPomiaru >= startdate && t.DataPomiaru <= enddate).AsQueryable().OrderByDescending(t => t.DataPomiaru);

            return Ok(Temperatury);
        }
        // /api/Palma/grzanie
        [HttpGet]
        [Route("grzanie")]
        public ActionResult<IQueryable<DaneZPalmyModel>> GetGrzanieAll()
        {
            IQueryable Temperatury = _Db.temperaturies.Where(t=> t.CzyGrzanieZalaczone==true).AsQueryable().OrderByDescending(t => t.DataPomiaru);
            return Ok(Temperatury);
        }
        [HttpGet]
        [Route("grzanie/cost")]
        public ActionResult<CostDTO> Getcost(float price, int power)
        {
            float cost=0f;
            int minutes = _Db.temperaturies.Where(t => t.CzyGrzanieZalaczone == true).Count();
            float KWh = (power * (minutes / 60f))/1000;
            cost = KWh * price;

            return Ok(new CostDTO()
            {
               
                costEnergy = cost,
                usedEnergy=KWh,
                minuty=minutes,
                godziny=minutes/60f
            }) ;
     
        }
        // /api/Palma/grzanie/between?enddate={Data końca przedziału w formacie yyyy-mm-ddThh:mm:ss}&startdate={Data początku przedziału w formacie yyyy-mm-ddThh:mm:ss}
        [HttpGet]
        [Route("grzanie/between")]
        public ActionResult<IQueryable<DaneZPalmyModel>> GetGrzanieBetween(DateTime startdate, DateTime enddate)
        {
            IQueryable Temperatury = _Db.temperaturies.Where(t => t.DataPomiaru >= startdate && t.DataPomiaru <= enddate && t.CzyGrzanieZalaczone == true).AsQueryable().OrderByDescending(t => t.DataPomiaru);

            return Ok(Temperatury);
        }
        // /api/Palma/bezgrzania
        [HttpGet]
        [Route("bezgrzania")]
        public ActionResult<IQueryable<DaneZPalmyModel>> GetBezGrzaniaAll()
        {
            IQueryable Temperatury = _Db.temperaturies.Where(t => t.CzyGrzanieZalaczone == false).AsQueryable().OrderByDescending(t => t.DataPomiaru);
            return Ok(Temperatury);
        }
        // /api/Palma/bezgrzania/between?enddate={Data końca przedziału w formacie yyyy-mm-ddThh:mm:ss}&startdate={Data początku przedziału w formacie yyyy-mm-ddThh:mm:ss}
        [HttpGet]
        [Route("bezgrzania/between")]
        public ActionResult<IQueryable<DaneZPalmyModel>> GetBezGrzanieBetween(DateTime startdate, DateTime enddate)
        {

            IQueryable Temperatury = _Db.temperaturies.Where(t => t.DataPomiaru >= startdate && t.DataPomiaru <= enddate && t.CzyGrzanieZalaczone == false);

            return Ok(Temperatury);
        }
        // /api/Palma/srednia
        [HttpGet]
        [Route("srednia")]
        public ActionResult<IQueryable<SrednieTemperaturyModel>> GetSredniaAll()
        {
            IQueryable Temperatury = _Db.srednieTemperatury.FromSqlRaw("SELECT * FROM public.srednieTemperatury").AsQueryable().OrderByDescending(t => t.DataPomiaru);
            return Ok(Temperatury);
        }
        // /api/Palma/srednia/between?enddate={Data końca przedziału w formacie yyyy-mm-dd}&startdate={Data początku przedziału w formacie yyyy-mm-dd}
        [HttpGet]
        [Route("srednia/between")]
        public ActionResult<IQueryable<SrednieTemperaturyModel>> GetSredniaBetween(DateTime startdate, DateTime enddate)
        {
            IQueryable Temperatury = _Db.srednieTemperatury.FromSqlRaw("SELECT * FROM public.srednieTemperatury").Where(st=>st.DataPomiaru>=DateOnly.FromDateTime(startdate)&&st.DataPomiaru<=DateOnly.FromDateTime(enddate)).AsQueryable().OrderByDescending(t => t.DataPomiaru);
            return Ok(Temperatury);
        }
        // /api/Palma/MinMax
        [HttpGet]
        [Route("minmax")]
        public ActionResult<IQueryable<MinMaxModel>> GetMinMaxAll()
        {
            IQueryable Temperatury = _Db.minMax.FromSqlRaw("SELECT * FROM public.MinMax").AsQueryable().OrderByDescending(t => t.DataPomiaru);
            return Ok(Temperatury);
        }
        // /api/Palma/minmax/between?enddate={Data końca przedziału w formacie yyyy-mm-dd}&startdate={Data początku przedziału w formacie yyyy-mm-dd}
        [HttpGet]
        [Route("minmax/between")]
        public ActionResult<IQueryable<MinMaxModel>> GetMinMaxBetween(DateTime startdate, DateTime enddate)
        {
            IQueryable Temperatury = _Db.minMax.FromSqlRaw("SELECT * FROM public.MinMax").Where(st => st.DataPomiaru >= DateOnly.FromDateTime(startdate) && st.DataPomiaru <= DateOnly.FromDateTime(enddate)).AsQueryable().OrderByDescending(t => t.DataPomiaru);
            return Ok(Temperatury);
        }
        // /api/Palma/ostatni
        [HttpGet]
        [Route("ostatni")]
        public ActionResult<OstatnieTemperaturyDTO> GetOstatni()
        {
            DaneZPalmyModel? Temperatury = _Db.temperaturies.OrderByDescending(t => t.DataPomiaru).FirstOrDefault();
            OstatnieTemperaturyDTO ostania = new OstatnieTemperaturyDTO()
            {
                TemperaturaGleby = Temperatury.TemperaturaGleby,
                TemperaturaPowietrza = Temperatury.TemperaturaPowietrza
            };
            return Ok(ostania);
        }

    }
}

