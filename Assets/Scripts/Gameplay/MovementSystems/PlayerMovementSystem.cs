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
           // var potentialPos = LateralMovementNewPosition(amount);
           // if (FitInGameplayBounds(potentialPos))
          //  {
          //      LateralMovement(amount);
          //  }
            LateralMovement(amount);
        }
        
        private bool FitInGameplayBounds(Vector3 potentialPos) => 
            GameAreaHelper.FitInGameplayBounds(potentialPos, _hull.bounds);
    }
}