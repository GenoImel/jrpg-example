using Jrpg.Core;
using Jrpg.Runtime.DataClasses.PartyData;
using UnityEngine;

namespace Jrpg.Runtime.Systems.GameData
{
    internal interface IInventorySystem : ISystem
    {
        /// <summary>
        /// Loads the specified inventory <paramref name="data"/> file.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public PartyInventory LoadInventoryData(TextAsset data);

        /// <summary>
        /// Gets an inventory item from the inventory database using <paramref name="itemName"/>.
        /// </summary>
        public InventoryItem GetInventoryItemData(string itemName);
    }
}