using System;
using Gameplay.Core;
using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class HealthSystem : MonoBehaviour, IHealthSystem
    {
        [SerializeField] private float _maxHealth;

        public float MaxHealth => _maxHealth;
        public float CurrentHealth { get; private set; }
        public UnitBattleIdentity BattleIdentity { get; private set; }
        
        public event Action OnHealthLeft;
        public event Action OnCurrentHealthChanged;
        
        public void ApplyDamage(IDamageDealer damageDealer)
        {
            CurrentHealth -= damageDealer.Damage;
            OnCurrentHealthChanged?.Invoke();
            if (CurrentHealth <= 0)
            {
                OnHealthLeft?.Invoke();
                Destroy(gameObject);
            }
        }

        public void HealUp(IHealer healer)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + healer.HealAmount, 0, _maxHealth);
            OnCurrentHealthChanged?.Invoke();
        }

        public void Init(ISpaceship ship)
        {
            BattleIdentity = ship.BattleIdentity;
            CurrentHealth = _maxHealth;
            OnCurrentHealthChanged?.Invoke();
        }
    }
}