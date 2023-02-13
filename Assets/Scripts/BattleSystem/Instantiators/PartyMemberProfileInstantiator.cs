using UnityEngine;

namespace JRPG.BattleSystem.Instantiators
{
    internal sealed class PartyMemberProfileInstantiator : MonoBehaviour
    {
        void Awake()
        {
            BattlePartyMember.OnPartyMemberAdded += OnNewPartyMemberAdded;
        }

        private void OnNewPartyMemberAdded(BattlePartyMember battlePartyMember)
        {
            var ui = Instantiate(
                battlePartyMember.ProfileUI,
                this.transform
            );

            ui.CharacterName = battlePartyMember.CharacterName;
            ui.ProfilePicture = battlePartyMember.ProfilePicture;
            ui.PartyMember = battlePartyMember;
        }

    }
}
