using Gameplay.ShipSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIHealthBar : MonoBehaviour
    {
        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _health;

        private void Awake()
        {
            _healthSystem.OnCurrentHealthChanged += OnCurrentHealthChanged;
        }

        private void OnCurrentHealthChanged()
        {
            _health.text = _healthSystem.CurrentHealth.ToString();
            _slider.value = (float)_healthSystem.CurrentHealth / _healthSystem.MaxHealth;
        }
    }
}
