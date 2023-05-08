using System.IO;
using Jrpg.Runtime.DataClasses.PartyData;
using Newtonsoft.Json;
using UnityEngine;

namespace Jrpg.Runtime.Systems.GameData
{
    internal sealed class SaveDataSystem : MonoBehaviour, ISaveDataSystem
    {
        [Header("Default Party Data File")]
        [SerializeField] 
        private TextAsset defaultPartyInfoFile;

        [Header("Default Inventory Data File")] 
        [SerializeField]
        private TextAsset defaultInventoryDataFile;
        
        [Header("Party Information")] 
        [SerializeField]
        private PartyData partyData;

        [Header("Inventory Information")] 
        [SerializeField]
        private PartyInventory inventoryData;

        [Header("Save Data Filename")] 
        [SerializeField]
        private string saveFileName;

        [Header("Default Save Data Filename")] 
        [SerializeField]
        private string defaultSaveFileName;

        [Header("Inventory Data Filename")] 
        [SerializeField]
        private string inventoryFileName;
        
        [Header("Default Inventory Data Filename")] 
        [SerializeField]
        private string defaultInventoryFileName;

        private bool isDefault;

        private void Awake()
        {
            partyData = LoadDefaultPartyData();
            inventoryData = LoadDefaultPartyInventory();

            isDefault = true;
        }
        
        public PartyData LoadPartyData(TextAsset data)
        {
            saveFileName = data.name;
            isDefault = false;
            
            var currentPartyData = JsonConvert
                .DeserializeObject<PartyData>(data.text);

            return currentPartyData;
        }

        private PartyInventory LoadInventoryData(TextAsset data)
        {
            inventoryFileName = data.name;
            isDefault = false;

            var currentPartyInventory = JsonConvert
                .DeserializeObject <PartyInventory>(data.text);

            return currentPartyInventory;
        }
        
        public void SaveData()
        {
            var fileName = isDefault ? defaultSaveFileName : saveFileName;
            var data = JsonConvert.SerializeObject(partyData);
            var filePath = Path.Combine(Application.persistentDataPath, fileName);
        }

        public void WritePartyMemberData(PartyMember partyMember)
        {
            partyData.UpdatePartyMember(partyMember);
        }

        public PartyMember GetPartyMemberData(string charName)
        {
            return partyData.GetPartyMember(charName);
        }
        
        public PartyInventory GetPartyInventory()
        {
            return inventoryData;
        }

        public InventoryItem GetInventoryItemData(string itemName)
        {
            return inventoryData.GetInventoryItem(itemName);
        }

        public PartyData GetPartyData()
        {
            return partyData;
        }

        private PartyData LoadDefaultPartyData()
        {
            var currentPartyData = JsonConvert
                .DeserializeObject<PartyData>(defaultPartyInfoFile.text);

            return currentPartyData;
        }

        private PartyInventory LoadDefaultPartyInventory()
        {
            var currentPartyInventory = JsonConvert
                .DeserializeObject<PartyInventory>(defaultInventoryDataFile.text);

            return currentPartyInventory;
        }
    }
}