using Jrpg.Core;
using Jrpg.Runtime.DataClasses.PartyData;
using UnityEngine;

namespace Jrpg.Runtime.Systems.GameData
{
    internal interface ISaveDataSystem : ISystem
    {
        /// <summary>
        /// Load the specified save <paramref name="data"/> file.
        /// </summary>
        public PartyData LoadPartyData(TextAsset data);

        /// <summary>
        /// Save the current data.
        /// </summary>
        public void SaveData();

        /// <summary>
        /// Overwrite data for a particular <paramref name="partyMember"/>;
        /// </summary>
        public void WritePartyMemberData(PartyMember partyMember);

        /// <summary>
        /// Returns the data for the entire party.
        /// </summary>
        public PartyData GetPartyData();
        
        /// <summary>
        /// Returns the data for the party inventory.
        /// </summary>
        public PartyInventory GetPartyInventory();
        
        /// <summary>
        /// Gets an inventory item from the inventory database using <paramref name="itemName"/>.
        /// </summary>
        public InventoryItem GetInventoryItemData(string itemName);

        /// <summary>
        /// Retrieve a party member, their stats, and equipment
        /// from the current save data.
        /// </summary>
        public PartyMember GetPartyMemberData(string charName);
    }
}