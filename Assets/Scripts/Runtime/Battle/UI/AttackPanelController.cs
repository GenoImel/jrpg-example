using System.Collections.Generic;
using Jrpg.Core;
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

        [Header("Buttons")] 
        [SerializeField] 
        private InputActionReference attackButton;

        [SerializeField] 
        private List<InputActionReference> otherButtons;

        [Header("Attacks")] 
        [SerializeField] 
        private List<GameObject> attackOptions;

        [SerializeField] 
        private GameObject limitOption;

        private List<GameObject> totalOptions;
        
        
        private int pageIndex = 0;
        private int optionIndex = 0;

        private bool commandsEnabled;

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void OnAttackButtonPressed(InputAction.CallbackContext context)
        {
            if (!canvasGroup.interactable && commandsEnabled)
            {
                SetPanelActive(true);
            }
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
            
            //enable individual options in the pool

            ResetPanel();
        }

        private void ResetPanel()
        {
            pageIndex = 0;
            pageNumberText.text = (pageIndex + 1).ToString();
        }

        private void InitializePanel()
        {
            
        }

        private void OnPartyMemberSelected(PartyMemberSelectedMessage message)
        {
            commandsEnabled = true;
        }

        private void AddListeners()
        {
            GameManager.AddListener<PartyMemberSelectedMessage>(OnPartyMemberSelected);
            
            attackButton.action.performed += OnAttackButtonPressed;
            attackButton.action.Enable();

            foreach (var button in otherButtons)
            {
                button.action.performed += OnAnyOtherFaceButtonPressed;
                button.action.Enable();
            }
        }

        private void RemoveListeners()
        {
            GameManager.RemoveListener<PartyMemberSelectedMessage>(OnPartyMemberSelected);
            
            attackButton.action.performed -= OnAttackButtonPressed;
            attackButton.action.Disable();

            foreach (var button in otherButtons)
            {
                button.action.performed -= OnAnyOtherFaceButtonPressed;
                button.action.Disable();
            }
        }
    }
}
