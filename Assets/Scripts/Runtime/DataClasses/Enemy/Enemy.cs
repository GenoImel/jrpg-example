using Jrpg.Runtime.DataClasses.Bases;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.Enemy
{
    internal sealed class BattleEnemy : BaseEntity
    {
        [JsonConstructor]
        public BattleEnemy(
            [JsonProperty("name")] string name,
            [JsonProperty("level")] int level,
            [JsonProperty("health")] int health,
            [JsonProperty("maxHealth")] int maxHealth,
            [JsonProperty("magic")] int magic,
            [JsonProperty("maxMagic")] int maxMagic,
            [JsonProperty("basePhysicalAttack")] int basePhysicalAttack,
            [JsonProperty("baseMagicAttack")] int baseMagicAttack,
            [JsonProperty("baseDefense")] int baseDefense,
            [JsonProperty("baseSpeed")] int baseSpeed
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
        }
    }
}