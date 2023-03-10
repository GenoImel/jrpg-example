using System.Collections.Generic;
using Jrpg.Runtime.DataClasses.SaveData;
using Jrpg.Runtime.Utilities;
using Newtonsoft.Json;
using UnityEngine;

namespace Jrpg.Runtime.BattleSystem.Instantiators
{
    internal sealed class PartyMemberInstantiator : MonoBehaviour
    {

        [Header("Party Information")]
        [SerializeField] 
        private TextAsset defaultPartyInfoFile;

        [SerializeField] 
        private TextAsset partyInfoFile;

        [SerializeField] 
        private float popInHeight = 2f;
        
        [Header("Party Member ScriptableObjects")]
        [SerializeField] 
        private List<GameObject> partyMembers;

        [Header("Grid")] 
        [SerializeField] 
        private MeshFilter gridPlane;
        
        [SerializeField] 
        private List<Vector2> frontRow;

        [SerializeField] 
        private List<Vector2> backRow;
        
        private readonly int numRow = 2;

        private readonly int numCol = 4;
        
        void Start()
        {
            var partyInfo = LoadPartyInfo();
            
            var plane = GridGenerator.DefineXZPlane(gridPlane);
            
            var gridPoints = GridGenerator.Create2DGrid(plane, numRow, numCol);
            
            SeparateRows(gridPoints);
            
            PlacePartyMembers(partyInfo);
        }

        private PartyData LoadPartyInfo()
        {
            PartyData currentPartyData = null;

            if (partyInfoFile != null)
            {
                currentPartyData = JsonConvert.DeserializeObject<PartyData>(partyInfoFile.text);
            }
            else
            {
                currentPartyData = JsonConvert.DeserializeObject<PartyData>(defaultPartyInfoFile.text); 
            }

            return currentPartyData;
        }

        private void SeparateRows(List<Vector2> gridPoints)
        {
            for (int i = 0; i < gridPoints.Count; i++)
            {
                if (i < numCol)
                {
                    frontRow.Add(gridPoints[i]);
                }
                else
                {
                    backRow.Add(gridPoints[i]);
                }
            }
        }

        private void PlacePartyMembers(PartyData partyData)
        {
            if (partyData == null)
            {
                Debug.Log("Could not load party members.");
                return;
            }
            
            for( int i = 0; i < partyData.PartyMembers.Count; i++)
            {
                var partyMember = GetPartyMemberByName(partyData.PartyMembers[i].Name);

                Instantiate(
                    partyMember,
                    new Vector3(frontRow[i].x, popInHeight, frontRow[i].y),
                    Quaternion.identity,
                    this.transform
                );
            }
        }

        private GameObject GetPartyMemberByName(string charName)
        {
            foreach(var member in partyMembers)
            {
                if (member.name == charName)
                {
                    return member;
                }
            }

            return null;
        }

    }
}
