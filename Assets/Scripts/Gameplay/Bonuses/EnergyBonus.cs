using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.Bonuses
{
    public class EnergyBonus : Bonus, IEnergy
    {
        [SerializeField] 
        private float _time = 2f;

        [SerializeField] 
        private float _energy = 2;

        public float Amount => _energy;
        public float Time => _time;
        
        protected override void ApplyBonus(ISpaceship spaceship)
        {
            var weaponSystem = spaceship.GetShipSystem<IWeaponSystem>();
            if (weaponSystem == null)
                return;
            weaponSystem.TakeEnergy(this);
        }
    }
}