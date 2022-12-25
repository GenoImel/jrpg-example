using System.Collections.Generic;
using JRPG.Utilities;
using UnityEngine;

namespace JRPG.BattleSystem
{
    internal sealed class PartyMemberBattleScreenSpawner : MonoBehaviour
    {
        
        //[Header("Pary Members")]
        //[SerializeField]
        //Need a JSON serialized object to go here to determine default party members

        [Header("Grid")] 
        [SerializeField] private MeshFilter gridPlane;
        
        [SerializeField] private List<Vector2> frontRow;

        [SerializeField] private List<Vector2> backRow;

        //These shouldn't be changed for the party members
        private readonly int numRow = 2;

        private readonly int numCol = 4;
        
        void Start()
        {
            var plane = GridGenerator.DefineXZPlane(gridPlane);
            
            var gridPoints = GridGenerator.Create2DGrid(plane, numRow, numCol);
            
            SeparateRows(gridPoints);
            
            PlacePartyMembers();
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

        private void PlacePartyMembers()
        {
            
        }

    }
}
