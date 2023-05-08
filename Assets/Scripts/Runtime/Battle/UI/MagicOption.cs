using Jrpg.Runtime.DataClasses.Bases;
using Jrpg.Runtime.DataClasses.EquipmentData;
using TMPro;
using UnityEngine;

namespace Jrpg.Runtime.Battle.UI
{
    internal sealed class MagicOption : Option
    {
        [Header("Option Cost")] 
        [SerializeField] private TMP_Text optionCostText;

        protected override void InitializeOption(string optionName, Charm charmData)
        {
            base.InitializeOption(optionName, charmData);
            optionCostText.text = charmData.CharmCost.ToString();
        }
    }
}