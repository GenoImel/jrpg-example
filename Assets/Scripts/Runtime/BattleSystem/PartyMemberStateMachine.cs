using Jrpg.Core;
using Jrpg.Runtime.BattleSystem.UI;
using UnityEngine;

namespace Jrpg.Runtime.BattleSystem
{
    internal sealed class PartyMemberStateMachine : MonoBehaviour
    {
        [SerializeField] 
        private BattleProfileController profileUI;

        [SerializeField] 
        private BattlePartyMember battlePartyMember;

        private enum Status
        {
            Resting,
            ReadyForInput,
            Inqueue,
            Action,
            Dead
        }

        [Header("Party Member State")]
        [SerializeField] private Status status = Status.Resting;

        public BattleProfileController ProfileUI => profileUI;

        private void Update()
        {
            switch (status)
            {
                case Status.Resting:
                    break;
                
                case Status.ReadyForInput:
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
            status = Status.ReadyForInput;
            GameManager.Publish(new PartyMemberReadyForInputMessage(battlePartyMember));
        }
    }
}
