using UnityEngine;

namespace Gameplay.MovementSystems
{
    public class LonLatMovementSystem : MovementSystem
    {
        protected void Update()
        {
            LateralMovement(Time.deltaTime * _lateralMovementSpeed);
            LongitudinalMovement(Time.deltaTime * _longitudinalMovementSpeed);
        }
    }
}