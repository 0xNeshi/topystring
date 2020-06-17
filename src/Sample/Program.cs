using System;
using System.Collections.Generic;

using Collections.Extensions.ToPyString;

namespace Sample
{
    class Program
    {
        static void Main()
        {
            var dict1 = new Dictionary<object, object>
            {
                [2] = 1,
                ["dic2"] = 1,
            };
            dict1["dicself"] = dict1;

            var dicInts = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 3
            };

            var list = new List<object> { "list1", null, new List<string> { "sublist1" } };
            list.Add(list);
            
            var containerList = new List<object> { "list2", list, dict1 };
            containerList.Add(containerList);

            var obj = new Program();

            Console.WriteLine(dict1.ToPyString());
            Console.WriteLine(dicInts.ToPyString());
            Console.WriteLine(list.ToPyString());
            Console.WriteLine(containerList.ToPyString());
            Console.WriteLine(obj.ToPyString());
        }
    }
}
