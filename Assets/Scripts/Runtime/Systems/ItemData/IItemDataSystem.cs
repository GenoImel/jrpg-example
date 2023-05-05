using Jrpg.Core;
using Jrpg.Runtime.DataClasses.ItemData;

namespace Jrpg.Runtime.Systems.ItemData
{
    internal interface IItemDataSystem : ISystem
    {
        /// <summary>
        /// Get an item from the items database using <param name="itemName"></param>.
        /// </summary>
        public Item GetItem(string itemName);
    }
}