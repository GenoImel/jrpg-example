using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.ItemData
{
    /// <summary>
    /// Database of all necklaces in game.
    /// </summary>
    internal sealed class Necklaces
    {
        [JsonProperty("necklaces")]
        public IEnumerable<Necklace> NecklacesDatabase { get; }
        
        [JsonConstructor]
        public Necklaces([JsonProperty("necklaces")] IEnumerable<Necklace> necklaces)
        {
            NecklacesDatabase = necklaces;
        }
        
        public Necklace GetNecklace(string necklaceName)
        {
            foreach (var t in NecklacesDatabase.Where(t => t.NecklaceName == necklaceName))
            {
                return t;
            }

            throw new Exception($"The Necklace {necklaceName} was not found.");
        }
    }

    /// <summary>
    /// An individual necklace in the necklaces database.
    /// </summary>
    internal sealed class Necklace
    {
        [JsonProperty("necklaceName")]
        public string NecklaceName { get; }
        
        [JsonProperty("necklaceType")]
        public int Description { get; }
        
        [JsonProperty("necklaceAttack")]
        public int NumCharmSlots { get; }

        public Necklace(
            [JsonProperty("gemName")] string necklaceNameName,
            [JsonProperty("gemType")] int description,
            [JsonProperty("gemAttack")] int numCharmSlots
        )
        {
            NecklaceName = necklaceNameName;
            Description = description;
            NumCharmSlots = numCharmSlots;
        }
    }
}