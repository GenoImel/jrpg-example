using Jrpg.Core;
using Jrpg.Runtime.Systems.EquipmentData;
using Jrpg.Runtime.Systems.GameData;
using Jrpg.Runtime.Systems.ItemData;
using UnityEngine;

namespace Jrpg.Runtime
{
    internal sealed class JrpgGameManager : GameManager
    {
        [Header("Systems")] 
        [SerializeField] private SaveDataSystem saveDataSytem;
        
        [SerializeField] private EquipmentDataSystem equipmentDataSystem;
        
        [SerializeField] private ItemDataSystem itemDataSystem;

        [Header("Management")] 
        [SerializeField] private Transform controllerParentTransform;
        
        [SerializeField] private Transform systemsParentTransform;

        protected override string GetApplicationName()
        {
            return nameof(JrpgGameManager);
        }

        protected override void OnInitialized()
        {
            AddSystem<SaveDataSystem, ISaveDataSystem>(saveDataSytem);
            AddSystem<EquipmentDataSystem, IEquipmentDataSystem>(equipmentDataSystem);
            AddSystem<ItemDataSystem, IItemDataSystem>(itemDataSystem);

            controllerParentTransform.gameObject.SetActive(true);
            systemsParentTransform.gameObject.SetActive(true);
        }
    }
}
