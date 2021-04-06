using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace powerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class productionplanController : ControllerBase
    {
        private static readonly string l1 = @"{'load':480,'fuels':{'gas(euro / MWh)':13.4,'kerosine(euro / MWh)':50.8,'co2(euro / ton)':20,'wind(%)':60},'powerplants':[{'name':'gasfiredbig1','type':'gasfired','efficiency':0.53,'pmin':100,'pmax':460},{'name':'gasfiredbig2','type':'gasfired','efficiency':0.53,'pmin':100,'pmax':460},{'name':'gasfiredsomewhatsmaller','type':'gasfired','efficiency':0.37,'pmin':40,'pmax':210},{'name':'tj1','type':'turbojet','efficiency':0.3,'pmin':0,'pmax':16},{'name':'windpark1','type':'windturbine','efficiency':1,'pmin':0,'pmax':150},{'name':'windpark2','type':'windturbine','efficiency':1,'pmin':0,'pmax':36}]}";


        private readonly ILogger<productionplanController> _logger;

        public productionplanController(ILogger<productionplanController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public dynamic Get()
        {
            var res = power.Calculator.Calculate(l1);
            var linqret = from r in res select new { name = r.Item1.name, p = r.Item2 };
            return  linqret;
        }

        // POST api/<sController>
        [HttpPost]
        public dynamic Post([FromBody] JsonElement value)
        {
            var res = power.Calculator.Calculate(value.ToString());
            var linqret = from r in res select new { name = r.Item1.name, p = r.Item2 };
            return linqret;

        }
    }
}
