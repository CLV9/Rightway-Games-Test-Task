using Gameplay.Core;
using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.Weapons.Projectiles
{
    public abstract class Projectile : MonoBehaviour, IDamageDealer, IBattleUnit
    {
        [SerializeField] 
        private float _damage;

        public UnitBattleIdentity BattleIdentity { get; private set; }
        public float Damage => _damage;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var damagableObject = other.gameObject.GetComponent<IHealthSystem>();
            
            if (damagableObject != null 
                && damagableObject.BattleIdentity != BattleIdentity)
            {
                damagableObject.ApplyDamage(this);
            }
        }

        public void Init(UnitBattleIdentity battleIdentity)
        {
            BattleIdentity = battleIdentity;
        }
    }
}
