using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    public abstract class WeaponSystem : MonoBehaviour, IShipSystem, IShipProcess, IWeaponSystem
    {
        [SerializeField]
        private List<Weapon> _weapons;

        [SerializeField] 
        protected float _energy;

        private bool _canFire = true;
        
        public float Energy => _energy;
        
        public event Action OnEnergyChanged;
        
        private IEnumerator FireDelayRoutine(float delay)
        {
            _canFire = false;
            yield return new WaitForSeconds(delay);
            _canFire = true;
        }

        public void Init(ISpaceship spaceship)
        {
            _weapons.ForEach(w => w.Init(spaceship.BattleIdentity));
        }

        public void Process()
        {
            if (!_canFire)
                return;
            ProcessFire();
            StartCoroutine(FireDelayRoutine(GetFireDelay()));
        }

        public void TakeEnergy(IEnergy energy)
        {
            StartCoroutine(ReduceFireDelayRoutine(energy));
        }

        protected IEnumerator ReduceFireDelayRoutine(IEnergy energy)
        {
            _energy += energy.Amount;
            OnEnergyChanged?.Invoke();
            yield return new WaitForSeconds(energy.Time);
            _energy -= energy.Amount;
            OnEnergyChanged?.Invoke();
        }

        protected void TriggerFire()
        {
            _weapons.ForEach(w => w.TriggerFire());
        }

        protected abstract float GetFireDelay();

        protected abstract void ProcessFire();
    }
}
