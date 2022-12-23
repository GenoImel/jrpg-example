using System.Collections.Generic;
using UnityEngine;

namespace JRPG.Utilities
{
    internal static class GridGenerator
    {

        public static List<Vector2> Create2DGrid(Vector2 minBounds, Vector2 maxBounds, int numRow, int numCol)
        {
            var gridPoints = new List<Vector2>();
            
            if (numRow == 0 || numCol == 0)
            {
                Debug.Log("The number of rows or columns in the grid cannot be zero.");
                return gridPoints;
            }

            var pointsAlongX = GeneratePoints(
                new Vector2(minBounds.x, 0), 
                new Vector2(maxBounds.x, 0), 
                numRow
                );
            var pointsAlongY = GeneratePoints(
                new Vector2(0, minBounds.y), 
                new Vector2(0, maxBounds.y), 
                numCol
                );

            gridPoints = Generate2DGrid(pointsAlongX, pointsAlongY);
            return gridPoints;
        }
        
        private static List<Vector2> GeneratePoints(Vector3 startPoint, Vector3 endPoint, int numPoints)
        {
            var result = new List<Vector2>();

            if (numPoints == 0)
            {
                Debug.Log("Variable numPoints cannot be zero.");
                return result;
            }

            float frac = 1f / numPoints;
            float point = 0f;

            if (numPoints == 1)
            {
                result.Add(Vector2.Lerp(startPoint, endPoint, 0.5f));
                return result;
            }
            
            for (int i = 0; i < numPoints; i++)
            {
                if (i == 0)
                {
                    point = frac / 2;
                }
                else
                {
                    point += frac;
                }
                result.Add(Vector2.Lerp(startPoint, endPoint, point));
            }
      
            return result;
        }

        private static List<Vector2> Generate2DGrid(List<Vector2> pointsAlongX, List<Vector2> pointsAlongY)
        {
            List<Vector2> gridPoints = new List<Vector2>();
            
            foreach(Vector2 pointX in pointsAlongX)
            {
                foreach (Vector2 pointY in pointsAlongY)
                {
                    gridPoints.Add(new Vector2(
                        pointX.x,
                        pointY.y
                    ));
                }
            }

            return gridPoints;
        }
    }
}