using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.ItemData
{
    /// <summary>
    /// Database of all charms in game.
    /// </summary>
    internal sealed class Charms
    {
        [JsonProperty("charms")]
        public IEnumerable<Charm> CharmsDatabase { get; }
        
        [JsonConstructor]
        public Charms([JsonProperty("charms")] IEnumerable<Charm> charms)
        {
            CharmsDatabase = charms;
        }
        
        public Charm GetCharm(string charmName)
        {
            foreach (var t in CharmsDatabase.Where(t => t.CharmName == charmName))
            {
                return t;
            }

            throw new Exception($"The Charm {charmName} was not found.");
        }
    }

    /// <summary>
    /// An individual charm in the charms database.
    /// </summary>
    internal sealed class Charm
    {
        [JsonProperty("charmName")]
        public string CharmName { get; }
        
        [JsonProperty("charmAttack")]
        public int CharmAttack { get; }
        
        [JsonProperty("charmHeal")]
        public int CharmHeal { get; }
        
        [JsonProperty("charmStatusEffect")]
        public string CharmStatusEffect { get; }
        
        [JsonProperty("charmStatusEffectChance")]
        public float CharmStatusEffectChance { get; }

        public Charm(
            [JsonProperty("charmName")] string charmName,
            [JsonProperty("charmAttack")] int charmAttack,
            [JsonProperty("charmHeal")] int charmHeal,
            [JsonProperty("charmStatusEffect")] string charmStatusEffect,
            [JsonProperty("charmStatusEffectChance")] float charmStatusEffectChance
        )
        {
            CharmName = charmName;
            CharmAttack = charmAttack;
            CharmHeal = charmHeal;
            CharmStatusEffect = charmStatusEffect;
            CharmStatusEffectChance = charmStatusEffectChance;
        }
    }
}