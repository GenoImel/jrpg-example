using Jrpg.Runtime.DataClasses.PartyData;

namespace Jrpg.Runtime.Battle.UI
{
    internal sealed class ItemPanelController : OptionsPanelController
    {
        private PartyInventory partyInventory;

        protected override void Awake()
        {
            base.Awake();

            partyInventory = saveDataSystem.GetPartyInventory();
        }

        protected override void InitializePanel()
        {
            InitializePanelOptions(partyInventory);
        }
    }
}