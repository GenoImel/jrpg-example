using System.Collections.Generic;
using System.Linq;
using Jrpg.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Jrpg.Runtime.BattleSystem
{
    internal sealed class PartyCommandController : MonoBehaviour
    {
        [Header("Controls")] 
        [SerializeField] 
        private InputActionReference axes;
        
        [SerializeField] 
        private float inputDelaySeconds = 0.25f;

        [Header("Party Members")]
        [SerializeField] 
        private List<BattlePartyMember> partyMembers = new();
        
        private int partyIndex = 0;

        private bool isMemberSelected = false;
        private float delayCounterSeconds = 0f;

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void FixedUpdate()
        {
            delayCounterSeconds += Time.deltaTime;
            if (delayCounterSeconds < inputDelaySeconds)
            {
                return;
            }
            
            if (partyMembers.Count > 0)
            {
                var direction = GetAxisValueAsInt(axes.action.ReadValue<Vector2>().x);

                if (direction == 0)
                {
                    return;
                }
                
                PartyIndexChanged(direction);
            }
        }

        private void OnNewPartyMemberReady(PartyMemberReadyForInputMessage message)
        {
            partyMembers.Add(message.PartyMember);
            SelectPartyMember();
        }
        
        private void SelectPartyMember()
        {
            if (!partyMembers.Any())
            {
                return;
            }
            
            if (isMemberSelected)
            {
                return;
            }

            GameManager.Publish(new BattleCommandsEnabledMessage(true));

            if (partyMembers.Any())
            {
                if (partyIndex >= partyMembers.Count())
                {
                    partyIndex = 0;
                }
                var selectedMember = partyMembers.ElementAt(partyIndex);
                NotifyOfSelectedPartyMember(selectedMember);
            }

            isMemberSelected = true;
        }

        private void NotifyOfSelectedPartyMember(BattlePartyMember battlePartyMember)
        {
            GameManager.Publish(new PartyMemberSelectedMessage(battlePartyMember));
        }

        private void PartyIndexChanged(int direction)
        {
            partyIndex = (partyIndex + direction + partyMembers.Count) % partyMembers.Count;
                
            var selectedMember = partyMembers.ElementAt(partyIndex);
            NotifyOfSelectedPartyMember(selectedMember);

            delayCounterSeconds = 0;
        }

        private int GetAxisValueAsInt(float value)
        {
            if (value == 0f)
            {
                return 0;
            }
            
            return value < 0 ? -1 : 1;
        }

        private void AddListeners()
        {
            GameManager.AddListener<PartyMemberReadyForInputMessage>(OnNewPartyMemberReady);
            
            axes.action.Enable();
        }

        private void RemoveListeners()
        {
            GameManager.RemoveListener<PartyMemberReadyForInputMessage>(OnNewPartyMemberReady);
            
            axes.action.Disable();
        }
    }
}
