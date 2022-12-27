using UnityEngine;

namespace JRPG.BattleSystem
{
    internal sealed class PartyMemberUICreator : MonoBehaviour
    {
        public delegate void PartyMemberUICreated(BattleScreenProfileController ui);

        public static event PartyMemberUICreated OnPartyMemberUICreated;
        
        void Awake()
        {
            BattleScreenPartyMember.OnPartyMemberAdded += OnNewPartyMemberAdded;
        }

        public void OnNewPartyMemberAdded(BattleScreenPartyMember battleScreenPartyMember)
        {
            var ui = Instantiate(
                battleScreenPartyMember.partyMemberUIPrefab,
                this.transform
            );

            //TODO: wrap this in a class so you don't have to GetComponent
            var profileController = ui.GetComponent<BattleScreenProfileController>();
            profileController.battleScreenPartyMember = battleScreenPartyMember;
            
            OnPartyMemberUICreated?.Invoke(profileController);
        }

    }
}
