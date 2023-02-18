using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Jrpg.Runtime.BattleSystem.UI
{
    internal sealed class BattleOptionsController : MonoBehaviour
    {
        [Header("UI Elements")] [SerializeField]
        private CanvasGroup canvasGroup;

        
        [Header("Buttons")]
        [SerializeField] private List<InputActionReference> faceButtons = new List<InputActionReference>();
        
        private bool commandsEnabled = false;

        private void Awake()
        {
            SetCommandPanelVisibility(false);
        }

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void OnFaceButtonPressed(InputAction.CallbackContext context)
        {
            SetCommandPanelVisibility(true);
        }

        private void SetCommandPanelVisibility(bool isVisible)
        {
            canvasGroup.alpha = isVisible ? 1f : 0f;
            canvasGroup.interactable = isVisible;
            canvasGroup.blocksRaycasts = isVisible;
        }

        private void OnCommandsEnabled(bool isEnabled)
        {
            commandsEnabled = isEnabled;
        }

        private void AddListeners()
        {
            PartyCommandController.OnBattleCommandsEnabled += OnCommandsEnabled;

            foreach (var button in faceButtons)
            {
                button.action.performed += OnFaceButtonPressed;
                button.action.Enable();
            }
        }

        private void RemoveListeners()
        {
            PartyCommandController.OnBattleCommandsEnabled -= OnCommandsEnabled;
            
            foreach (var button in faceButtons)
            {
                button.action.performed -= OnFaceButtonPressed;
                button.action.Disable();
            }
        }

    }
}
