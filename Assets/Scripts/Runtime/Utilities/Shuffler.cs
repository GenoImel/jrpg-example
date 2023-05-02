using System.Collections.Generic;
using UnityEngine;

namespace Jrpg.Runtime.Utilities
{
    internal static class Shuffler
    {
        /// <summary>
        /// Uses the Fisher-Yates shuffle to shuffle a list of any type.
        /// </summary>
        /// <param name="list">List to be shuffled.</param>
        /// <returns>Returns a list.</returns>
        public static List<T> Shuffle<T>(List<T> list)
        {
            for (var i = list.Count-1; i > 0; i--)
            {
                var k = Random.Range(0, i);

                (list[i], list[k]) = (list[k], list[i]);
            }

            return list;
        }
    }
}