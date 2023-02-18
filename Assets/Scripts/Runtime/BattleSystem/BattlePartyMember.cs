using UnityEngine;

namespace Jrpg.Runtime.BattleSystem
{
    internal sealed class BattlePartyMember : MonoBehaviour
    {
        [Header("General Info")] 
        [SerializeField] private string characterName;

        [Header("UI")]
        [SerializeField] private Sprite profilePicture;

        [SerializeField] private GameObject selector;

        [Header("Scripting")] 
        [SerializeField] private PartyMemberStateMachine stateMachine;

        public delegate void PartyMemberAdded(BattlePartyMember battlePartyMember);

        public static event PartyMemberAdded OnPartyMemberAdded;
        
        public string CharacterName
        {
            get => characterName;
        }

        public Sprite ProfilePicture
        {
            get => profilePicture;
        }

        public PartyMemberStateMachine StateMachine
        {
            get => stateMachine;
        }

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        void Start()
        {
            OnPartyMemberAdded?.Invoke(this);
        }

        private void OnPartyMemberSelected(BattlePartyMember battlePartyMember)
        {
            SetSelected(battlePartyMember == this);
        }

        private void SetSelected(bool isSelected)
        {
            selector.SetActive(isSelected);
        }

        private void AddListeners()
        {
            PartyCommandController.OnPartyMemberSelected += OnPartyMemberSelected;
        }

        private void RemoveListeners()
        {
            PartyCommandController.OnPartyMemberSelected -= OnPartyMemberSelected;
        }
    }
}
