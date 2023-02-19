using System;
using UnityEngine;

namespace Jrpg.Core
{
    internal abstract class GameManager : MonoBehaviour
    {
        private const string GameManagerPrefabPath = "GameManager";
        private static GameManager instance;
        
        private readonly MessageManager messageManager = new ();
        private readonly SystemManager systemManager = new ();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            if (instance)
            {
                return;
            }

            var gameManagerPrefab = Resources.Load<GameManager>(GameManagerPrefabPath);
            var gameManager = Instantiate(gameManagerPrefab);

            gameManager.name = gameManager.GetApplicationName();
            
            DontDestroyOnLoad(gameManager);

            instance = gameManager;

            gameManager.OnInitialized();
        }

        /// <summary>
        /// Adds a new message listener.
        /// </summary>
        public static void AddListener<TMessage>(Action<TMessage> listener) where TMessage : IMessage
        {
            instance.messageManager.AddListener(listener);
        }

        /// <summary>
        /// Removes a message listener.
        /// </summary>
        public static void RemoveListener<TMessage>(Action<TMessage> listener) where TMessage : IMessage
        {
            instance.messageManager.RemoveListener(listener);
        }

        /// <summary>
        /// Publishes a message to the systems in the game.
        /// </summary>
        public static void Publish<TMessage>(TMessage message) where TMessage : IMessage
        {
            instance.messageManager.Publish(message);
        }

        /// <returns>
        /// Returns an existing system in the game.
        /// </returns>
        public static TSystem GetSystem<TSystem>()
        {
            return instance.systemManager.GetSystem<TSystem>();
        }
        
        /// <summary>
        /// Adds a system to the game.
        /// </summary>
        protected void AddSystem<TSystem, TBindTo>(TSystem system) where TSystem : ISystem, TBindTo
        {
            systemManager.AddSystem<TSystem, TBindTo>(system);
        }
        
        /// <returns>
        /// Name of the application or game.
        /// </returns>
        protected abstract string GetApplicationName();

        /// <summary>
        /// Called when the game manager is initialized.
        /// </summary>
        protected abstract void OnInitialized();
    }
}
