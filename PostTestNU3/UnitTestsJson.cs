using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PostTestNU3;
using power;
using System.IO;

namespace PowerTests
{


    public class TestInnFiles
    {
        [SetUp]
        public void Setup()
        {
        }

        //const string froot = @"D:\po\pow\powerplant-coding-challenge-master\example_payloads"; 
        const string froot = @"example_payloads";



        [Test]
        [TestCase("payload1.json", 480)]
        [TestCase("payload2.json", 480)]
        [TestCase("payload3.json", 910)]

        public void testJson(string fn, int expextedSum)
        {
            
            var path = Path.Join(@"..\..\..\..\",  froot, fn);
            var jsons = File.ReadAllText(path);
            var res = Calculator.Calculate(jsons);
            
            Assert.AreEqual(expextedSum, TestCommon.sum(res));
        }


    }
}