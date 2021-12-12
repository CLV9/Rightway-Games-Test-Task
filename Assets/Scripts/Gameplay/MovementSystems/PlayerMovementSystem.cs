using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.MovementSystems
{
    public class PlayerMovementSystem : MovementSystem
    {
        [SerializeField] private SpriteRenderer _hull;
        
        private void Update()
        {
            var amount = Input.GetAxis("Horizontal") * Time.deltaTime;
            LateralMovement(amount);
            var positionX = Mathf.Clamp(transform.position.x, 
                GameAreaHelper.Bounds.LeftBound + _hull.bounds.extents.x, 
                GameAreaHelper.Bounds.RightBound - _hull.bounds.extents.x);
            transform.position = new Vector3(positionX, transform.position.y);
        }
    }
}