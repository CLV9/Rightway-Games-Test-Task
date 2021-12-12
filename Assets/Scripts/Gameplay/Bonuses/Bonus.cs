using Gameplay.Core;
using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.Bonuses
{
    public abstract class Bonus : MonoBehaviour, IBattleUnit
    {
        [SerializeField] 
        private UnitBattleIdentity _battleIdentity;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        private void OnCollisionEnter2D(Collision2D col)
        {
            var spaceship = col.gameObject.GetComponent<ISpaceship>();
            
            if (spaceship != null 
                && spaceship.BattleIdentity == BattleIdentity)
            {
                ApplyBonus(spaceship);
                Destroy(gameObject);
            }
        }

        protected abstract void ApplyBonus(ISpaceship spaceship);
    }
}