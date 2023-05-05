using UnityEngine;

namespace Jrpg.Runtime.Battle.Instantiators
{
    internal sealed class TerrainInstantiator : MonoBehaviour
    {
        [Header("Terrain Info")] 
        [SerializeField] private GameObject defaultTerrain;

        [SerializeField] private GameObject sceneTerrain;

        private void Start()
        {
            if (sceneTerrain == null)
            {
                return;
            } 
            
            defaultTerrain.SetActive(false);
            CreateTerrain(sceneTerrain);
        }

        private void CreateTerrain(GameObject terrain)
        {
            Instantiate(
                terrain,
                transform
            );
        }
    }
}
