using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JRPG.BattleSystem
{
    internal sealed class BattleOptionsController : MonoBehaviour
    {
        [Header("Panels")] 
        [SerializeField] private GameObject AttackPanel;

        [SerializeField] private GameObject MagicPanel;

        [SerializeField] private GameObject ItemPanel;

        [SerializeField] private GameObject LimitPanel;

        [SerializeField] private GameObject EtcPanel;

        [Header("Misc")] 
        [SerializeField] private GameObject PageNumber;

    }
}
