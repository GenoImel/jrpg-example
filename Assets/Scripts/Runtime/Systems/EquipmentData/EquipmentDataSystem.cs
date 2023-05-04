using Jrpg.Runtime.DataClasses.ItemData;
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

        private Weapons weaponsData;
        private Charms charmsData;
        private Gems gemsData;
        private Necklaces necklacesData;

        private void Awake()
        {
            LoadData();
        }
        
        public Weapon GetWeapon(string weaponName)
        {
            return weaponsData.GetWeapon(weaponName);
        }
        
        public Charm GetCharm(string charmName)
        {
            return charmsData.GetCharm(charmName);
        }
        
        public Gem GetGem(string gemName)
        {
            return gemsData.GetGem(gemName);
        }

        public Necklace GetNecklace(string necklaceName)
        {
            return necklacesData.GetNecklace(necklaceName);
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
        }
    }
}