using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.PartyData
{
    /// <summary>
    /// Currently equipped necklace and charms.
    /// </summary>
    [Serializable]
    internal sealed class ActiveNecklace
    {
        [JsonProperty("necklaceName")]
        public string NecklaceName { get; }
        
        [JsonProperty("numCharmSlots")]
        public int NumCharmSlots { get; }
        
        [JsonProperty("charms")]
        public List<string> Charms { get; }

        public ActiveNecklace(
            [JsonProperty("necklaceName")] string necklaceName,
            [JsonProperty("numCharmSlots")] int numCharmSlots,
            [JsonProperty("charms")] List<string> charms
        )
        {
            NecklaceName = necklaceName;
            NumCharmSlots = numCharmSlots;
            Charms = charms;
        }
    }
}