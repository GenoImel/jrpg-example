using System.Collections.Generic;
using UnityEngine;

namespace JRPG.Utilities
{
    // ReSharper disable all SwapViaDeconstruction
    internal static class Shuffler
    {
        /// <summary>
        /// Uses the Fisher-Yates shuffle to shuffle a list of Vector3.
        /// </summary>
        /// <param name="vectorList">List of Vector3 to be shuffled.</param>
        /// <returns>Returns a list of Vector3.</returns>
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
        
        /// <summary>
        /// Uses the Fisher-Yates shuffle to shuffle a list of Vector2.
        /// </summary>
        /// <param name="vectorList">List of Vector2 to be shuffled.</param>
        /// <returns>Returns a list of Vector2.</returns>
        public static List<Vector2> Shuffle(List<Vector2> vectorList)
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
