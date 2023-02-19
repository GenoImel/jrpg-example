using System;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.SaveData
{
    /// <summary>
    /// Currently equipped weapons.
    /// </summary>
    [Serializable]
    internal sealed class ActiveWeapons
    {
        [JsonProperty("rightHandWeapon")]
        public ActiveWeapon RightHandWeapon { get; }
        
        [JsonProperty("leftHandWeapon")]
        public ActiveWeapon LeftHandWeapon { get; }

        public ActiveWeapons(
            [JsonProperty("rightHandWeapon")] ActiveWeapon rightHandWeapon,
            [JsonProperty("leftHandWeapon")] ActiveWeapon leftHandWeapon
        )
        {
            RightHandWeapon = rightHandWeapon;
            LeftHandWeapon = leftHandWeapon;
        }
    }
}