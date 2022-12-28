using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

namespace JRPG.BattleSystem
{
    internal sealed class BattleScreenPartyMember : MonoBehaviour
    {
        [Header("Party Member Info")] 
        [SerializeField] public GameObject partyMemberUIPrefab;

        private BattleScreenProfileController partyMemberUI;
        
        private enum Status
        {
            Resting,
            Readyforinput,
            Inqueue,
            Action,
            Dead
        }

        [Header("Party Member State")]
        [SerializeField] private Status status = Status.Resting;
        
        public delegate void PartyMemberAdded(BattleScreenPartyMember battleScreenPartyMember);

        public static event PartyMemberAdded OnPartyMemberAdded;

        void Awake()
        {
            PartyMemberUICreator.OnPartyMemberUICreated += OnUIAdded;
        }

        void Start()
        {
            OnPartyMemberAdded?.Invoke(this);
            partyMemberUI.StartUpdateRestBar();
        }

        void Update()
        {
            switch (status)
            {
                case Status.Resting:
                    break;
                
                case Status.Readyforinput:
                    //put in line for a command
                    break;
                    
                case Status.Inqueue:
                    //put in queue for action
                    break;
                
                case Status.Action:
                    //perform action
                   break;
                
                case Status.Dead:
                    break;
            }
        }

        public void OnUIAdded(BattleScreenProfileController ui)
        {
            partyMemberUI = ui;
        }
        
        public void RestingComplete()
        {
            status = Status.Readyforinput;
        }
        
    }
}
