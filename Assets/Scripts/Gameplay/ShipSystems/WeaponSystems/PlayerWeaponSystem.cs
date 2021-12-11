using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class PlayerWeaponSystem : WeaponSystem
    {
        protected override void ProcessFire()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                TriggerFire();
            }
        }
    }
}