using UnityEngine;
using UnityEngine.Events;

namespace JRPG.BattleSystem
{
    internal sealed class PartyMemberUICreator : MonoBehaviour
    {

        void Awake()
        {
            PartyMember.OnPartyMemberAdded += OnNewPartyMemberAdded;
        }

        public void OnNewPartyMemberAdded(PartyMember partyMember)
        {
            Instantiate(
                partyMember.partyMemberUIPrefab,
                this.transform
            );
        }

    }
}
