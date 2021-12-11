using System.Collections;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class EnemyWeaponSystem : WeaponSystem
    {
        [SerializeField] 
        private Vector2 _fireDelay;

        private bool _fire = true;

        private IEnumerator FireDelay(float delay)
        {
            _fire = false;
            yield return new WaitForSeconds(delay);
            _fire = true;
        }
        
        protected override void ProcessFire()
        {
            if (!_fire)
                return;

            TriggerFire();
            StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y)));
        }
    }
}