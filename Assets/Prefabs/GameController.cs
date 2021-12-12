using System;
using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.Core
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        public int Score { get; private set; } = 0;

        public event Action OnScoreChanged;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }
        
        public void RegisterPlayerShip(IPlayerSpaceship spaceship)
        {
            var healthSystem = spaceship.GetShipSystem<IHealthSystem>();
            healthSystem.OnHealthLeft += OnPlayerHealthLeft;
            
            void OnPlayerHealthLeft()
            {
                print("GAME OVER");
                healthSystem.OnHealthLeft -= OnPlayerHealthLeft;
            }
        }

        public void RegisterEnemyShip(IEnemySpaceship spaceship)
        {
            var healthSystem = spaceship.GetShipSystem<IHealthSystem>();
            healthSystem.OnHealthLeft += OnEnemyHealthLeft;
            spaceship.OnOutOfBorderReached += OnEnemyOutOfBorderReached;
            
            void OnEnemyHealthLeft()
            {
                Score++;
                OnScoreChanged?.Invoke();
                spaceship.OnOutOfBorderReached -= OnEnemyOutOfBorderReached;
                healthSystem.OnHealthLeft -= OnEnemyHealthLeft;
            }
            
            void OnEnemyOutOfBorderReached()
            {
                spaceship.OnOutOfBorderReached -= OnEnemyOutOfBorderReached;
                healthSystem.OnHealthLeft -= OnEnemyHealthLeft;
            }
        }
    }

}
