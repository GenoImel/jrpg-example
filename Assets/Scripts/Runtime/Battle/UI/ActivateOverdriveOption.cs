using Jrpg.Core;
using Jrpg.Runtime.Battle;

namespace Jrpg.Runtime.Battle.UI
{
    internal sealed class ActivateOverdriveOption : Option
    {
        public override void OnClick()
        {
            GameManager.Publish(new ActivateOverdriveMessage());
        }
    }
}