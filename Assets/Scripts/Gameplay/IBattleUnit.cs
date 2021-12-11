using UnityEngine;

namespace Gameplay.Core
{
    public interface IBattleUnit
    {
        UnitBattleIdentity BattleIdentity { get; }
    }
        
    public enum UnitBattleIdentity
    {
        Neutral,
        Ally,
        Enemy
    }
}