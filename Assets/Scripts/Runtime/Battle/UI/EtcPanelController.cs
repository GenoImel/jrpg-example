using System.Collections.Generic;
using UnityEngine;

namespace Jrpg.Runtime.Battle.UI
{
    internal sealed class EtcPanelController : OptionsPanelController
    {
        [Header("Etc Options Prefabs")]
        [SerializeField]
        private List<Option> etcOptionsPrefabs;
        
        protected override void InitializePanel()
        {
            foreach(var etcOption in etcOptionsPrefabs)
            {
                var option = Instantiate(etcOption, optionsContainer.transform);
                option.InitializeOption(etcOption.name, null);
                listOptions.Add(option);
            }
        }

        protected override void ResetPageNumber()
        {
        }
    }
}