using System;
using System.Collections.Generic;
using System.Linq;
using Jrpg.Runtime.DataClasses.Bases;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.EquipmentData
{
    /// <summary>
    /// Database of all weapons in game.
    /// </summary>
    internal sealed class Weapons
    {
        [JsonProperty("weapons")]
        public IEnumerable<Weapon> WeaponsDatabase { get; }
        
        [JsonConstructor]
        public Weapons([JsonProperty("weapons")] IEnumerable<Weapon> weapons)
        {
            WeaponsDatabase = weapons;
        }

        public Weapon GetWeapon(string weaponName)
        {
            foreach (var t in WeaponsDatabase.Where(t => t.Name == weaponName))
            {
                return t;
            }

            throw new Exception($"The Weapon {weaponName} was not found.");
        }
    }

    /// <summary>
    /// An individual weapon in the weapons database.
    /// </summary>
    internal sealed class Weapon : BaseEquipment
    {
        [JsonProperty("weaponType")]
        public string WeaponType { get; }
        
        [JsonProperty("weaponStance")]
        public string WeaponStance { get; }

        [JsonProperty("weaponAttack")]
        public int WeaponAttack { get; }
        
        [JsonProperty("weaponDefense")]
        public int WeaponDefense { get; }
        
        [JsonProperty("weaponSpeed")]
        public int WeaponSpeed { get; }
        
        [JsonProperty("weaponGemSlots")]
        public int WeaponGemSlots { get; }
        
        public Weapon(
            [JsonProperty("weaponName")] string weaponName,
            [JsonProperty("weaponType")] string weaponType,
            [JsonProperty("weaponStance")] string weaponStance,
            [JsonProperty("weaponAttack")] int weaponAttack,
            [JsonProperty("weaponDefense")] int weaponDefense,
            [JsonProperty("weaponSpeed")] int weaponSpeed,
            [JsonProperty("weaponGemSlots")] int weaponGemSlots
            
        )
        {
            Name = weaponName;
            WeaponType = weaponType;
            WeaponStance = weaponStance;
            WeaponAttack = weaponAttack;
            WeaponDefense = weaponDefense;
            WeaponSpeed = weaponSpeed;
            WeaponGemSlots = weaponGemSlots;
        }
    }
}