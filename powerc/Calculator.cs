using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace power
{
    public static class Calculator
    {

        static Dictionary<string,string>
        getDict(  JToken token)
        {
            var res = new Dictionary<string, string>();
            var els = token.Values();
            foreach (var el in els)
            {
                res.TryAdd(((Newtonsoft.Json.Linq.JProperty)el).Name.ToString(), el.Last.ToString());
            }
            return res;

        }

        static List<Dictionary<string,string>>
        getArray(JToken token)
        {
            var res = new List<Dictionary<string, string>>();
            for (var el = token.First.First; el != null; el = el.Next)
            {
                var dict = new Dictionary<string, string>();
                foreach ( var p in el.Children())
                {
                    var key = ((Newtonsoft.Json.Linq.JProperty)p).Name;
                    var val = p.Last;
                    dict.TryAdd(key, val.ToString());
                }
                res.Add(dict);
            }         
            return res;
        }




        static (uint, List<PlantCost>) Parse( string innjson)
        {
            var top  = JObject.Parse(innjson);
            var loadT = top.First;
            var fuelsT = loadT.Next;
            var plantsT = fuelsT.Next;
            var loadS = loadT.Values()[0];
            var fuels = getDict(fuelsT);
            var plantsDict = getArray(plantsT);
            var plants = new List<PlantCost>();
            foreach ( var p in plantsDict)
            {
                var plant = new PlantCost(fuels, p);
                plants.Add( plant);

            }
            var d = loadT.Last;
            uint load = uint.Parse(d.ToString());

            return (load, plants);
        }


        static bool subtract( List<(PlantCost, uint)> list, uint tosubtract , int index     )
        {
            if (index < 1)
                return false;
            var lel = list[index];
            var pl = lel.Item1;
            var newval = lel.Item2 - tosubtract;
            if (newval >= pl.pmin)
            {
                lel.Item2 = newval;
                list[index] = lel;
                return true;
            }
            var rc = subtract(list, tosubtract - (lel.Item2 - pl.pmin), index - 1);
            if (!rc)
                return false;
            lel.Item2 = pl.pmin;
            list[index] = lel;
            return true;
        }
        
        static public List<(PlantCost, uint)> Calculate(string innjson)
        {
            var inn = Parse(innjson);
            var innList = inn.Item2;
            var ordered = innList.OrderBy(p => p.cost).ThenByDescending(p => p.pmin).ThenByDescending(p => p.pmax).ToList();
            var target = inn.Item1;
            uint accumulated = 0;
            var res = new List<(PlantCost, uint)>();
            for( int i = 0; i < ordered.Count; i++ )
            {
                var pl = ordered[i];
                uint toadd  = target - accumulated;
                if (toadd == 0)
                    break;

                var power = Math.Min(toadd, pl.pmax);
                if( power < pl.pmin)
                {
                    var tosub = pl.pmin - power;
                    if (subtract(res, tosub, i - 1))
                    {
                        accumulated = accumulated - tosub;
                        power = pl.pmin;
                    }
                    else
                        power = 0;
                }
                res.Add((pl, (uint) power));
                accumulated = accumulated + power;
            }
            return res; // from r in res select new { name = r.Item1.name, p = r.Item2 };
            
        }
    }
}
