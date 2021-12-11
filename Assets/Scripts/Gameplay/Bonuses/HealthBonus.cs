using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.Bonuses
{
    public class HealthBonus : Bonus, IHealer
    {
        [SerializeField] private float _heal = 15f;
        
        public float HealAmount => _heal;
        
        protected override void ApplyBonus(Collision2D col)
        {
            var healthSystem = col.gameObject.GetComponent<IHealthSystem>();
            if (healthSystem == null)
                return;
            healthSystem.HealUp(this);
        }
    }
}