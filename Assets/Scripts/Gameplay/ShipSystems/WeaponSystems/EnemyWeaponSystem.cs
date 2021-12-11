using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class EnemyWeaponSystem : WeaponSystem
    {
        [SerializeField] 
        private Vector2 _fireDelay;
        
        protected override float GetFireDelay()
        {
            return Random.Range(_fireDelay.x / _energy, _fireDelay.y / _energy);
        }

        protected override void ProcessFire()
        {
            TriggerFire();
        }
    }
}