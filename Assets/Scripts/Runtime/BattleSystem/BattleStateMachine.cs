using System.Collections.Generic;
using Jrpg.Runtime.BattleSystem;
using UnityEngine;

namespace Jrpg.Runtime.BattleSystem
{
    public class BattleStateMachine : MonoBehaviour
    {
        //[SerializeField] private IEnumerable<Turn> turnQueue;
        
        private enum BattleState
        {
            Waiting,
            PlayerTurn,
            EnemyTurn,
            Paused,
            Win,
            Lose
        }

        [SerializeField] private BattleState battleState = BattleState.Waiting;
        
        
    }
}
