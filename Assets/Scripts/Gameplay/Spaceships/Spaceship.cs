using System.Linq;
using Gameplay.Core;
using Gameplay.Helpers;
using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public abstract class Spaceship : MonoBehaviour, ISpaceship
    {
        private IShipSystem[] _systems;
        private IShipProcess[] _processes;
        
        public abstract UnitBattleIdentity BattleIdentity { get; }

        protected virtual void Start()
        {
            InitSystems();
            InitProcesses();
        }

        private void Update()
        {
            foreach (var process in _processes)
            {
                process.Process();
            }
        }

        private void InitProcesses()
        {
            _processes = GetComponents<IShipProcess>();
        }

        private void InitSystems()
        {
            _systems = GetComponents<IShipSystem>();
            foreach (var system in _systems)
            {
                system.Init(this);
            }
        }

        public T GetShipSystem<T>() where T : IShipSystem
        {
            return (T)_systems.FirstOrDefault(x => x is T);
        }
    }
}
