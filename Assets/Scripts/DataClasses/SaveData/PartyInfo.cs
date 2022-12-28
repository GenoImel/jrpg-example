using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JRPG.DataClasses.SaveData
{
    [System.Serializable]
    internal sealed class PartyInfo
    {
        [Header("Party Members")]
        [SerializeField]
        public List<PartyMember> partyMembers;
    }

    [System.Serializable]
    internal sealed class PartyMember
    {
        public string name;
        public int level;
        public int health;
        public int maxHealth;
        public int magic;
        public int maxMagic;
        public int basePhysicalAttack;
        public int baseMagicAttack;
        public int baseDefense;
        public int baseSpeed;
        public string positionOnField;
        public string handedness;

        public Equipment equipment;

        public ActiveRings activeRings;

        public ActiveNecklace activeNecklace;

        public ActiveWeapons activeWeapons;
    }

    internal sealed class Equipment
    {
        public string hat;
        public string shirt;
        public string shoulders;
        public string gloves;
        public string pants;
        public string boots;
    }

    internal sealed class ActiveRings
    {
        public string leftRing1;
        public string leftRing2;
        public string rightRing1;
        public string rightRing2;
    }

    internal sealed class ActiveNecklace
    {
        public string necklaceName;
        public int numCharmSlots;
        public List<string> charms;
    }

    internal sealed class ActiveWeapons
    {
        public ActiveWeapon rightHandWeapon;
        public ActiveWeapon leftHandWeapon;
    }

    internal sealed class ActiveWeapon
    {
        public string weaponName;
        public int numGemSlots;
        public List<string> gemSlots;
    }
}
