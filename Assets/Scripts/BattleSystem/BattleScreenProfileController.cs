using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

namespace JRPG.BattleSystem
{
    internal sealed class BattleScreenProfileController : MonoBehaviour
    {
        [Header("UI Bars")] 
        [SerializeField] private RectTransform restBar;

        [SerializeField] private RectTransform healthBar;

        [SerializeField] private RectTransform magicBar;

        [SerializeField] private RectTransform limitBar;

        [SerializeField] private Image profilePicture;

        [SerializeField] private float currentRestValue = 0f;

        [SerializeField] private float maxRestValue = 5f;

        [SerializeField] private float currentLimitValue = 0f;

        [SerializeField] private float maxLimitValue = 5f;

        public BattleScreenPartyMember battleScreenPartyMember;
        
        void Start()
        {
            InitializeBars();
        }

        private void InitializeBars()
        {
            restBar.localScale = new Vector3(currentRestValue, 1f, 1f);
            limitBar.localScale = new Vector3(currentLimitValue, 1f, 1f);
        }

        public void StartUpdateRestBar()
        {
            StartCoroutine(UpdateRestBar());
        }
        
        private IEnumerator UpdateRestBar()
        {
            for (var restVal = currentRestValue; restVal <= maxRestValue; restVal += Time.deltaTime)
            {
                currentRestValue = restVal;
                restBar.localScale = new Vector3(currentRestValue / maxRestValue, 1f, 1f);
                yield return null;
            }
            
            battleScreenPartyMember.RestingComplete();
        }



    }
}
