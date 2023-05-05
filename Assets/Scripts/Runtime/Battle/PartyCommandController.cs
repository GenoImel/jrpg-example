using System.Collections.Generic;
using System.Linq;
using Jrpg.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Jrpg.Runtime.Battle
{
    internal sealed class PartyCommandController : MonoBehaviour
    {
        [Header("Controls")] 
        [SerializeField] 
        private InputActionReference axes;
        
        [SerializeField] 
        private float inputDelaySeconds = 0.25f;
        
        private enum SelectionMode
        {
            PartyMemberSelection,
            TargetSelection
        }

        [SerializeField]
        private SelectionMode selectionMode = SelectionMode.PartyMemberSelection;
        
        [Header("Party Members Waiting for Commands")]
        [SerializeField] 
        private List<BattlePartyMember> readyPartyMembers = new();
        
        [Header("Party Members on Field")]
        [SerializeField]
        private List<BattlePartyMember> partyMembers = new();

        [Header("Enemies")]
        private List<BattleEnemy> enemies = new();
        
        private List<BaseBattleEntity> allEntities = new();

        private BaseBattleEntity defaultDamageTarget;

        private BaseBattleEntity defaultHealTarget;
        
        private int partyIndex;

        private int entityIndex;
        
        private bool isMemberSelected;
        
        private float delayCounterSeconds;

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
            
            var direction = GetAxisValueAsInt(axes.action.ReadValue<Vector2>().x);

            if (direction == 0)
            {
                return;
            }

            switch (selectionMode)
            {
                case SelectionMode.PartyMemberSelection:
                    if (readyPartyMembers.Count > 0)
                    {
                        PartyIndexChanged(direction);
                    }
                    break;
                
                case SelectionMode.TargetSelection:
                    EntityIndexChanged(direction);
                    break;
            }
            

        }

        private void OnNewPartyMemberReady(PartyMemberReadyForInputMessage message)
        {
            readyPartyMembers.Add(message.PartyMember);
            SelectPartyMember();
        }
        
        private void OnPartyMemberSelectionModeEnabled(PartyMemberSelectionModeEnabledMessage message)
        {
            selectionMode = SelectionMode.PartyMemberSelection;
            SelectPartyMember();
        }
        
        private void OnTargetSelectionModeEnabled(TargetSelectionModeEnabledMessage message)
        {
            selectionMode = SelectionMode.TargetSelection;
            SelectDefaultTargetEntity();
        }

        private void SelectDefaultTargetEntity()
        {
            var index = allEntities.IndexOf(enemies[0]);
            entityIndex = index;
            SelectEntity(entityIndex);
        }

        private void SelectPartyMember()
        {
            if (!readyPartyMembers.Any())
            {
                return;
            }
            
            if (isMemberSelected)
            {
                return;
            }

            GameManager.Publish(new BattleCommandsEnabledMessage(true));

            if (readyPartyMembers.Any())
            {
                if (partyIndex >= readyPartyMembers.Count())
                {
                    partyIndex = 0;
                }
                var selectedMember = readyPartyMembers.ElementAt(partyIndex);
                NotifyOfSelectedPartyMember(selectedMember);
            }

            isMemberSelected = true;
        }

        private void NotifyOfSelectedPartyMember(BattlePartyMember battlePartyMember)
        {
            GameManager.Publish(new PartyMemberSelectedMessage(battlePartyMember));
        }
        
        private void NotifyOfSelectedEntity(BaseBattleEntity baseBattleEntity)
        {
            GameManager.Publish(new BattleEntitySelectedMessage(baseBattleEntity));
        }

        private void PartyIndexChanged(int direction)
        {
            partyIndex = (partyIndex + direction + readyPartyMembers.Count) % readyPartyMembers.Count;
                
            SelectPartyMember(partyIndex);

            delayCounterSeconds = 0;
        }

        private void SelectPartyMember(int index)
        {
            var selectedMember = readyPartyMembers.ElementAt(index);
            NotifyOfSelectedPartyMember(selectedMember);
        }

        private void EntityIndexChanged(int direction)
        {
            entityIndex = (entityIndex + direction + allEntities.Count) % allEntities.Count;
            
            SelectEntity(entityIndex);
            
            delayCounterSeconds = 0;
        }

        private void SelectEntity(int index)
        {
            var selectedEntity = allEntities.ElementAt(index);
            NotifyOfSelectedEntity(selectedEntity);
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
            
            GameManager.AddListener<PartyMemberAddedToFieldMessage>
                (msg => partyMembers.Add(msg.PartyMember));
            GameManager.AddListener<PartyMemberAddedToFieldMessage>
                (msg => allEntities.Add(msg.PartyMember));
            GameManager.AddListener<EnemyAddedToFieldMessage>
                (msg => enemies.Add(msg.Enemy));
            GameManager.AddListener<EnemyAddedToFieldMessage>
                (msg => allEntities.Add(msg.Enemy));
            
            GameManager.AddListener<PartyMemberSelectionModeEnabledMessage>
                (OnPartyMemberSelectionModeEnabled);
            GameManager.AddListener<TargetSelectionModeEnabledMessage>
                (OnTargetSelectionModeEnabled);
            
            axes.action.Enable();
        }

        private void RemoveListeners()
        {
            GameManager.RemoveListener<PartyMemberReadyForInputMessage>(OnNewPartyMemberReady);
            
            GameManager.RemoveListener<PartyMemberAddedToFieldMessage>
                (msg => partyMembers.Add(msg.PartyMember));
            GameManager.RemoveListener<PartyMemberAddedToFieldMessage>
                (msg => allEntities.Add(msg.PartyMember));
            GameManager.RemoveListener<EnemyAddedToFieldMessage>
                (msg => enemies.Add(msg.Enemy));
            GameManager.RemoveListener<EnemyAddedToFieldMessage>
                (msg => allEntities.Add(msg.Enemy));
            
            GameManager.RemoveListener<PartyMemberSelectionModeEnabledMessage>
                (OnPartyMemberSelectionModeEnabled);
            GameManager.RemoveListener<TargetSelectionModeEnabledMessage>
                (OnTargetSelectionModeEnabled);
            
            axes.action.Disable();
        }
    }
}
