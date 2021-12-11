using System;
using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class HealthSystem : MonoBehaviour, IShipSystem, IHealthSystem
    {
        [SerializeField] private float _maxHealth;
        private float _currentHealth;

        public float MaxHealth => _maxHealth;
        public float CurrentHealth => _currentHealth;
        public UnitBattleIdentity BattleIdentity { get; private set; }
        
        public event Action OnCurrentHealthChanged;
        
        public void ApplyDamage(IDamageDealer damageDealer)
        {
            _currentHealth -= damageDealer.Damage;
            OnCurrentHealthChanged?.Invoke();
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void Init(ISpaceship ship)
        {
            BattleIdentity = ship.BattleIdentity;
            _currentHealth = _maxHealth;
            OnCurrentHealthChanged?.Invoke();
        }
    }
}