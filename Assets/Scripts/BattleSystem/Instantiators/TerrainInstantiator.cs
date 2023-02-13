using UnityEngine;

namespace JRPG.BattleSystem.Instantiators
{
    internal sealed class TerrainInstantiator : MonoBehaviour
    {
        [Header("Terrain Info")] 
        [SerializeField] private GameObject defaultTerrain;

        [SerializeField] private GameObject sceneTerrain;

        private void Start()
        {
            if (sceneTerrain != null)
            {
                defaultTerrain.SetActive(false);
                CreateTerrain(sceneTerrain);
            }
        }

        private void CreateTerrain(GameObject terrain)
        {
            Instantiate(
                terrain,
                this.transform
            );
        }
    }
}
