using System.Collections.Generic;
using JRPG.DataClasses.SaveData;
using Newtonsoft.Json;
using JRPG.Utilities;
using UnityEditor;
using UnityEngine;

namespace JRPG.BattleSystem
{
    internal sealed class PartyMemberBattleScreenSpawner : MonoBehaviour
    {

        [Header("Party Information")] 
        [SerializeField] private bool useDefaultInfo = true;

        [SerializeField] private string pathToPartyInfo = "SaveData/";

        [SerializeField] private string pathToPartyMembers = "Assets/Art/PartyMembers/";

        [SerializeField] private float popInHeight = 2f;

        [Header("Grid")] 
        [SerializeField] private MeshFilter gridPlane;
        
        [SerializeField] private List<Vector2> frontRow;

        [SerializeField] private List<Vector2> backRow;
        
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

        private PartyInfo LoadPartyInfo()
        {
            TextAsset partyInfoFile;
            PartyInfo partyInfo = null;
            
            if (useDefaultInfo)
            {
                partyInfoFile = 
                    Resources.Load(pathToPartyInfo + "Default/DefaultPartyInfo") as TextAsset;
            }
            else
            {
                partyInfoFile = 
                    Resources.Load(pathToPartyInfo + "PartyInfo") as TextAsset;
            }

            if (partyInfoFile != null)
                partyInfo = JsonConvert.DeserializeObject<PartyInfo>(partyInfoFile.text);

            return partyInfo;
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

        private void PlacePartyMembers(PartyInfo partyInfo)
        {
            if (partyInfo == null)
            {
                Debug.Log("Could not load party members.");
                return;
            }
            
            for( int i = 0; i < partyInfo.partyMembers.Count; i++)
            {
                var partyMemberPrefab = AssetDatabase.LoadAssetAtPath(
                    pathToPartyMembers + partyInfo.partyMembers[i] + "_BattleScreen.prefab",
                    typeof(GameObject));

                Instantiate(
                    partyMemberPrefab,
                    new Vector3(frontRow[i].x, popInHeight, frontRow[i].y),
                    Quaternion.identity,
                    this.transform
                );
            }
        }

    }
}
