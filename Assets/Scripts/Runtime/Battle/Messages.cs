using Jrpg.Core;
using Jrpg.Runtime.Battle.UI;
using Jrpg.Runtime.DataClasses.Bases;
using Jrpg.Runtime.DataClasses.Enemy;

namespace Jrpg.Runtime.Battle
{
    internal sealed class PartyMemberAddedMessage : IMessage
    {
        public BattlePartyMember PartyMember { get; }

        public PartyMemberAddedMessage(BattlePartyMember partyMember)
        {
            PartyMember = partyMember;
        }
    }
    
    internal sealed class PartyMemberAddedToFieldMessage : IMessage
    {
        public BattlePartyMember PartyMember { get; }

        public PartyMemberAddedToFieldMessage(BattlePartyMember partyMember)
        {
            PartyMember = partyMember;
        }
    }
    
    internal sealed class EnemyAddedToFieldMessage : IMessage
    {
        public BattleEnemy Enemy { get; }

        public EnemyAddedToFieldMessage(BattleEnemy enemy)
        {
            Enemy = enemy;
        }
    }

    internal sealed class BattleCommandsEnabledMessage : IMessage
    {
        public bool Enabled { get; }

        public BattleCommandsEnabledMessage(bool enabled)
        {
            Enabled = enabled;
        }
    }

    internal sealed class PartyMemberSelectedMessage : IMessage
    {
        public BattlePartyMember PartyMember { get; }
        
        public PartyMemberSelectedMessage(BattlePartyMember partyMember)
        {
            PartyMember = partyMember;
        }
    }

    internal sealed class UpdateOverdriveAchievedMessage : IMessage
    {
        public BattlePartyMember PartyMember { get; }
        
        public UpdateOverdriveAchievedMessage(BattlePartyMember partyMember)
        {
            PartyMember = partyMember;
        }
    }

    internal sealed class BattleEntitySelectedMessage : IMessage
    {
        public BaseBattleEntity Entity { get; }
        
        public BattleEntitySelectedMessage(BaseBattleEntity entity)
        {
            Entity = entity;
        }
    }

    internal sealed class PartyMemberReadyForInputMessage : IMessage
    {
        public BattlePartyMember PartyMember { get; }

        public PartyMemberReadyForInputMessage(BattlePartyMember partyMember)
        {
            PartyMember = partyMember;
        }
    }

    internal sealed class BattleCommandIssuedMessage : IMessage
    {
        public BattlePartyMember PartyMember { get; }
        public BaseEntity Target { get; }
        public Option BattleOption{ get; }

        public BattleCommandIssuedMessage(BattlePartyMember partyMember, BaseEntity target, Option battleOption)
        {
            PartyMember = partyMember;
            Target = target;
            BattleOption = battleOption;
        }
    }

    internal sealed class PartyMemberSelectionModeEnabledMessage : IMessage
    {
    }
    
    internal sealed class TargetSelectionModeEnabledMessage : IMessage
    {
    }
}