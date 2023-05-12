using System.Linq;
using Jrpg.Core;
using Jrpg.Runtime.DataClasses.EquipmentData;
using Jrpg.Runtime.DataClasses.OverdriveData;
using UnityEngine;
using UnityEngine.Serialization;

namespace Jrpg.Runtime.Battle.UI
{
    internal sealed class AttackPanelController : OptionsPanelController
    {
        [Header("UI")]
        [SerializeField] 
        private Option activeOverdriveOptionPrefab;

        [SerializeField] 
        private Option overdriveOptionPrefab;

        [SerializeField] private SelectionMode selectionMode = SelectionMode.Attack;

        private enum SelectionMode
        {
            Attack,
            Overdrive
        }

        protected override void InitializePanel()
        {
            switch (selectionMode)
            {
                case SelectionMode.Attack:
                    InitializeAttackPanel();
                    break;
                case SelectionMode.Overdrive:
                    InitializeOverdrivePanel();
                    break;
            }
            
        }

        private void InitializeAttackPanel()
        {
            var listAttacks = partyMember.ActiveWeapons.LeftHandWeapon.GemSlots
                .Concat(partyMember.ActiveWeapons.RightHandWeapon.GemSlots);

            InitializePanelOptions<Gem>(listAttacks);

            if (!partyMember.OverdriveAchieved)
            {
                return;
            }
            var overdrive = Instantiate(activeOverdriveOptionPrefab, optionsContainer.transform);
            listOptions.Add(overdrive);
        }

        private void InitializeOverdrivePanel()
        {
            var listOverdrives = partyMember.Overdrives;
            
            InitializePanelOptions<Overdrive>(listOverdrives, overdriveOptionPrefab);
        }

        private void OnUpdateOverdriveAchievedMessage(UpdateOverdriveAchievedMessage message)
        {
            if (message.PartyMember != partyMember)
            {
                return;
            }
            
            var overdrive = Instantiate(activeOverdriveOptionPrefab, optionsContainer.transform);
            listOptions.Add(overdrive);
        }
        
        private void OnActivateOverdriveMessageReceived(ActivateOverdriveMessage message)
        {
            selectionMode = SelectionMode.Overdrive;
            
            ResetPanel();
            InitializePanel();
        }

        protected override void OnPartyMemberSelected(PartyMemberSelectedMessage message)
        {
            selectionMode = SelectionMode.Attack;
            base.OnPartyMemberSelected(message);
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            
            GameManager.AddListener<UpdateOverdriveAchievedMessage>(OnUpdateOverdriveAchievedMessage);
            GameManager.AddListener<ActivateOverdriveMessage>(OnActivateOverdriveMessageReceived);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            
            GameManager.RemoveListener<UpdateOverdriveAchievedMessage>(OnUpdateOverdriveAchievedMessage);
            GameManager.RemoveListener<ActivateOverdriveMessage>(OnActivateOverdriveMessageReceived);
        }
    }
}
