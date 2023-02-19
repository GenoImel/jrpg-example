using System.Collections.Generic;
using Jrpg.Core;
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

        private void OnEnable()
        {
            AddListeners();
            
            SetCommandPanelVisibility(false);
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void OnFaceButtonPressed(InputAction.CallbackContext context)
        {
            if (commandsEnabled && !canvasGroup.interactable)
            {
                SetCommandPanelVisibility(true);
            }
        }

        private void SetCommandPanelVisibility(bool isVisible)
        {
            canvasGroup.alpha = isVisible ? 1f : 0f;
            canvasGroup.interactable = isVisible;
            canvasGroup.blocksRaycasts = isVisible;
        }

        private void OnCommandsEnabled(BattleCommandsEnabledMessage message)
        {
            commandsEnabled = message.Enabled;
        }

        private void AddListeners()
        {
            GameManager.AddListener<BattleCommandsEnabledMessage>(OnCommandsEnabled);

            foreach (var button in faceButtons)
            {
                button.action.performed += OnFaceButtonPressed;
                button.action.Enable();
            }
        }

        private void RemoveListeners()
        {
            GameManager.RemoveListener<BattleCommandsEnabledMessage>(OnCommandsEnabled);
            
            foreach (var button in faceButtons)
            {
                button.action.performed -= OnFaceButtonPressed;
                button.action.Disable();
            }
        }

    }
}
