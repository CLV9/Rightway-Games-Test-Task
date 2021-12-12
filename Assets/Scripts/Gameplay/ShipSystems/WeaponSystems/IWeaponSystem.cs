namespace Gameplay.ShipSystems
{
    public interface IWeaponSystem : IShipSystem, IShipProcess
    {
        void TakeEnergy(IEnergy energy);
    }

    public interface IEnergy
    {
        float Amount { get; }
        float Time { get; }
    }
}