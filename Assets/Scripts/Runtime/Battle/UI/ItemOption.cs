using Jrpg.Runtime.DataClasses.ItemData;
using Jrpg.Runtime.DataClasses.PartyData;
using TMPro;
using UnityEngine;

namespace Jrpg.Runtime.Battle.UI
{
    internal sealed class ItemOption : Option
    {
        [Header("Option Count")] 
        [SerializeField] private TMP_Text optionCountText;
        
        public override void InitializeOption(string optionName, InventoryItem inventoryItem, Item itemData)
        {
            base.InitializeOption(optionName, inventoryItem, itemData);
            optionCountText.text = inventoryItem.ItemCount.ToString();
        }
    }
}
