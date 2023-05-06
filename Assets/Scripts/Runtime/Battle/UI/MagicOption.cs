using Jrpg.Runtime.DataClasses.Bases;
using TMPro;
using UnityEngine;

namespace Jrpg.Runtime.Battle.UI
{
    internal sealed class MagicOption : Option
    {
        [Header("Option Cost")] 
        [SerializeField] private TMP_Text optionCostText;

        public override void InitializeOption(string optionName, BaseEquipment equipment, int cost)
        {
            base.InitializeOption(optionName, equipment, cost);
            optionCostText.text = cost.ToString();
        }
    }
}