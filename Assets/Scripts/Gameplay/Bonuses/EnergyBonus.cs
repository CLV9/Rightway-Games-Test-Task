using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.Bonuses
{
    public class EnergyBonus : Bonus, IEnergy
    {
        [SerializeField] 
        private float _time = 2f;

        [SerializeField] 
        private float _energy = 2;

        public float Amount => _energy;
        public float Time => _time;
        
        protected override void ApplyBonus(Collision2D col)
        {
            var weaponSystem = col.gameObject.GetComponent<IWeaponSystem>();
            if (weaponSystem == null)
                return;
            weaponSystem.TakeEnergy(this);
        }
    }
}