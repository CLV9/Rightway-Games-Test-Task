using System;
using Gameplay.Core;

namespace Gameplay.ShipSystems
{
    public interface IHealthSystem : IShipSystem
    {
        UnitBattleIdentity BattleIdentity { get; }
        
        event Action OnHealthLeft;
        event Action OnCurrentHealthChanged;
        
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


