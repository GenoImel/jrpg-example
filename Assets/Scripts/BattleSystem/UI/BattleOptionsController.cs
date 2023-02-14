using System;
using JRPG.Input;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace JRPG.BattleSystem.UI
{
    internal sealed class BattleOptionsController : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Image panelBackground;
        
        private  BattleScreenInput battleScreenInput;
        private InputAction inputAction;

        private void Awake()
        {
            battleScreenInput = new BattleScreenInput();
            
            SetCommandPanelVisibility(false);
        }

        private void OnEnable()
        {
            battleScreenInput.Battlescreen.AnyFaceButton.performed += OnFaceButtonPressed;
            battleScreenInput.Battlescreen.AnyFaceButton.Enable();
        }


        private void OnFaceButtonPressed(InputAction.CallbackContext obj)
        {
            SetCommandPanelVisibility(true);
        }

        private void SetCommandPanelVisibility(bool isVisible)
        {
            panelBackground.enabled = isVisible;
        }

    }
}
