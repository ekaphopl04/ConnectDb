using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnedataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotnedataBase.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ReportContext _db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,ReportContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost]
        public ActionResult PostForDatabase(GetUser Value){
            var UserCheck = _db.ReportTable.Where(x => x.Id == Value.Id).Select(x => x.Id).FirstOrDefault();
            if(UserCheck != Value.Id && Value.Name != null && Value.Surname != null){
                _db.ReportTable.Add(new Report{
                    Id = Value.Id ,
                    Name = Value.Name,
                    Surname = Value.Surname
                });

                _db.SaveChanges();
                return Ok() ;
                
            } else {
                return BadRequest();
            }

        }
    }
}
