using System;
using System.Collections.Generic;
using Jrpg.Core;
using Jrpg.Runtime.DataClasses.PartyData;
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
        protected AttackOption optionPrefab;
        
        [Header("Buttons")] 
        [SerializeField] 
        protected InputActionReference optionFaceButton;

        [SerializeField] 
        protected InputActionReference incrementOptionIndexButton;
        
        [SerializeField]
        protected InputActionReference decrementOptionIndexButton;

        [SerializeField] 
        protected List<InputActionReference> otherFaceButtons;
        
        [Header("Attacks")] 
        [SerializeField] 
        protected List<Option> listOptions;

        protected List<GameObject> totalOptions;
        
        protected PartyMember partyMember;

        private int pageIndex = 0;
        private int optionIndex = 0;
        private bool commandsEnabled;

        protected virtual void Awake()
        {
            SetPanelActive(false);
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
            canvasGroup.alpha = isActive ? 1f : 0f;
            canvasGroup.interactable = isActive;
            canvasGroup.blocksRaycasts = isActive;
        }

        private void ResetPanel()
        {
            optionIndex = 0;
            pageIndex = 0;
            pageNumberText.text = (pageIndex + 1).ToString();

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

        private void HighlightCurrentOption()
        {
            foreach (var attack in listOptions)
            {
                attack.SetSelected(false);
            }
            
            listOptions[optionIndex].SetSelected(true);
        }

        protected void OnPartyMemberSelected(PartyMemberSelectedMessage message)
        {
            partyMember = message.PartyMember.GetEntityData();
            commandsEnabled = true;
            ResetPanel();
            InitializePanelOptions();
            HighlightCurrentOption();
        }

        protected virtual void InitializePanelOptions()
        {
        }

        protected virtual void AddListeners()
        {
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