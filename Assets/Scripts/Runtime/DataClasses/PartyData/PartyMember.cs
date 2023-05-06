using Jrpg.Runtime.DataClasses.Bases;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.PartyData
{
    /// <summary>
    /// An active party member, their stats, and their equipment.
    /// </summary>
    internal sealed class PartyMember : BaseEntity
    {
        [JsonProperty("overdriveLevel")]
        public int OverdriveLevel { get; set; }
        
        [JsonProperty("overdriveAchieved")]
        public bool OverdriveAchieved { get; set; }
        
        [JsonProperty("positionOnField")]
        public string PositionOnField { get; }

        [JsonProperty("handedness")]
        public string Handedness { get; }

        [JsonProperty("equipment")]
        public Equipment Equipment { get; }

        [JsonProperty("activeRings")]
        public ActiveRings ActiveRings { get; }

        [JsonProperty("activeNecklace")]
        public ActiveNecklace ActiveNecklace { get; }

        [JsonProperty("activeWeapons")]
        public ActiveWeapons ActiveWeapons { get; }
        
        [JsonConstructor]
        public PartyMember(
            [JsonProperty("name")] string name,
            [JsonProperty("level")] int level,
            [JsonProperty("health")] int health,
            [JsonProperty("overdriveLevel")] int overdriveLevel,
            [JsonProperty("overdriveAchieved")] bool overdriveAchieved,
            [JsonProperty("maxHealth")] int maxHealth,
            [JsonProperty("magic")] int magic,
            [JsonProperty("maxMagic")] int maxMagic,
            [JsonProperty("basePhysicalAttack")] int basePhysicalAttack,
            [JsonProperty("baseMagicAttack")] int baseMagicAttack,
            [JsonProperty("baseDefense")] int baseDefense, 
            [JsonProperty("baseSpeed")] int baseSpeed,
            [JsonProperty("positionOnField")] string positionOnField,
            [JsonProperty("handedness")] string handedness,
            [JsonProperty("equipment")] Equipment equipment, 
            [JsonProperty("activeRings")] ActiveRings activeRings,
            [JsonProperty("activeNecklace")] ActiveNecklace activeNecklace,
            [JsonProperty("activeWeapons")] ActiveWeapons activeWeapons
        )
        {
            Name = name;
            Level = level;
            Health = health;
            OverdriveLevel = overdriveLevel;
            OverdriveAchieved = overdriveAchieved;
            MaxHealth = maxHealth;
            Magic = magic;
            MaxMagic = maxMagic;
            BasePhysicalAttack = basePhysicalAttack;
            BaseMagicAttack = baseMagicAttack;
            BaseDefense = baseDefense;
            BaseSpeed = baseSpeed;
            PositionOnField = positionOnField;
            Handedness = handedness;
            Equipment = equipment;
            ActiveRings = activeRings;
            ActiveNecklace = activeNecklace;
            ActiveWeapons = activeWeapons;
        }
    }
}