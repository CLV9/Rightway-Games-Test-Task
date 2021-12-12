using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.Bonuses
{
    public class HealthBonus : Bonus, IHealer
    {
        [SerializeField] private float _heal = 15f;
        
        public float HealAmount => _heal;
        
        protected override void ApplyBonus(ISpaceship spaceship)
        {
            var healthSystem = spaceship.GetShipSystem<IHealthSystem>();
            if (healthSystem == null)
                return;
            healthSystem.HealUp(this);
        }
    }
}