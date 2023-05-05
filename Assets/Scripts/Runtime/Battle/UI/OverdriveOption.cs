using Jrpg.Runtime.DataClasses.OverdriveData;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Jrpg.Runtime.Battle.UI
{
    internal sealed class OverdriveOption : Option
    {
        [Header("Overdrive")]
        [SerializeField] private Overdrive assignedOverdrive;

        public Overdrive AssignedOverdrive => assignedOverdrive;
        
        public void InitializeOverdriveOption(Overdrive overdrive)
        {
            nameText.text = overdrive.OverdriveName;
            assignedOverdrive = overdrive;
        }
    }
}
