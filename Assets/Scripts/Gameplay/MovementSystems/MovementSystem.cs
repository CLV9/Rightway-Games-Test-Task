using UnityEngine;

namespace Gameplay.MovementSystems
{
    public abstract class MovementSystem : MonoBehaviour
    {        
        [SerializeField]
        protected float _lateralMovementSpeed;
        
        [SerializeField]
        protected float _longitudinalMovementSpeed;

        public void LateralMovement(float amount)
        {
            Move(amount * _lateralMovementSpeed, Vector3.right);
        }

        public void LongitudinalMovement(float amount)
        {
            Move(amount * _longitudinalMovementSpeed, Vector3.up);
        }

        protected void Move(float amount, Vector3 axis)
        {
            transform.Translate(amount * axis.normalized);
        }
    }
}
