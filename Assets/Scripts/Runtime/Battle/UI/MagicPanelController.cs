using Jrpg.Core;
using Jrpg.Runtime.DataClasses.EquipmentData;
using Jrpg.Runtime.Systems.EquipmentData;

namespace Jrpg.Runtime.Battle.UI
{
    internal sealed class MagicPanelController : OptionsPanelController
    {
        protected override void InitializePanel()
        {
            var listMagic = partyMember.ActiveNecklace.Charms;

            InitializePanelOptions<Charm>(listMagic);
        }
    }
}