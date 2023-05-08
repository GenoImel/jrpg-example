using Jrpg.Runtime.DataClasses.Bases;
using Jrpg.Runtime.DataClasses.EquipmentData;
using Jrpg.Runtime.DataClasses.ItemData;
using Jrpg.Runtime.DataClasses.PartyData;
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
        [SerializeField] private BaseData assignedData;

        public BaseData AssignedData => assignedData;
        
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

        public virtual void InitializeOption(string optionName, BaseData data)
        {
            NameText.text = optionName;
            assignedData = data;
        }

        protected virtual void InitializeOption(string optionName, Charm charmData)
        {
            NameText.text = optionName;
            assignedData = charmData;
        }

        public virtual void InitializeOption(string optionName, InventoryItem inventoryItem, Item itemData)
        {
            NameText.text = optionName;
            assignedData = itemData;
        }

        public virtual void InitializeOption(string optionName)
        {
            NameText.text = optionName;
            assignedData = null;
        }
    }
}