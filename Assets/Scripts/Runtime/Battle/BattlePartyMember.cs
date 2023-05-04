using System;
using Jrpg.Core;
using Jrpg.Runtime.DataClasses.PartyData;
using Jrpg.Runtime.Systems.GameData;
using UnityEngine;

namespace Jrpg.Runtime.Battle
{
    internal sealed class BattlePartyMember : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] 
        private Sprite profilePicture;

        [SerializeField] 
        private GameObject selector;

        [Header("Scripting")] 
        [SerializeField] 
        private PartyMemberStateMachine stateMachine;
        
        private PartyMember MemberData { get; set; }

        private ISaveDataSystem saveDataSystem;

        public void SetData(PartyMember memberData)
        {
            MemberData = memberData;
        }

        public string GetCharacterName()
        {
            return MemberData.Name;
        }

        public string CharacterName => MemberData.Name;

        public Sprite ProfilePicture => profilePicture;

        public PartyMemberStateMachine StateMachine => stateMachine;

        private void Awake()
        {
            saveDataSystem = GameManager.GetSystem<ISaveDataSystem>();
        }

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void Start()
        {
            GameManager.Publish(new PartyMemberAddedMessage(this));
        }

        private void OnPartyMemberSelected(PartyMemberSelectedMessage message)
        {
            SetSelected(message.PartyMember == this);
        }

        private void SetSelected(bool isSelected)
        {
            selector.SetActive(isSelected);
        }

        private void AddListeners()
        {
            GameManager.AddListener<PartyMemberSelectedMessage>(OnPartyMemberSelected);
        }

        private void RemoveListeners()
        {
            GameManager.RemoveListener<PartyMemberSelectedMessage>(OnPartyMemberSelected);
        }

        private void OnDestroy()
        {
            //saveDataSystem.WritePartyMemberData(MemberData);
        }
    }
}
