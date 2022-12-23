using System.Collections.Generic;
using JRPG.Utilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace JRPG.BattleSystem
{
    public class EnemyBattlescreenSpawner : MonoBehaviour
    {
        [Header("Enemies")] 
        [SerializeField] private List<GameObject> enemies;
        
        [SerializeField] private int enemyCount = 3;
        
        [Header("Grid")] 
        [SerializeField] private Collider gridPlane;
        
        [SerializeField] [Range(1,3)] private int numRow = 2;

        [SerializeField] [Range(1,4)] private int numCol = 3;
        
        private List<Vector3> gridPoints;

        void Start()
        {
            gridPoints = GridGenerator.CreateGrid(gridPlane, numRow, numCol);
            
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
                Instantiate(enemies[0], gridPoints[0], Quaternion.identity, this.transform);
            }
            else
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    Instantiate(enemies[Random.Range(0, enemies.Count)], gridPoints[i], Quaternion.identity, this.transform);
                }
            }
        }
        
    }
}
