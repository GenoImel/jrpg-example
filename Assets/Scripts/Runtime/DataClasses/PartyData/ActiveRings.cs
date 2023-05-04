using System;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.PartyData
{
    /// <summary>
    /// All currently equipped rings.
    /// </summary>
    [Serializable]
    internal sealed class ActiveRings
    {
        [JsonProperty("leftRing1")]
        public string LeftRing1 { get; }
        
        [JsonProperty("leftRing2")]
        public string LeftRing2 { get; }
        
        [JsonProperty("rightRing1")]
        public string RightRing1 { get; }
        
        [JsonProperty("rightRing2")]
        public string RightRing2 { get; }

        public ActiveRings(
            [JsonProperty("leftRing1")] string leftRing1,
            [JsonProperty("leftRing2")] string leftRing2,
            [JsonProperty("rightRing1")] string rightRing1,
            [JsonProperty("rightRing2")] string rightRing2
        )
        {
            LeftRing1 = leftRing1;
            LeftRing2 = leftRing2;
            RightRing1 = rightRing1;
            RightRing2 = rightRing2;
        }
    }
}