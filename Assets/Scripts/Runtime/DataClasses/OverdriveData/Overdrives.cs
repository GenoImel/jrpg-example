using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.OverdriveData
{
    /// <summary>
    /// Database of all overdrives in game.
    /// </summary>
    internal sealed class Overdrives
    {
        [JsonProperty("overdrives")]
        public IEnumerable<Overdrive> OverdrivesDatabase { get; }
        
        [JsonConstructor]
        public Overdrives([JsonProperty("overdrives")] IEnumerable<Overdrive> overdrives)
        {
            OverdrivesDatabase = overdrives;
        }
        
        public Overdrive GetOverdrive(string overdriveName)
        {
            foreach (var t in OverdrivesDatabase)
            {
                if (t.OverdriveName == overdriveName)
                {
                    return t;
                }
            }

            throw new KeyNotFoundException($"The Overdrive {overdriveName} was not found.");
        }
    }

    /// <summary>
    /// An individual overdrive in the overdrives database.
    /// </summary>
    internal sealed class Overdrive
    {
        [JsonProperty("overdriveName")]
        public string OverdriveName { get; }
        
        [JsonProperty("description")]
        public string Description { get; }
        
        [JsonProperty("partyMember")]
        public string PartyMember { get; }
        
        [JsonProperty("levelAcquired")]
        public int LevelAcquired { get; }
        
        [JsonProperty("overdriveAttack")]
        public int OverdriveAttack { get; }
        
        public Overdrive(
            [JsonProperty("overdriveName")] string overdriveName,
            [JsonProperty("description")] string description,
            [JsonProperty("partyMember")] string partyMember,
            [JsonProperty("levelAcquired")] int levelAcquired,
            [JsonProperty("overdriveAttack")] int overdriveAttack
        )
        {
            OverdriveName = overdriveName;
            Description = description;
            PartyMember = partyMember;
            LevelAcquired = levelAcquired;
            OverdriveAttack = overdriveAttack;
        }
    }
}