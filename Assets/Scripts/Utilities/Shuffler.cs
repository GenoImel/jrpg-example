using System.Collections.Generic;
using UnityEngine;

namespace JRPG.Utilities
{
    // ReSharper disable once SwapViaDeconstruction
    public static class Shuffler
    {
        /// <summary>
        /// Uses the Fisher-Yates shuffle to shuffle a list of Vector3.
        /// </summary>
        /// <param name="vectorList">List of Vector3 to be shuffled.</param>
        /// <returns></returns>
        public static List<Vector3> Shuffle(List<Vector3> vectorList)
        {
            for (int i = vectorList.Count-1; i > 0; i--)
            {
                int k = Random.Range(0,i);

                var temp = vectorList[i];
                vectorList[i] = vectorList[k];
                vectorList[k] = temp;
            }
            return vectorList;
        }
        
    }
}
