using System.Collections;
using TMPro;
using UnityEngine;
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
        private RectTransform limitBar;

        [SerializeField] 
        private Image profilePicture;

        [SerializeField] 
        private TextMeshProUGUI characterName;

        [SerializeField] 
        private float currentRestValue = 0f;

        [SerializeField] 
        private float maxRestValue = 5f;

        [SerializeField] 
        private float currentLimitValue = 0f;

        [SerializeField] 
        private float maxLimitValue = 5f;

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
            InitializeBars();
            StartUpdateRestBar();
        }

        private void InitializeBars()
        {
            restBar.localScale = new Vector3(currentRestValue, 1f, 1f);
            limitBar.localScale = new Vector3(currentLimitValue, 1f, 1f);
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
