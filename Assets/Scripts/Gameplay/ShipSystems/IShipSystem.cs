using System;
using Gameplay.Spaceships;

namespace Gameplay.ShipSystems
{
    public interface IShipSystem
    {
        void Init(ISpaceship ship);
    }

    public interface IShipProcess
    {
        void Process();
    }
}