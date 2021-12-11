using Gameplay.Core;

namespace Gameplay.ShipSystems
{
    public interface IHealthSystem
    {
        UnitBattleIdentity BattleIdentity { get; }
        void ApplyDamage(IDamageDealer damageDealer);
        void HealUp(IHealer healer);
    }

    public interface IHealer
    {
        float HealAmount { get; }
    }
    
    public interface IDamageDealer
    {
        float Damage { get; }
    }
}


