using System;
using Jrpg.Core;

namespace Jrpg.Runtime.Battle
{
    internal sealed class BattleEnemy : BaseBattleEntity
    {
        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void Start()
        {
            GameManager.Publish(new EnemyAddedToFieldMessage(this));
        }
        
        private void OnBattleEntitySelected(BattleEntitySelectedMessage message)
        {
            SetSelected(message.Entity == this);
        }
        
        private void AddListeners()
        {
            GameManager.AddListener<BattleEntitySelectedMessage>(OnBattleEntitySelected);
        }
        
        private void RemoveListeners()
        {
            GameManager.AddListener<BattleEntitySelectedMessage>(OnBattleEntitySelected);
        }
    }
}