using Jrpg.Core;
using Jrpg.Runtime.DataClasses.Bases;
using Jrpg.Runtime.DataClasses.EquipmentData;

namespace Jrpg.Runtime.Systems.EquipmentData
{
    internal interface IEquipmentDataSystem : ISystem
    {
        /// <summary>
        /// Gets a weapon from the weapons database using <paramref name="weaponName"/>.
        /// </summary>
        public Weapon GetWeaponByName(string weaponName);
        
        /// <summary>
        /// Gets a charm from the charms database using <paramref name="charmName"/>.
        /// </summary>
        public Charm GetCharmByName(string charmName);
        
        /// <summary>
        /// Gets a gem from the gems database using <paramref name="gemName"/>.
        /// </summary>
        public Gem GetGemByName(string gemName);
        
        /// <summary>
        /// Gets a necklace from the necklaces database using <paramref name="necklaceName"/>.
        /// </summary>
        public Necklace GetNecklaceByName(string necklaceName);

        /// <summary>
        /// Gets a equipment from the equipment database using <paramref name="equipmentName"/>.
        /// </summary>
        public BaseData GetEquipmentDataByName<T>(string equipmentName);
    }
}