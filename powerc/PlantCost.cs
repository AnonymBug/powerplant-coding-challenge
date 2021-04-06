using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace power
{
    public class PlantCost {

        public string name { get; private set; }
        //double costMvH;
        public uint pmin { get; private set; }
        public uint pmax { get; private set; }

        public double cost { get; private set; }

        private double efficiency { get; set; }

        public uint allocated { get; set; }

        private double
        getFuelCost(Dictionary<string, string> costs, string type)
        {
            var first = type[0];
            if ('t' == first) //turbo
                first = 'k'; //"kerosine"
            if ('w' == first)
                return 0.0;
            foreach( var pair in costs)
            {
                if( pair.Key[0] == first)
                {
                    var priceStr =pair.Value;
                    return Double.Parse(priceStr);
                }
            }
            return -1.0;
        }
        public 
        PlantCost(Dictionary<string, string> costs, Dictionary<string, string>  plant)
        {
            allocated = 0;
            name = plant["name"];
            efficiency = Double.Parse(plant["efficiency"]);
            pmin = uint.Parse(plant["pmin"]);
            pmax = uint.Parse(plant["pmax"]);
            string type = plant["type"];
            var price = getFuelCost(costs, type);
            cost = price / efficiency;
            if (0 == cost) //wind
            {
                var percentagePair = costs.Where(pv => pv.Key.StartsWith("w")).ToDictionary(pv => pv.Key, pv => pv.Value);
                var percentageS = percentagePair.Values.ToArray()[0];
                var percentage = int.Parse(percentageS);
                efficiency = percentage / 100.0;
                //pmin = pmin * efficiency;
                pmax = (uint) (pmax * efficiency);

            }
        }
    }
}
