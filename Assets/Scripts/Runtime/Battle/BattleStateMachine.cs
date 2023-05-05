using UnityEngine;

namespace Jrpg.Runtime.Battle
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
