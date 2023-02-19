using System;
using Jrpg.Core;
using UnityEngine;

namespace Jrpg.Runtime
{
    internal sealed class JrpgGameManager : GameManager
    {
        //[Header("Systems")] 
        //[SerializeField] private SomeSystem someSystem;

        [Header("Management")] 
        [SerializeField] private Transform controllerParentTransform;

        [SerializeField] private Transform systemsParentTransform;

        protected override string GetApplicationName()
        {
            return nameof(JrpgGameManager);
        }

        protected override void OnInitialized()
        {
            //AddSystem<SomeSystem, ISomeSystem>(someSystem);
            
            controllerParentTransform.gameObject.SetActive(true);
            systemsParentTransform.gameObject.SetActive(true);
        }
    }
}
