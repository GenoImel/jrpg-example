using Jrpg.Core;
using Jrpg.Runtime.DataClasses.EquipmentData;
using Jrpg.Runtime.DataClasses.ItemData;

namespace Jrpg.Runtime.Systems.EquipmentData
{
    internal interface IEquipmentDataSystem : ISystem
    {
        /// <summary>
        /// Gets a weapon from the weapons database using <param name="weaponName"></param>.
        /// </summary>
        public Weapon GetWeapon(string weaponName);
        
        /// <summary>
        /// Gets a charm from the charms database using <param name="charmName"></param>.
        /// </summary>
        public Charm GetCharm(string charmName);
        
        /// <summary>
        /// Gets a gem from the gems database using <param name="gemName"></param>.
        /// </summary>
        public Gem GetGem(string gemName);
        
        /// <summary>
        /// Gets a necklace from the necklaces database using <param name="necklaceName"></param>.
        /// </summary>
        public Necklace GetNecklace(string necklaceName);
    }
}