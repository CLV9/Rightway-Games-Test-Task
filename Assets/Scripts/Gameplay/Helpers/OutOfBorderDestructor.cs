using System;
using UnityEngine;

namespace Gameplay.Helpers
{
    public class OutOfBorderDestructor : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _representation;

        public event Action OnOutOfBorderReached;
        
        private void Update()
        {
            CheckBorders();
        }
    
        private void CheckBorders()
        {
            if (GameAreaHelper.IsInGameplayArea(_representation.bounds)) return;
            OnOutOfBorderReached?.Invoke();
            Destroy(gameObject);
        }
    }
}
