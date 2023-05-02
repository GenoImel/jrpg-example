using Jrpg.Core;

namespace Jrpg.Runtime.BattleSystem
{
    internal sealed class PartyMemberAddedMessage : IMessage
    {
        public BattlePartyMember PartyMember { get; }

        public PartyMemberAddedMessage(BattlePartyMember partyMember)
        {
            PartyMember = partyMember;
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

    internal sealed class PartyMemberReadyForInputMessage : IMessage
    {
        public BattlePartyMember PartyMember { get; }

        public PartyMemberReadyForInputMessage(BattlePartyMember partyMember)
        {
            PartyMember = partyMember;
        }
    }
}
