using System;
using Jrpg.Core;
using Jrpg.Runtime.DataClasses.PartyData;
using Jrpg.Runtime.Systems.GameData;
using UnityEngine;

namespace Jrpg.Runtime.Battle
{
    internal sealed class BattlePartyMember : BaseBattleEntity
    {
        [Header("UI")]
        [SerializeField] 
        private Sprite profilePicture;

        [Header("Scripting")] 
        [SerializeField] 
        private PartyMemberStateMachine stateMachine;
        
        private new PartyMember EntityData { get ; set; }

        public PartyMember GetEntityData()
        {
            return EntityData;
        }

        private ISaveDataSystem saveDataSystem;

        public void SetData(PartyMember memberData)
        {
            EntityData = memberData;
        }

        public string CharacterName => EntityData.Name;

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
