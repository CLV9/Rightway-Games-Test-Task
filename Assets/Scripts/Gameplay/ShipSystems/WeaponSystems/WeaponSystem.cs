using System.Collections.Generic;
using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    public abstract class WeaponSystem : MonoBehaviour, IShipSystem, IShipProcess
    {
        [SerializeField]
        private List<Weapon> _weapons;

        public void Init(ISpaceship spaceship)
        {
            _weapons.ForEach(w => w.Init(spaceship.BattleIdentity));
        }

        public void Process()
        {
            ProcessFire();
        }

        protected void TriggerFire()
        {
            _weapons.ForEach(w => w.TriggerFire());
        }

        protected abstract void ProcessFire();
    }
}
