using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.PartyData
{
    /// <summary>
    /// An equipped weapon and it's gem slots.
    /// </summary>
    [Serializable]
    internal sealed class ActiveWeapon
    {
        [JsonProperty("weaponName")]
        public string WeaponName { get; }
        
        [JsonProperty("numGemSlots")]
        public int NumGemSlots { get; }
        
        [JsonProperty("gemSlots")]
        public List<string> GemSlots { get; }

        public ActiveWeapon(
            [JsonProperty("weaponName")] string weaponName,
            [JsonProperty("numGemSlots")] int numGemSlots,
            [JsonProperty("gemSlots")] List<string> gemSlots
        )
        {
            WeaponName = weaponName;
            NumGemSlots = numGemSlots;
            GemSlots = gemSlots;
        }
    }
}