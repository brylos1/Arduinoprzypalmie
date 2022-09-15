using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemperaturyAPI.Database;
using TemperaturyAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        [HttpGet]
        [Route("all")]
        public ActionResult< IEnumerable<DaneZPalmyModel>> GetAll()
        {
            var Temperatury = _Db.temperaturies.ToList();
            return Ok(Temperatury);
        }
        [HttpGet("between")]
        public ActionResult<IEnumerable<DaneZPalmyModel>> GetBetween(DateTime startdate,DateTime stopday)
        {
            
            IQueryable Temperatury = _Db.temperaturies.Where(t => t.DataPomiaru >= stopday && t.DataPomiaru <= startdate);
            if(Temperatury is null)
            {
                return NotFound();
            }
            return Ok(Temperatury);
        }

    }
}

