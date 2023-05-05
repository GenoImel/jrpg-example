using Jrpg.Runtime.DataClasses.EquipmentData;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Jrpg.Runtime.Battle.UI
{
    internal sealed class AttackOption : Option
    {
        [Header("Gem")] 
        [SerializeField] private Gem assignedGem;

        public Gem AssignedGem => assignedGem;

        public void InitializeAttackOption(string attackName, Gem gem)
        {
            NameText.text = attackName;
            assignedGem = gem;
        }
    }
}
