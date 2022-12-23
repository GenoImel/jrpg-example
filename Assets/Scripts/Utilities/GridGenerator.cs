using System.Collections.Generic;
using UnityEngine;

namespace JRPG.Utilities
{
    internal static class GridGenerator
    {

        public static List<Vector3> CreateGrid(Collider meshCollider, int numRow, int numCol)
        {
            var bounds = meshCollider.bounds;
            var minBounds = bounds.min;
            var maxBounds = bounds.max;

            var pointsAlongX = GeneratePoints(new Vector3(minBounds.x, 0, 0), new Vector3(maxBounds.x, 0, 0), numRow);
            var pointsAlongZ = GeneratePoints(new Vector3(0, 0, minBounds.z), new Vector3(0, 0, maxBounds.z), numCol);

            var gridPoints = GenerateGrid(meshCollider.transform, pointsAlongX, pointsAlongZ);
            return gridPoints;
        }
        
        private static List<Vector3> GeneratePoints(Vector3 startPoint, Vector3 endPoint, int numPoints)
        {
            var result = new List<Vector3>();

            float divisor = 1f / numPoints;
            float point = 0f;

            if (numPoints == 1)
            {
                result.Add(Vector3.Lerp(startPoint, endPoint, 0.5f));
                return result;
            }
            
            for (int i = 0; i < numPoints; i++)
            {
                if (i == 0)
                {
                    point = divisor / 2;
                }
                else
                {
                    point += divisor;
                }
                result.Add(Vector3.Lerp(startPoint, endPoint, point));
            }
      
            return result;
        }

        private static List<Vector3> GenerateGrid(Transform gridTransform, List<Vector3> pointsAlongX, List<Vector3> pointsAlongZ)
        {
            List<Vector3> gridPoints = new List<Vector3>();
            
            foreach(Vector3 pointX in pointsAlongX)
            {
                foreach (Vector3 pointZ in pointsAlongZ)
                {
                    gridPoints.Add(new Vector3(
                        pointX.x, 
                        gridTransform.position.y, 
                        pointZ.z
                    ));
                }
            }

            return gridPoints;
        }
    }
}