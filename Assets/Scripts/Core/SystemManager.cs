using System;
using System.Collections.Generic;

namespace Jrpg.Core
{
    internal sealed class SystemManager
    {
        private readonly IDictionary<Type, ISystem> systems =
            new Dictionary<Type, ISystem>();

        public void AddSystem<TSystem, TBindTo>(TSystem system)
            where TSystem : TBindTo, ISystem
        {
            if (system == null)
            {
                throw new Exception($"{nameof(system)} cannot be null");
            }

            var systemType = typeof(TBindTo);
            systems[systemType] = system;
        }

        public TSystem GetSystem<TSystem>()
        {
            var SystemType = typeof(TSystem);
            if (systems.TryGetValue(SystemType, out var system))
            {
                return (TSystem)system;
            }

            throw new Exception($"System {SystemType} does not exist");
        }
    }
}
