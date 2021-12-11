namespace Gameplay.Weapons
{
    public interface IHealthSystem
    {
        UnitBattleIdentity BattleIdentity { get; }
        void ApplyDamage(IDamageDealer damageDealer);
    }
    
    public enum UnitBattleIdentity
    {
        Neutral,
        Ally,
        Enemy
    }
}


