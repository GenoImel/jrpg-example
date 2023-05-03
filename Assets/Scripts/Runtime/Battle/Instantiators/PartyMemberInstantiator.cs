using System.Collections.Generic;
using Jrpg.Runtime.DataClasses.SaveData;
using Jrpg.Runtime.Utilities;
using Newtonsoft.Json;
using UnityEngine;

namespace Jrpg.Runtime.Battle.Instantiators
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

        private const int NumRow = 2;

        private const int NumCol = 4;

        private void Start()
        {
            var partyInfo = LoadPartyInfo();
            
            var plane = GridGenerator.DefineXZPlane(gridPlane);
            
            var gridPoints = GridGenerator.Create2DGrid(plane, NumRow, NumCol);
            
            SeparateRows(gridPoints);
            
            PlacePartyMembers(partyInfo);
        }

        private PartyData LoadPartyInfo()
        {
            var currentPartyData = JsonConvert
                .DeserializeObject<PartyData>(partyInfoFile != null ? 
                    partyInfoFile.text : defaultPartyInfoFile.text);

            return currentPartyData;
        }

        private void SeparateRows(List<Vector2> gridPoints)
        {
            for (var i = 0; i < gridPoints.Count; i++)
            {
                if (i < NumCol)
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
