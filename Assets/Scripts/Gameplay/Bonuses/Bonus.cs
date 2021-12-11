using Gameplay.Core;
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
            var unit = col.gameObject.GetComponent<IBattleUnit>();
            
            if (unit != null 
                && unit.BattleIdentity == BattleIdentity)
            {
                ApplyBonus(col);
                Destroy(gameObject);
            }
        }

        protected abstract void ApplyBonus(Collision2D unit);
    }
}