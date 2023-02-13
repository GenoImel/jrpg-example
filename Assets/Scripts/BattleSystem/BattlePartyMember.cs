using JRPG.BattleSystem.UI;
using UnityEngine;

namespace JRPG.BattleSystem
{
    internal sealed class BattlePartyMember : MonoBehaviour
    {
        [Header("General Info")] 
        [SerializeField] private string characterName;

        [Header("UI")]
        [SerializeField] private Sprite profilePicture;
        
        [SerializeField] private BattleProfileController profileUI;
        
        public string CharacterName
        {
            get => characterName;
        }

        public Sprite ProfilePicture
        {
            get => profilePicture;
        }

        public BattleProfileController ProfileUI
        {
            get => profileUI;
        }
        
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
        
        public delegate void PartyMemberAdded(BattlePartyMember battlePartyMember);

        public static event PartyMemberAdded OnPartyMemberAdded;
        

        void Start()
        {
            OnPartyMemberAdded?.Invoke(this);
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

        public void RestingComplete()
        {
            status = Status.Readyforinput;
        }
        
    }
}
