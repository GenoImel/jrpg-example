using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.PartyData
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

        public PartyMember GetPartyMember(string name)
        {
            foreach (var t in PartyMembers.Where(t => t.Name == name))
            {
                return t;
            }

            throw new Exception($"Party Member {name} was not found.");
        }
        
        public void UpdatePartyMember(PartyMember updatedPartyMember)
        {
            for (var i = 0; i < PartyMembers.Count; i++)
            {
                if (PartyMembers[i].Name == updatedPartyMember.Name)
                {
                    PartyMembers[i] = updatedPartyMember;
                    break;
                }
            }
        }
    }
}
