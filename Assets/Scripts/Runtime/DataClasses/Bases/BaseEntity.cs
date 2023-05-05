using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.Bases
{
    internal class BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("health")]
        public int Health { get; set; }

        [JsonProperty("maxHealth")]
        public int MaxHealth { get; set; }

        [JsonProperty("magic")]
        public int Magic { get; set; }

        [JsonProperty("maxMagic")]
        public int MaxMagic { get; set; }

        [JsonProperty("basePhysicalAttack")]
        public int BasePhysicalAttack { get; set; }

        [JsonProperty("baseMagicAttack")]
        public int BaseMagicAttack { get; set; }

        [JsonProperty("baseDefense")]
        public int BaseDefense { get; set; }

        [JsonProperty("baseSpeed")]
        public int BaseSpeed { get; set; }
    }
}