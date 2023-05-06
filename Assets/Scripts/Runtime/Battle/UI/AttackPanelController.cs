using System.Collections.Generic;
using System.Linq;
using Jrpg.Core;
using Jrpg.Runtime.DataClasses.PartyData;
using Jrpg.Runtime.Systems.EquipmentData;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Jrpg.Runtime.Battle.UI
{
    internal sealed class AttackPanelController : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] 
        private TextMeshProUGUI pageNumberText;

        [SerializeField] 
        private GameObject optionsContainer;

        [SerializeField] 
        private CanvasGroup canvasGroup;

        [SerializeField] 
        private AttackOption attackOptionPrefab;

        [SerializeField] 
        private Option overdriveOptionPrefab;

        [Header("Buttons")] 
        [SerializeField] 
        private InputActionReference attackButton;

        [SerializeField] 
        private InputActionReference incrementOptionIndexButton;
        
        [SerializeField]
        private InputActionReference decrementOptionIndexButton;

        [SerializeField] 
        private List<InputActionReference> otherButtons;

        [Header("Attacks")] 
        [SerializeField] 
        private List<Option> attackOptions;

        private List<GameObject> totalOptions;
        
        private BattlePartyMember partyMember;
        
        private int pageIndex = 0;
        private int optionIndex = 0;

        private bool commandsEnabled;

        private IEquipmentDataSystem equipmentDataSystem;

        private void Awake()
        {
            equipmentDataSystem = GameManager.GetSystem<IEquipmentDataSystem>();
        }

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void OnIncrementOptionIndexButtonPressed(InputAction.CallbackContext context)
        {
            optionIndex -= 1;
            CheckOptionIndex();
            HighlightCurrentOption();
        }
        
        private void OnDecrementOptionIndexButtonPressed(InputAction.CallbackContext context)
        {
            optionIndex += 1;
            CheckOptionIndex();
            HighlightCurrentOption();
        }

        private void CheckOptionIndex()
        {
            if (optionIndex > attackOptions.Count - 1)
            {
                optionIndex = 0;
            }

            if (optionIndex < 0)
            {
                optionIndex = attackOptions.Count - 1;
            }
        }

        private void OnAttackButtonPressed(InputAction.CallbackContext context)
        {
            if (!canvasGroup.interactable && commandsEnabled)
            {
                GameManager.Publish(new PartyMemberSelectionModeEnabledMessage());
                SetPanelActive(true);
                return;
            }
            
            //select attack, switch to targeting panel?
        }

        private void OnAnyOtherFaceButtonPressed(InputAction.CallbackContext context)
        {
            if (canvasGroup.interactable && commandsEnabled)
            {
                SetPanelActive(false);
            }
        }

        private void SetPanelActive(bool isActive)
        {
            canvasGroup.alpha = isActive ? 1f : 0f;
            canvasGroup.interactable = isActive;
            canvasGroup.blocksRaycasts = isActive;
        }

        private void ResetPanel()
        {
            pageIndex = 0;
            pageNumberText.text = (pageIndex + 1).ToString();

            if (attackOptions == null)
            {
                return;
            }

            foreach (var attack in attackOptions)
            {
                var attackObject = attack.gameObject;
                Destroy(attackObject);
            }
            
            attackOptions.Clear();
        }

        private void InitializePanel(PartyMember partyMember)
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
                var option = Instantiate(attackOptionPrefab, optionsContainer.transform);
                    option.InitializeAttackOption(gem.GemName, gem);
                    attackOptions.Add(option);
            }

            if (!partyMember.OverdriveAchieved)
            {
                return;
            }
            var overdrive = Instantiate(overdriveOptionPrefab, optionsContainer.transform);
            attackOptions.Add(overdrive);
        }

        private void HighlightCurrentOption()
        {
            foreach (var attack in attackOptions)
            {
                attack.SetSelected(false);
            }
            
            attackOptions[optionIndex].SetSelected(true);
        }

        private void OnPartyMemberSelected(PartyMemberSelectedMessage message)
        {
            partyMember = message.PartyMember;
            commandsEnabled = true;
            ResetPanel();
            InitializePanel(message.PartyMember.GetEntityData());
            HighlightCurrentOption();
        }

        private void OnUpdateOverdriveAchievedMessage(UpdateOverdriveAchievedMessage message)
        {
            if (message.PartyMember != partyMember)
            {
                return;
            }
            
            var overdrive = Instantiate(overdriveOptionPrefab, optionsContainer.transform);
            attackOptions.Add(overdrive);
        }

        private void AddListeners()
        {
            GameManager.AddListener<PartyMemberSelectedMessage>(OnPartyMemberSelected);
            GameManager.AddListener<UpdateOverdriveAchievedMessage>(OnUpdateOverdriveAchievedMessage);
            
            attackButton.action.performed += OnAttackButtonPressed;
            attackButton.action.Enable();
            
            incrementOptionIndexButton.action.performed += OnIncrementOptionIndexButtonPressed;
            incrementOptionIndexButton.action.Enable();
            
            decrementOptionIndexButton.action.performed += OnDecrementOptionIndexButtonPressed;
            decrementOptionIndexButton.action.Enable();

            foreach (var button in otherButtons)
            {
                button.action.performed += OnAnyOtherFaceButtonPressed;
                button.action.Enable();
            }
        }

        private void RemoveListeners()
        {
            GameManager.RemoveListener<PartyMemberSelectedMessage>(OnPartyMemberSelected);
            GameManager.RemoveListener<UpdateOverdriveAchievedMessage>(OnUpdateOverdriveAchievedMessage);
            
            attackButton.action.performed -= OnAttackButtonPressed;
            attackButton.action.Disable();
            
            incrementOptionIndexButton.action.performed -= OnIncrementOptionIndexButtonPressed;
            incrementOptionIndexButton.action.Disable();
            
            decrementOptionIndexButton.action.performed -= OnDecrementOptionIndexButtonPressed;
            decrementOptionIndexButton.action.Disable();

            foreach (var button in otherButtons)
            {
                button.action.performed -= OnAnyOtherFaceButtonPressed;
                button.action.Disable();
            }
        }
    }
}
