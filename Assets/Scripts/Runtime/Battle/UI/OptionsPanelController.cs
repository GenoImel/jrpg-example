using System.Collections.Generic;
using System.Linq;
using Jrpg.Core;
using Jrpg.Runtime.DataClasses.PartyData;
using Jrpg.Runtime.Systems.EquipmentData;
using Jrpg.Runtime.Systems.GameData;
using Jrpg.Runtime.Systems.ItemData;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Jrpg.Runtime.Battle.UI
{
    internal class OptionsPanelController : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] 
        protected TextMeshProUGUI pageNumberText;

        [SerializeField] 
        protected GameObject optionsContainer;

        [SerializeField] 
        protected CanvasGroup canvasGroup;

        [SerializeField] 
        protected Option optionPrefab;
        
        [Header("Buttons")] 
        [SerializeField] 
        protected InputActionReference optionFaceButton;

        [SerializeField] 
        protected InputActionReference incrementOptionIndexButton;
        
        [SerializeField]
        protected InputActionReference decrementOptionIndexButton;

        [SerializeField] 
        protected List<InputActionReference> otherFaceButtons;
        
        [Header("Options")] 
        [SerializeField] 
        protected List<Option> listOptions;

        protected List<GameObject> totalOptions;
        
        protected PartyMember partyMember;

        
        private IEquipmentDataSystem equipmentDataSystem;
        protected ISaveDataSystem saveDataSystem;
        private IItemDataSystem itemDataSystem;

        protected int pageIndex = 0;
        protected int optionIndex = 0;
        protected bool commandsEnabled;

        protected virtual void Awake()
        {
            SetPanelActive(false);
            
            equipmentDataSystem = GameManager.GetSystem<IEquipmentDataSystem>();
            saveDataSystem = GameManager.GetSystem<ISaveDataSystem>();
            itemDataSystem = GameManager.GetSystem<IItemDataSystem>();
        }

        protected virtual void OnEnable()
        {
            AddListeners();
        }

        protected virtual void OnDisable()
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
            if (optionIndex > listOptions.Count - 1)
            {
                optionIndex = 0;
            }

            if (optionIndex < 0)
            {
                optionIndex = listOptions.Count - 1;
            }
        }

        private void OnOptionFaceButtonPressed(InputAction.CallbackContext context)
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
            ResetIndices();
            ResetPageNumber();
            HighlightCurrentOption();
            
            canvasGroup.alpha = isActive ? 1f : 0f;
            canvasGroup.interactable = isActive;
            canvasGroup.blocksRaycasts = isActive;
        }

        protected virtual void ResetPanel()
        {
            ResetIndices();
            ResetPageNumber();

            if (listOptions == null)
            {
                return;
            }

            foreach (var attack in listOptions)
            {
                var attackObject = attack.gameObject;
                Destroy(attackObject);
            }
            
            listOptions.Clear();
        }

        private void ResetIndices()
        {
            optionIndex = 0;
            pageIndex = 0;
        }

        protected virtual void ResetPageNumber()
        {
            pageNumberText.text = (pageIndex + 1).ToString();
        }

        protected void HighlightCurrentOption()
        {
            if (!listOptions.Any())
            {
                return;
            }
            
            foreach (var option in listOptions)
            {
                option.SetSelected(false);
            }
            
            listOptions[optionIndex].SetSelected(true);
        }

        protected virtual void OnPartyMemberSelected(PartyMemberSelectedMessage message)
        {
            partyMember = message.PartyMember.GetEntityData();
            commandsEnabled = true;
            ResetPanel();
            InitializePanel();
            HighlightCurrentOption();
        }

        protected virtual void InitializePanel()
        {
        }

        protected virtual void InitializePanelOptions(PartyInventory partyInventory)
        {
            foreach(var inventoryItem in partyInventory.InventoryItemsList)
            {
                if(string.IsNullOrWhiteSpace(inventoryItem.Name) || string.IsNullOrEmpty(inventoryItem.Name))
                {
                    continue;
                }

                var itemData = itemDataSystem.GetItemByName(inventoryItem.Name);
                var option = Instantiate(optionPrefab, optionsContainer.transform);
                option.InitializeOption(itemData.Name, inventoryItem, itemData);
                listOptions.Add(option);
            }
        }

        protected void InitializePanelOptions<T>(IEnumerable<string> tempListOptions)
        {
            foreach (var tempOption in tempListOptions)
            {
                if(string.IsNullOrWhiteSpace(tempOption) || string.IsNullOrEmpty(tempOption))
                {
                    continue;
                }

                var optionData = equipmentDataSystem.GetEquipmentDataByName<T>(tempOption);
                var option = Instantiate(optionPrefab, optionsContainer.transform);
                    option.InitializeOption(optionData.Name, optionData);
                    listOptions.Add(option);
            }
        }

        protected virtual void AddListeners()
        {
            GameManager.AddListener<PartyMemberSelectedMessage>(OnPartyMemberSelected);
            
            optionFaceButton.action.performed += OnOptionFaceButtonPressed;
            optionFaceButton.action.Enable();
            
            incrementOptionIndexButton.action.performed += OnIncrementOptionIndexButtonPressed;
            incrementOptionIndexButton.action.Enable();
            
            decrementOptionIndexButton.action.performed += OnDecrementOptionIndexButtonPressed;
            decrementOptionIndexButton.action.Enable();

            foreach (var button in otherFaceButtons)
            {
                button.action.performed += OnAnyOtherFaceButtonPressed;
                button.action.Enable();
            }
        }

        protected virtual void RemoveListeners()
        {
            GameManager.RemoveListener<PartyMemberSelectedMessage>(OnPartyMemberSelected);
            
            optionFaceButton.action.performed -= OnOptionFaceButtonPressed;
            optionFaceButton.action.Disable();
            
            incrementOptionIndexButton.action.performed -= OnIncrementOptionIndexButtonPressed;
            incrementOptionIndexButton.action.Disable();
            
            decrementOptionIndexButton.action.performed -= OnDecrementOptionIndexButtonPressed;
            decrementOptionIndexButton.action.Disable();

            foreach (var button in otherFaceButtons)
            {
                button.action.performed -= OnAnyOtherFaceButtonPressed;
                button.action.Disable();
            }
        }
    }
}