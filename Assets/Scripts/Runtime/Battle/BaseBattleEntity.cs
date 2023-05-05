using Jrpg.Runtime.DataClasses.Bases;
using UnityEngine;

namespace Jrpg.Runtime.Battle
{
    internal class BaseBattleEntity : MonoBehaviour
    {
        [SerializeField] 
        protected GameObject selector;
        
        protected void SetSelected(bool isSelected)
        {
            selector.SetActive(isSelected);
        }
    }
}
