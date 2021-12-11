using UnityEngine;

namespace Gameplay.Weapons.Projectiles
{
    public abstract class Projectile : MonoBehaviour, IDamageDealer
    {
        [SerializeField]
        private float _speed;

        [SerializeField] 
        private float _damage;
        
        private UnitBattleIdentity _battleIdentity;
        public UnitBattleIdentity BattleIdentity => _battleIdentity;
        public float Damage => _damage;

        private void Update()
        {
            Move(_speed);
        }

        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var damagableObject = other.gameObject.GetComponent<IHealthSystem>();
            
            if (damagableObject != null 
                && damagableObject.BattleIdentity != BattleIdentity)
            {
                damagableObject.ApplyDamage(this);
            }
        }

        protected abstract void Move(float speed);
    }
}
