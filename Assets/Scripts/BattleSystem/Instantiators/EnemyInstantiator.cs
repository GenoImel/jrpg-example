using System.Collections.Generic;
using JRPG.Utilities;
using UnityEngine;

namespace JRPG.BattleSystem.Instantiators
{
    internal sealed class EnemyInstantiator : MonoBehaviour
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
            var plane = GridGenerator.DefineXZPlane(gridPlane);
            
            gridPoints = GridGenerator.Create2DGrid(plane, numRow, numCol);
            
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
