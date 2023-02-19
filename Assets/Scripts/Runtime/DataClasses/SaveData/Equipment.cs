using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.SaveData
{
    /// <summary>
    /// A party member's equipment.
    /// </summary>
    [Serializable]
    internal sealed class Equipment
    {
        [JsonProperty("hat")]
        public string Hat { get; }
        
        [JsonProperty("shirt")]
        public string Shirt { get; }
        
        [JsonProperty("shoulders")]
        public string Shoulders { get; }
        
        [JsonProperty("gloves")]
        public string Gloves { get; }
        
        [JsonProperty("pants")]
        public string Pants { get; }
        
        [JsonProperty("boots")]
        public string Boots { get; }

        public Equipment(
            [JsonProperty("hat")] string hat,
            [JsonProperty("shirt")] string shirt,
            [JsonProperty("shoulders")] string shoulders,
            [JsonProperty("gloves")] string gloves,
            [JsonProperty("pants")] string pants,
            [JsonProperty("boots")] string boots
        )
        {
            Hat = hat;
            Shirt = shirt;
            Shoulders = shoulders;
            Gloves = gloves;
            Pants = pants;
            Boots = boots;
        }
    }
}