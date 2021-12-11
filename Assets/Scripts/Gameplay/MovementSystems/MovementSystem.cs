using UnityEngine;

namespace Gameplay.MovementSystems
{
    public abstract class MovementSystem : MonoBehaviour
    {        
        [SerializeField]
        protected float _lateralMovementSpeed;
        
        [SerializeField]
        protected float _longitudinalMovementSpeed;

        public Vector3 LateralMovementNewPosition(float amount)
        {
            return transform.position + transform.TransformDirection(amount * Vector3.right);
        }
        
        public Vector3 LongitudinalMovementNewPosition(float amount)
        {
            return transform.position + transform.TransformDirection(amount * Vector3.up);
        }

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
