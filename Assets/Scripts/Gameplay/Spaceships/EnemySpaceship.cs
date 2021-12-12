using System;
using Gameplay.Core;
using Gameplay.Helpers;

namespace Gameplay.Spaceships
{
    public class EnemySpaceship : Spaceship, IEnemySpaceship
    {
        public override UnitBattleIdentity BattleIdentity => UnitBattleIdentity.Enemy;

        public event Action OnOutOfBorderReached;

        protected override void Start()
        {
            base.Start();
            GameController.Instance.RegisterEnemyShip(this);
            GetComponent<OutOfBorderDestructor>().OnOutOfBorderReached += OutOfBorderReached;
        }

        private void OutOfBorderReached()
        {
            OnOutOfBorderReached?.Invoke();
        }
    }

    public interface IEnemySpaceship : ISpaceship
    {
        event Action OnOutOfBorderReached;
    }
}