using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class PlayerWeaponSystem : WeaponSystem
    {
        [SerializeField] 
        private float _fireDelay;
        
        protected override float GetFireDelay()
        {
            return _fireDelay / _energy;
        }

        protected override void ProcessFire()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                TriggerFire();
            }
        }
    }
}