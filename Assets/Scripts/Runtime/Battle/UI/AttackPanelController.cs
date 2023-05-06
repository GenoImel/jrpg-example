using System.Linq;
using Jrpg.Core;
using Jrpg.Runtime.Systems.EquipmentData;
using UnityEngine;

namespace Jrpg.Runtime.Battle.UI
{
    internal sealed class AttackPanelController : OptionsPanelController
    {
        [SerializeField] 
        private Option overdriveOptionPrefab;

        private IEquipmentDataSystem equipmentDataSystem;

        protected override void Awake()
        {
            base.Awake();
            
            equipmentDataSystem = GameManager.GetSystem<IEquipmentDataSystem>();
        }

        protected override void InitializePanelOptions()
        {
            var listAttacks = partyMember.ActiveWeapons.LeftHandWeapon.GemSlots
                .Concat(partyMember.ActiveWeapons.RightHandWeapon.GemSlots);

            foreach (var attack in listAttacks)
            {
                if (string.IsNullOrWhiteSpace(attack) || string.IsNullOrEmpty(attack))
                {
                    continue;
                }

                var gem = equipmentDataSystem.GetGem(attack);
                var option = Instantiate(optionPrefab, optionsContainer.transform);
                    option.InitializeAttackOption(gem.GemName, gem);
                    listOptions.Add(option);
            }

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
            
            GameManager.AddListener<PartyMemberSelectedMessage>(OnPartyMemberSelected);
            GameManager.AddListener<UpdateOverdriveAchievedMessage>(OnUpdateOverdriveAchievedMessage);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            
            GameManager.RemoveListener<PartyMemberSelectedMessage>(OnPartyMemberSelected);
            GameManager.RemoveListener<UpdateOverdriveAchievedMessage>(OnUpdateOverdriveAchievedMessage);
        }
    }
}
