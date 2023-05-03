using Jrpg.Core;
using UnityEngine;

namespace Jrpg.Runtime.Battle
{
    internal sealed class BattlePartyMember : MonoBehaviour
    {
        [Header("General Info")] 
        [SerializeField] 
        private string characterName;

        [Header("UI")]
        [SerializeField] 
        private Sprite profilePicture;

        [SerializeField] 
        private GameObject selector;

        [Header("Scripting")] 
        [SerializeField] 
        private PartyMemberStateMachine stateMachine;

        public string CharacterName => characterName;

        public Sprite ProfilePicture => profilePicture;

        public PartyMemberStateMachine StateMachine => stateMachine;

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
    }
}
