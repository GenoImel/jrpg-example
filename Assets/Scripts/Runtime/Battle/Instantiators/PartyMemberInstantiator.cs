using Jrpg.Core;
using System.Collections.Generic;
using Jrpg.Runtime.Systems.GameData;
using Jrpg.Runtime.Utilities;
using Unity.VisualScripting;
using UnityEngine;

namespace Jrpg.Runtime.Battle.Instantiators
{
    internal sealed class PartyMemberInstantiator : MonoBehaviour
    {
        [SerializeField] 
        private float popInHeight = 2f;
        
        [Header("Party Members")]
        [SerializeField] 
        private List<BattlePartyMember> partyMembers;

        [Header("Grid")] 
        [SerializeField] 
        private MeshFilter gridPlane;
        
        [SerializeField] 
        private List<Vector2> frontRow;

        [SerializeField] 
        private List<Vector2> backRow;

        private const int NumRow = 2;

        private const int NumCol = 4;

        private ISaveDataSystem saveDataSystem;

        private void Awake()
        {
            saveDataSystem = GameManager.GetSystem<ISaveDataSystem>();
        }
        
        private void Start()
        {
            var plane = GridGenerator.DefineXZPlane(gridPlane);
            
            var gridPoints = GridGenerator.Create2DGrid(plane, NumRow, NumCol);
            
            SeparateRows(gridPoints);
            
            PlacePartyMembers();
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

        private void PlacePartyMembers()
        {
            var partyData = saveDataSystem.GetPartyData();
            
            for (var i = 0; i < partyData.PartyMembers.Count; i++)
            {
                var partyMember = GetPartyMemberByName(partyData.PartyMembers[i].Name);

                if (partyMember == null)
                {
                    return;
                }

                var partyMemberGameObject = Instantiate(
                    partyMember,
                    new Vector3(frontRow[i].x, popInHeight, frontRow[i].y),
                    Quaternion.identity,
                    transform
                );
                
                partyMemberGameObject.SetData(partyData.PartyMembers[i]);
            }
        }

        private BattlePartyMember GetPartyMemberByName(string charName)
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
