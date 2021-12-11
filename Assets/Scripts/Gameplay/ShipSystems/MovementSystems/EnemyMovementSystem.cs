using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class EnemyMovementSystem : MovementSystem
    {
        protected override void ProcessMovement()
        {
            LongitudinalMovement(Time.deltaTime);
        }
    }
}