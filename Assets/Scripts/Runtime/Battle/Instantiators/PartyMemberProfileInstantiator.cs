using Jrpg.Core;
using UnityEngine;

namespace Jrpg.Runtime.Battle.Instantiators
{
    internal sealed class PartyMemberProfileInstantiator : MonoBehaviour
    {
        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void OnNewPartyMemberAdded(PartyMemberAddedMessage message)
        {
            var ui = Instantiate(
                message.PartyMember.StateMachine.ProfileUI,
                transform
            );

            ui.CharacterName = message.PartyMember.GetCharacterName();
            ui.ProfilePicture = message.PartyMember.ProfilePicture;
            ui.PartyMember = message.PartyMember.StateMachine;
        }

        private void AddListeners()
        {
            GameManager.AddListener<PartyMemberAddedMessage>(OnNewPartyMemberAdded);
        }

        private void RemoveListeners()
        {
            GameManager.RemoveListener<PartyMemberAddedMessage>(OnNewPartyMemberAdded);
        }

    }
}
