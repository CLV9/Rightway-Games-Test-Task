using Gameplay.Core;

namespace Gameplay.Spaceships
{
    public class PlayerSpaceship : Spaceship, IPlayerSpaceship
    {
        public override UnitBattleIdentity BattleIdentity => UnitBattleIdentity.Ally;

        protected override void Start()
        {
            base.Start();
            GameController.Instance.RegisterPlayerShip(this);
        }
    }

    public interface IPlayerSpaceship : ISpaceship
    {
        
    }
}