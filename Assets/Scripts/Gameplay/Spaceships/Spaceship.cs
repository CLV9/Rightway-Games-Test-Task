using Gameplay.Core;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IBattleUnit
    {
        [SerializeField]
        private UnitBattleIdentity _battleIdentity;

        private IShipSystem[] _systems;
        private IShipProcess[] _processes;
        
        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        private void Start()
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
    }
}
