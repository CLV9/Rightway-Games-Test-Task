using UnityEngine;

namespace Gameplay.Helpers
{
    public class OutOfBorderDestructor : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _representation;
    
        private void Update()
        {
            CheckBorders();
        }
    
        private void CheckBorders()
        {
            if(!GameAreaHelper.IsInGameplayArea(_representation.bounds))
            {
                Destroy(gameObject);
            }
        }
    }
}
