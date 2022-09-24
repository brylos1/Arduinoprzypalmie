using System;
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
        private readonly MysqlDbContext _Db;
        public PalmaController (MysqlDbContext mysqlDbContext)
        {
            _Db = mysqlDbContext;
        }
        // /api/Palma/all
        [HttpGet]
        [Route("all")]
        public ActionResult< IQueryable<DaneZPalmyModel>> GetAll()
        {
            var Temperatury = _Db.temperaturies.ToList();
            return Ok(Temperatury);
        }
        // /api/Palma/between?enddate={Data końca przedziału w formacie yyyy-mm-ddThh:mm:ss}&startdate={Data początku przedziału w formacie yyyy-mm-ddThh:mm:ss}
        [HttpGet("between")]
        public ActionResult<IQueryable<DaneZPalmyModel>> GetBetween(DateTime enddate,DateTime startdate)
        {
            
            IQueryable Temperatury = _Db.temperaturies.Where(t => t.DataPomiaru >= startdate && t.DataPomiaru <= enddate);

            return Ok(Temperatury);
        }
        // /api/Palma/grzanie
        [HttpGet]
        [Route("grzanie")]
        public ActionResult<IQueryable<DaneZPalmyModel>> GetGrzanieAll()
        {
            IQueryable Temperatury = _Db.temperaturies.Where(t=> t.CzyGrzanieZalaczone==true);
            return Ok(Temperatury);
        }
        // /api/Palma/grzanie/between?enddate={Data końca przedziału w formacie yyyy-mm-ddThh:mm:ss}&startdate={Data początku przedziału w formacie yyyy-mm-ddThh:mm:ss}
        [HttpGet]
        [Route("grzanie/between")]
        public ActionResult<IQueryable<DaneZPalmyModel>> GetGrzanieBetween(DateTime startdate, DateTime enddate)
        {
            IQueryable Temperatury = _Db.temperaturies.Where(t => t.DataPomiaru >= startdate && t.DataPomiaru <= enddate && t.CzyGrzanieZalaczone == true);

            return Ok(Temperatury);
        }
        // /api/Palma/bezgrzania
        [HttpGet]
        [Route("bezgrzania")]
        public ActionResult<IQueryable<DaneZPalmyModel>> GetBezGrzaniaAll()
        {
            IQueryable Temperatury = _Db.temperaturies.Where(t => t.CzyGrzanieZalaczone == false);
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
            IQueryable Temperatury = _Db.srednieTemperatury.FromSqlRaw("SELECT * FROM temperatury.srednieTemperatury").AsQueryable();
            return Ok(Temperatury);
        }
        // /api/Palma/srednia/between?enddate={Data końca przedziału w formacie yyyy-mm-dd}&startdate={Data początku przedziału w formacie yyyy-mm-dd}
        [HttpGet]
        [Route("srednia/between")]
        public ActionResult<IQueryable<SrednieTemperaturyModel>> GetSredniaBetween(DateTime startdate, DateTime enddate)
        {
            IQueryable Temperatury = _Db.srednieTemperatury.FromSqlRaw("SELECT * FROM temperatury.srednieTemperatury").Where(st=>st.DataPomiaru>=DateOnly.FromDateTime(startdate)&&st.DataPomiaru<=DateOnly.FromDateTime(enddate)).AsQueryable();
            return Ok(Temperatury);
        }
        // /api/Palma/MinMax
        [HttpGet]
        [Route("minmax")]
        public ActionResult<IQueryable<MinMaxModel>> GetMinMaxAll()
        {
            IQueryable Temperatury = _Db.minMax.FromSqlRaw("SELECT * FROM temperatury.MinMax").AsQueryable();
            return Ok(Temperatury);
        }
        // /api/Palma/srednia/between?enddate={Data końca przedziału w formacie yyyy-mm-dd}&startdate={Data początku przedziału w formacie yyyy-mm-dd}
        [HttpGet]
        [Route("minmax/between")]
        public ActionResult<IQueryable<MinMaxModel>> GetMinMaxBetween(DateTime startdate, DateTime enddate)
        {
            IQueryable Temperatury = _Db.minMax.FromSqlRaw("SELECT * FROM temperatury.MinMax").Where(st => st.DataPomiaru >= DateOnly.FromDateTime(startdate) && st.DataPomiaru <= DateOnly.FromDateTime(enddate)).AsQueryable();
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

