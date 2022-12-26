using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JRPG.DataClasses
{
    [System.Serializable]
    internal sealed class PartyInfo
    {
        [Header("Party Members")]
        [SerializeField]
        public List<string> partyMembers = new List<string>();
    }
}
