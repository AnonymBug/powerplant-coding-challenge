using Newtonsoft.Json.Linq;
using NUnit.Framework;
using power;

namespace PowerTests
{


    public class TestsHardcoded
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string l1 = @"{'load':480,'fuels':{'gas(euro / MWh)':13.4,'kerosine(euro / MWh)':50.8,'co2(euro / ton)':20,'wind(%)':60},'powerplants':[{'name':'gasfiredbig1','type':'gasfired','efficiency':0.53,'pmin':100,'pmax':460},{'name':'gasfiredbig2','type':'gasfired','efficiency':0.53,'pmin':100,'pmax':460},{'name':'gasfiredsomewhatsmaller','type':'gasfired','efficiency':0.37,'pmin':40,'pmax':210},{'name':'tj1','type':'turbojet','efficiency':0.3,'pmin':0,'pmax':16},{'name':'windpark1','type':'windturbine','efficiency':1,'pmin':0,'pmax':150},{'name':'windpark2','type':'windturbine','efficiency':1,'pmin':0,'pmax':36}]}";
            //var pow = new power.Calculator();

            var res = Calculator.Calculate(l1);
            Assert.AreEqual(480, TestCommon.sum(res));


        }
    }
}