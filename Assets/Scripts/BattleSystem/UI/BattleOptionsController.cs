using UnityEngine;
using UnityEngine.UI;

namespace JRPG.BattleSystem.UI
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

        [SerializeField] private Image panelBackground;

    }
}
