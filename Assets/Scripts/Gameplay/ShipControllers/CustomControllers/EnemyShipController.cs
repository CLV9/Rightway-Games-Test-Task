using System.Collections;
using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class EnemyShipController : ShipController
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

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            movementSystem.LongitudinalMovement(Time.deltaTime);
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (!_fire)
                return;

            fireSystem.TriggerFire();
            StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y)));
        }
    }
}
