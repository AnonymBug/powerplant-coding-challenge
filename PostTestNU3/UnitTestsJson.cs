using Newtonsoft.Json.Linq;
using NUnit.Framework;
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
        [TestCase("payload1.json")]
        [TestCase("payload2.json")]
        [TestCase("payload3.json")]

        public void testJson(string fn)
        {
            
            var path = Path.Join(@"..\..\..\..\",  froot, fn);
            var jsons = File.ReadAllText(path);
            Calculator.Calculate(jsons);
        }


    }
}