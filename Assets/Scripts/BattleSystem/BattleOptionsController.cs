using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JRPG.BattleSystem
{
    internal sealed class BattleOptionsController : MonoBehaviour
    {
        [Header("Panels")] 
        [SerializeField] private GameObject attackPanel;

        [SerializeField] private GameObject magicPanel;

        [SerializeField] private GameObject itemPanel;

        [SerializeField] private GameObject limitPanel;

        [SerializeField] private GameObject etcPanel;

        [Header("Misc")] 
        [SerializeField] private GameObject pageNumber;

    }
}
