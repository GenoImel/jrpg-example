using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.PartyData
{
    /// <summary>
    /// The inventory for the party.
    /// </summary>
    internal sealed class PartyInventory
    {
        [JsonProperty("inventoryItems")]
        public IEnumerable<InventoryItem> InventoryItemsList { get; }

        [JsonConstructor]
        public PartyInventory([JsonProperty("inventoryItems")] IEnumerable<InventoryItem> inventoryItems)
        {
            InventoryItemsList = inventoryItems;
        }

        public InventoryItem GetInventoryItem(string itemName)
        {
            foreach (var t in InventoryItemsList.Where(t => t.ItemName == itemName))
            {
                return t;
            }

            throw new Exception($"Inventory item {itemName} not found.");
        }
    }

    /// <summary>
    /// An individual item in the party inventory.
    /// </summary>
    internal sealed class InventoryItem
    {
        [JsonProperty("itemName")]
        public string ItemName { get; }
        
        [JsonProperty("itemCount")]
        public int ItemCount { get; }

        public InventoryItem(
            [JsonProperty("itemName")] string itemName,
            [JsonProperty("itemCount")] int itemCount
            )
        {
            ItemName = itemName;
            ItemCount = itemCount;
        }
    }
}