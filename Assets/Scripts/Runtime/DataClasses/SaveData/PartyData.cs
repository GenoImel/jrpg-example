using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.SaveData
{
    /// <summary>
    /// Currently active party members.
    /// </summary>
    [Serializable]
    internal sealed class PartyData
    {
        [JsonProperty("partyMembers")]
        public List<PartyMember> PartyMembers { get; }

        [JsonConstructor]
        public PartyData([JsonProperty("partyMembers")] List<PartyMember> partyMembers)
        {
            PartyMembers = partyMembers;
        }

        public void AddPartyMember(PartyMember partyMember)
        {
            PartyMembers.Add(partyMember);
        }

        public void RemovePartyMember(PartyMember partyMember)
        {
            PartyMembers.Remove(partyMember);
        }
    }
}
