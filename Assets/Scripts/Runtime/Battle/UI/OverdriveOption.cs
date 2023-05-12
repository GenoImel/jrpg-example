using Jrpg.Runtime.DataClasses.OverdriveData;
using UnityEngine;

namespace Jrpg.Runtime.Battle.UI
{
    internal sealed class OverdriveOption : Option
    {
        [Header("Overdrive")]
        [SerializeField] private Overdrive assignedOverdrive;

        public Overdrive AssignedOverdrive => assignedOverdrive;
        
        public void InitializeOverdriveOption(Overdrive overdrive)
        {
            nameText.text = overdrive.Name;
            assignedOverdrive = overdrive;
        }
    }
}
