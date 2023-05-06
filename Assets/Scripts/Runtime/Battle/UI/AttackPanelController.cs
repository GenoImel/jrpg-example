using System.Linq;
using Jrpg.Core;
using Jrpg.Runtime.DataClasses.EquipmentData;
using UnityEngine;

namespace Jrpg.Runtime.Battle.UI
{
    internal sealed class AttackPanelController : OptionsPanelController
    {
        [SerializeField] 
        private Option overdriveOptionPrefab;

        protected override void InitializePanel()
        {
            var listAttacks = partyMember.ActiveWeapons.LeftHandWeapon.GemSlots
                .Concat(partyMember.ActiveWeapons.RightHandWeapon.GemSlots);

            InitializePanelOptions<Gem>(listAttacks);

            if (!partyMember.OverdriveAchieved)
            {
                return;
            }
            var overdrive = Instantiate(overdriveOptionPrefab, optionsContainer.transform);
            listOptions.Add(overdrive);
        }

        private void OnUpdateOverdriveAchievedMessage(UpdateOverdriveAchievedMessage message)
        {
            if (message.PartyMember != partyMember)
            {
                return;
            }
            
            var overdrive = Instantiate(overdriveOptionPrefab, optionsContainer.transform);
            listOptions.Add(overdrive);
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            
            GameManager.AddListener<UpdateOverdriveAchievedMessage>(OnUpdateOverdriveAchievedMessage);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            
            GameManager.RemoveListener<UpdateOverdriveAchievedMessage>(OnUpdateOverdriveAchievedMessage);
        }
    }
}
