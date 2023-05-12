using Jrpg.Runtime.DataClasses.Bases;
using Jrpg.Runtime.DataClasses.EquipmentData;
using Jrpg.Runtime.DataClasses.OverdriveData;
using Newtonsoft.Json;
using UnityEngine;

namespace Jrpg.Runtime.Systems.EquipmentData
{
    internal sealed class EquipmentDataSystem : MonoBehaviour, IEquipmentDataSystem
    {
        [Header("Weapons Data File")] 
        [SerializeField] 
        private TextAsset weaponsDataFile;
        
        [Header("Charms Data File")] 
        [SerializeField] 
        private TextAsset charmsDataFile;
        
        [Header("Gems Data File")] 
        [SerializeField] 
        private TextAsset gemsDataFile;
        
        [Header("Necklaces Data File")] 
        [SerializeField] 
        private TextAsset necklacesDataFile;
        
        [Header("Overdrives Data File")]
        [SerializeField]
        private TextAsset overdrivesDataFile;

        private Weapons weaponsData;
        private Charms charmsData;
        private Gems gemsData;
        private Necklaces necklacesData;
        private Overdrives overdrivesData;

        private void Awake()
        {
            LoadData();
        }
        
        public Weapon GetWeaponByName(string weaponName)
        {
            return weaponsData.GetWeapon(weaponName);
        }
        
        public Charm GetCharmByName(string charmName)
        {
            return charmsData.GetCharm(charmName);
        }
        
        public Gem GetGemByName(string gemName)
        {
            return gemsData.GetGem(gemName);
        }

        public Necklace GetNecklaceByName(string necklaceName)
        {
            return necklacesData.GetNecklace(necklaceName);
        }
        
        public Overdrive GetOverdriveByName(string overdriveName)
        {
            return overdrivesData.GetOverdrive(overdriveName);
        }

        public BaseData GetEquipmentDataByName<T>(string equipmentName)
        {
            if (typeof(T) == typeof(Weapon))
            {
                return GetWeaponByName(equipmentName);
            }
            else if (typeof(T) == typeof(Charm))
            {
                return GetCharmByName(equipmentName);
            }
            else if (typeof(T) == typeof(Gem))
            {
                return GetGemByName(equipmentName);
            }
            else if (typeof(T) == typeof(Necklace))
            {
                return GetNecklaceByName(equipmentName);
            }
            else if (typeof(T) == typeof(Overdrive))
            {
                return GetOverdriveByName(equipmentName);
            }
            else
            {
                return null;
            }
        }

        private void LoadData()
        {
            weaponsData = JsonConvert
                .DeserializeObject<Weapons>(weaponsDataFile.text);
            charmsData = JsonConvert
                .DeserializeObject<Charms>(charmsDataFile.text);
            gemsData = JsonConvert
                .DeserializeObject<Gems>(gemsDataFile.text);
            necklacesData = JsonConvert
                .DeserializeObject<Necklaces>(necklacesDataFile.text);
            overdrivesData = JsonConvert
                .DeserializeObject<Overdrives>(overdrivesDataFile.text);
        }
    }
}