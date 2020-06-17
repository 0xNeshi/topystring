using System;
using System.Collections.Generic;

using Collections.Extensions.ToPyString;

namespace Sample
{
    class Program
    {
        static void Main()
        {
            var dic = new Dictionary<object, object>
            {
                [2] = 1,
                ["dic2"] = 1,
            };
            dic["dicself"] = dic;
            var filtered = new List<object> { "list1", null, new List<string> { "sublist1" } };
            filtered.Add(filtered);
            var t = new List<object> { "list2", filtered, dic };
            t.Add(t);

            var gg = new Program();

            Console.WriteLine(dic.ToPyString());
            Console.WriteLine(filtered.ToPyString());
            Console.WriteLine(t.ToPyString());
            Console.WriteLine(gg.ToPyString());
        }
    }
}
