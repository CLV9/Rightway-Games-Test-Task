using Gameplay.ShipSystems;
using Gameplay.Weapons;

namespace Gameplay.Spaceships
{
    public interface ISpaceship
    {
        UnitBattleIdentity BattleIdentity { get; }
    }
}
