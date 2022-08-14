using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public sealed class ExampleDictionary
    {
        public void Main()
        {
            #region Example Dictionary
            var dict = new Dictionary<char, string>();

            dict.Add('r', "tmp");
            dict.Add('i', "Iva");
            dict.Add('v', "Victor");

            foreach(KeyValuePair<char, string> user in dict)
            {
                Debug.Log($"{user.Key} - {user.Value}");
            }

            dict.Remove('i');

            if (dict.ContainsKey('i'))
            {
                var tempUser = dict['i'];
            }


            foreach(var user in dict.Keys)
            {
                Debug.Log($"{user}");
            }

            #endregion

            #region C# 5
            Dictionary<int, string> dictionary = new Dictionary<int, string>()
            {
                {1, "Roman" },
                {2, "Ivan" },
                {3, "Igor" }
            };
            #endregion

            #region C# 6
            Dictionary<int, string> dictionariy = new Dictionary<int, string>()
            {
                [1] = "e1",
                [2] = "y2",
                [3] = "k4"
            };
            #endregion
        }
    }
}
