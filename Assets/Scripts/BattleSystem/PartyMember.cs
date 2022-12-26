using UnityEngine;
using UnityEngine.Events;

namespace JRPG.BattleSystem
{
    internal sealed class PartyMember : MonoBehaviour
    {
        [Header("Party Member Info")] 
        [SerializeField] public GameObject partyMemberUIPrefab;
        
        public delegate void PartyMemberAdded(PartyMember partyMember);

        public static event PartyMemberAdded OnPartyMemberAdded;

        void Start()
        {
            OnPartyMemberAdded?.Invoke(this);
        }
        
    }
}
