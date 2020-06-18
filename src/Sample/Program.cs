using System;
using System.Collections.Generic;

using Collections.Extensions.ToPyString;

namespace Sample
{
    class Program
    {
        static void Main()
        {
            var regularArray = InitializeRegularArray();
            var regularDict = InitializeRegularDictionary();
            var selfContainingDict = InitializeSelfContainingDictionary();
            var regularList = InitializeRegularList();
            var selfContainingList = InitializeSelfContainingList();
            var complexList = InitializeSelfContainingListWithSubcollections(selfContainingDict, selfContainingList);
            var objWithoutToString = new object();
            var objWithToString = new Program();
            dynamic dynObject = new { SomeField = 1 };
            var listWithDynamicObject = new List<object> { 11, "some string", dynObject };

            Console.WriteLine("Regular array: " + regularArray.ToPyString());
            Console.WriteLine("Regular dictionary: " + regularDict.ToPyString());
            Console.WriteLine("Self-containing dictionary: " + selfContainingDict.ToPyString());
            Console.WriteLine("Regular list: " + regularList.ToPyString());
            Console.WriteLine("Self-containing list: " + selfContainingList.ToPyString());
            Console.WriteLine("Self-containing list with subcollections: " + complexList.ToPyString());
            Console.WriteLine("Regular object without ToString override: " + objWithoutToString.ToPyString());
            Console.WriteLine("Object with ToString override: " + objWithToString.ToPyString());
            Console.WriteLine("Dynamic object: " + Extensions.ToPyString(dynObject));
            Console.WriteLine("List containing a dynamic object: " + Extensions.ToPyString(listWithDynamicObject));
        }

        public override string ToString()
        {
            return "This is ToString value of an object with the override";
        }

        private static int[] InitializeRegularArray()
        {
            return new int[] { 1, 2, 9 };
        }

        private static Dictionary<int, int> InitializeRegularDictionary()
        {
            return new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 3
            };
        }

        private static Dictionary<object, object> InitializeSelfContainingDictionary()
        {
            var dict1 = new Dictionary<object, object>
            {
                [2] = 1,
                ["dic2"] = 1,
            };
            dict1["dicself"] = dict1;
            return dict1;
        }

        private static List<int> InitializeRegularList()
        {
            return new List<int> { 1, 5, -2, 88 };
        }

        private static List<object> InitializeSelfContainingList()
        {
            var list = new List<object> { "list1", null, new List<string> { "sublist1" } };
            list.Add(list);
            return list;
        }

        private static List<object> InitializeSelfContainingListWithSubcollections(Dictionary<object, object> selfContainingDict, List<object> list)
        {
            var containerList = new List<object> { "list2", list, selfContainingDict };
            containerList.Add(containerList);
            return containerList;
        }
    }
}
