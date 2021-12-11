using UnityEngine;

namespace Gameplay.ShipSystems
{
    public abstract class MovementSystem : MonoBehaviour, IShipProcess
    {
        [SerializeField]
        private float _lateralMovementSpeed;
        
        [SerializeField]
        private float _longitudinalMovementSpeed;

        public Vector3 LateralMovementNewPosition(float amount)
        {
            return transform.position + transform.TransformDirection(amount * Vector3.right);
        }

        public void LateralMovement(float amount)
        {
            Move(amount * _lateralMovementSpeed, Vector3.right);
        }

        public void LongitudinalMovement(float amount)
        {
            Move(amount * _longitudinalMovementSpeed, Vector3.up);
        }

        public void Process()
        {
            ProcessMovement();
        }

        private void Move(float amount, Vector3 axis)
        {
            transform.Translate(amount * axis.normalized);
        }

        protected abstract void ProcessMovement();
    }
}
