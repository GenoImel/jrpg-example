using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.EquipmentData
{
    /// <summary>
    /// Database of all gems in game.
    /// </summary>
    internal sealed class Gems
    {
        [JsonProperty("gems")]
        public IEnumerable<Gem> GemsDatabase { get; }
        
        [JsonConstructor]
        public Gems([JsonProperty("gems")] IEnumerable<Gem> gems)
        {
            GemsDatabase = gems;
        }
        
        public Gem GetGem(string gemName)
        {
            foreach (var t in GemsDatabase.Where(t => t.GemName == gemName))
            {
                return t;
            }

            throw new Exception($"The Gem {gemName} was not found.");
        }
    }

    /// <summary>
    /// An individual gem in the gems database.
    /// </summary>
    internal sealed class Gem
    {
        [JsonProperty("gemName")]
        public string GemName { get; }
        
        [JsonProperty("gemType")]
        public string GemType { get; }
        
        [JsonProperty("gemAttack")]
        public int GemAttack { get; }
        
        [JsonProperty("gemStatusEffect")]
        public string GemStatusEffect { get; }
        
        [JsonProperty("gemStatusEffectChance")]
        public float GemStatusEffectChance { get; }

        public Gem(
            [JsonProperty("gemName")] string gemName,
            [JsonProperty("gemType")] string gemType,
            [JsonProperty("gemAttack")] int gemAttack,
            [JsonProperty("gemStatusEffect")] string gemStatusEffect,
            [JsonProperty("gemStatusEffectChance")] float gemStatusEffectChance
        )
        {
            GemName = gemName;
            GemType = gemType;
            GemAttack = gemAttack;
            GemStatusEffect = gemStatusEffect;
            GemStatusEffectChance = gemStatusEffectChance;
        }
    }
}