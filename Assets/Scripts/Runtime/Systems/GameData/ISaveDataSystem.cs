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
        /// Loads the specified inventory <paramref name="data"/> file.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public PartyInventory LoadInventoryData(TextAsset data);
        
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
        /// Retrieve a party member, their stats, and equipment
        /// from the current save data.
        /// </summary>
        public PartyMember GetPartyMemberData(string charName);
    }
}