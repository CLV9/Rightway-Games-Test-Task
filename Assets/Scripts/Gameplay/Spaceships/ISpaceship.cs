using Gameplay.Core;
using Gameplay.ShipSystems;

namespace Gameplay.Spaceships
{
    public interface ISpaceship : IBattleUnit
    {
        T GetShipSystem<T>() where T : IShipSystem;
    }
}
