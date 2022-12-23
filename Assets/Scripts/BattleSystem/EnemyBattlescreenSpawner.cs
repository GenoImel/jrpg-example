using System.Collections.Generic;
using JRPG.Utilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace JRPG.BattleSystem
{
    internal sealed class EnemyBattlescreenSpawner : MonoBehaviour
    {
        [Header("Enemies")] 
        [SerializeField] private List<GameObject> enemyTypes;
        
        [SerializeField] private int enemyCount = 3;

        [SerializeField] private float popInHeight = 2f;
        
        [Header("Grid")] 
        [SerializeField] private MeshFilter gridPlane;
        
        [SerializeField] [Range(1,3)] private int numRow = 2;

        [SerializeField] [Range(1,4)] private int numCol = 3;
        
        private List<Vector2> gridPoints;

        void Start()
        {
            var bounds = gridPlane.mesh.bounds;
            var minBounds = gridPlane.transform.TransformPoint(bounds.min);
            var maxBounds = gridPlane.transform.TransformPoint(bounds.max);
            
            gridPoints = GridGenerator.Create2DGrid(
                new Vector2(minBounds.x, minBounds.z), 
                new Vector2(maxBounds.x, maxBounds.z), 
                numRow, 
                numCol
                );
            
            PlaceEnemies();
        }

        private void PlaceEnemies()
        {
            if (gridPoints.Count > 1)
            {
                gridPoints = Shuffler.Shuffle(gridPoints);
            }

            if (enemyCount > gridPoints.Count)
                enemyCount = gridPoints.Count;
            
            if (enemyCount == 1)
            {
                Instantiate(
                    enemyTypes[0], 
                    gridPoints[0], 
                    Quaternion.identity, 
                    this.transform
                    );
            }
            else
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    Instantiate(
                        enemyTypes[Random.Range(0, enemyTypes.Count)],
                        new Vector3(gridPoints[i].x, popInHeight, gridPoints[i].y),
                        Quaternion.identity, 
                        this.transform
                        );
                }
            }
        }
        
    }
}
