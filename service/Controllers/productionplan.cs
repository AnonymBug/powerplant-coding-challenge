using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using power;
namespace service.Controllers
{
    public class productionplan : ApiController
    {


        public void Post([FromBody] string value)
        {
            string l1 = @"{'load':480,'fuels':{'gas(euro / MWh)':13.4,'kerosine(euro / MWh)':50.8,'co2(euro / ton)':20,'wind(%)':60},'powerplants':[{'name':'gasfiredbig1','type':'gasfired','efficiency':0.53,'pmin':100,'pmax':460},{'name':'gasfiredbig2','type':'gasfired','efficiency':0.53,'pmin':100,'pmax':460},{'name':'gasfiredsomewhatsmaller','type':'gasfired','efficiency':0.37,'pmin':40,'pmax':210},{'name':'tj1','type':'turbojet','efficiency':0.3,'pmin':0,'pmax':16},{'name':'windpark1','type':'windturbine','efficiency':1,'pmin':0,'pmax':150},{'name':'windpark2','type':'windturbine','efficiency':1,'pmin':0,'pmax':36}]}";

            var res = new power.Calculator().Calculate(l1);
        }


    }
}
