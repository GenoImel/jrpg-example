using Jrpg.Runtime.DataClasses.ItemData;
using Newtonsoft.Json;
using UnityEngine;

namespace Jrpg.Runtime.Systems.ItemData
{
    internal sealed class ItemDataSystem : MonoBehaviour, IItemDataSystem
    {
        [Header("Items Data File")] 
        [SerializeField]
        private TextAsset itemsDataFile;

        private Items itemsData;

        private void Awake()
        {
            LoadData();
        }

        public Item GetItem(string itemName)
        {
            return itemsData.GetItem(itemName);
        }

        private void LoadData()
        {
            itemsData = JsonConvert
                .DeserializeObject<Items>(itemsDataFile.text);
        }
    }
}