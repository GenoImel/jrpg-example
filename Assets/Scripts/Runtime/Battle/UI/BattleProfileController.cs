using System.Collections;
using Jrpg.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Jrpg.Runtime.Battle.UI
{
    internal sealed class BattleProfileController : MonoBehaviour
    {
        [Header("UI Elements")] 
        [SerializeField] 
        private RectTransform restBar;

        [SerializeField] 
        private RectTransform healthBar;

        [SerializeField] 
        private RectTransform magicBar;

        [SerializeField] 
        private RectTransform overdriveBar;

        [SerializeField] 
        private Image profilePicture;

        [SerializeField] 
        private TextMeshProUGUI characterName;

        [SerializeField] 
        private float currentRestValue = 0f;

        [SerializeField] 
        private float maxRestValue = 5f;

        [SerializeField] 
        private float currentOverdriveValue = 0f;

        [SerializeField] 
        private float maxOverdriveValue = 100f;

        [SerializeField] 
        private PartyMemberStateMachine partyMember;

        public string CharacterName
        {
            get => characterName.text;
            set => characterName.text = value;
        }
        
        public Sprite ProfilePicture
        {
            get => profilePicture.sprite;
            set => profilePicture.sprite = value;
        }

        public PartyMemberStateMachine PartyMember
        {
            get => partyMember;
            set => partyMember = value;
        }

        void Start()
        {
            InitializeValues();
            InitializeBars();
            StartUpdateRestBar();
        }

        private void InitializeValues()
        {
            currentOverdriveValue = partyMember.BattlePartyMember.GetEntityData().OverdriveLevel;
        }

        private void InitializeBars()
        {
            restBar.localScale = new Vector3(currentRestValue / maxRestValue, 1f, 1f);
            overdriveBar.localScale = new Vector3(currentOverdriveValue / maxOverdriveValue, 1f, 1f);

            if (currentOverdriveValue / maxOverdriveValue >= 1f)
            {
                var partyMemberData = partyMember.BattlePartyMember.GetEntityData();
                partyMemberData.OverdriveAchieved = true;
                //GameManager.Publish(new UpdateOverdriveAchievedMessage(partyMember.BattlePartyMember));
            }
        }

        private void StartUpdateRestBar()
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
            
            partyMember.RestingComplete();
        }

        

    }
}
