using Jrpg.Runtime.DataClasses.Bases;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Jrpg.Runtime.Battle.UI
{
    internal class Option : MonoBehaviour
    {
        [Header("Sprite")] 
        [SerializeField] protected Image sprite;
        
        [Header("AttackText")] 
        [SerializeField] protected TMP_Text nameText;

        [Header("Background Color")] 
        [SerializeField] private Image backgroundImage;

        [Header("Colors")] 
        [SerializeField] private Color normalColor = new Color(43, 43, 43, 134);
        
        [SerializeField] private Color highlightColor = new Color(135, 135, 135, 134);
        
        [Header("Equipment")] 
        [SerializeField] private BaseEquipment assignedEquipment;

        public BaseEquipment AssignedEquipment => assignedEquipment;
        
        protected Image Sprite => sprite;

        protected TMP_Text NameText => nameText;

        private void Awake()
        {
            SetColor(normalColor);
        }
        
        public void SetSelected(bool selected)
        {
            SetColor(selected ? highlightColor : normalColor);
        }
        
        private void SetColor(Color color)
        {
            backgroundImage.color = color;
        }

        public virtual void InitializeOption(string optionName, BaseEquipment equipment)
        {
            NameText.text = optionName;
            assignedEquipment = equipment;
        }
        
        public virtual void InitializeOption(string optionName, BaseEquipment equipment, int cost)
        {
            NameText.text = optionName;
            assignedEquipment = equipment;
        }
        
        public virtual void InitializeOption(string optionName)
        {
            NameText.text = optionName;
            assignedEquipment = null;
        }
    }
}