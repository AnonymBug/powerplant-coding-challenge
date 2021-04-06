using power;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerTests
{
    static class TestCommon
    {
        static public uint sum(List<(PlantCost, uint)> l)
        {
            uint res = 0;
            foreach( var p in l)
            {
                res += p.Item2;

            }
            return res;
        }


    }
}
