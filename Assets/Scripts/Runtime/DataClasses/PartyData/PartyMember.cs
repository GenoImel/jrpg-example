using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.PartyData
{
    /// <summary>
    /// An active party member, their stats, and their equipment.
    /// </summary>
    internal sealed class PartyMember
    {
        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("level")]
        public int Level { get; }

        [JsonProperty("health")]
        public int Health { get; }

        [JsonProperty("maxHealth")]
        public int MaxHealth { get; }

        [JsonProperty("magic")]
        public int Magic { get; }

        [JsonProperty("maxMagic")]
        public int MaxMagic { get; }

        [JsonProperty("basePhysicalAttack")]
        public int BasePhysicalAttack { get; }

        [JsonProperty("baseMagicAttack")]
        public int BaseMagicAttack { get; }

        [JsonProperty("baseDefense")]
        public int BaseDefense { get; }

        [JsonProperty("baseSpeed")]
        public int BaseSpeed { get; }

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