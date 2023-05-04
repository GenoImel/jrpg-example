using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.ItemData
{
    /// <summary>
    /// Database of all items in game.
    /// </summary>
    internal sealed class Items
    {
        [JsonProperty("items")]
        public IEnumerable<Item> ItemsDatabase { get; }
        
        [JsonConstructor]
        public Items([JsonProperty("items")] IEnumerable<Item> items)
        {
            ItemsDatabase = items;
        }

        public Item GetItem(string itemName)
        {
            foreach (var t in ItemsDatabase.Where(t => t.ItemName == itemName))
            {
                return t;
            }

            throw new Exception($"The Item {itemName} was not found.");
        }
    }

    /// <summary>
    /// An individual item in the items database.
    /// </summary>
    internal sealed class Item
    {
        [JsonProperty("itemName")]
        public string ItemName { get; }
        
        [JsonProperty("itemType")]
        public string Description { get; }
        
        [JsonProperty("itemStance")]
        public string ItemMode { get; }

        [JsonProperty("itemAttack")]
        public int ItemAmount { get; }
        
        [JsonProperty("itemDefense")]
        public int ItemStatusEffect { get; }
        
        [JsonProperty("itemSpeed")]
        public int ItemStatusEffectChance { get; }

        public Item(
            [JsonProperty("itemName")] string itemName,
            [JsonProperty("itemType")] string itemType,
            [JsonProperty("itemStance")] string itemMode,
            [JsonProperty("itemAttack")] int itemAmount,
            [JsonProperty("itemDefense")] int itemStatusEffect,
            [JsonProperty("itemSpeed")] int itemStatusEffectChance
            
        )
        {
            ItemName = itemName;
            Description = itemType;
            ItemMode = itemMode;
            ItemAmount = itemAmount;
            ItemStatusEffect = itemStatusEffect;
            ItemStatusEffectChance = itemStatusEffectChance;
        }
    }
}