using Gameplay.ShipSystems;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIEnergyBar : MonoBehaviour
    {
        [SerializeField] private WeaponSystem _weaponSystem;
        [SerializeField] private TMP_Text _energy;

        private void Awake()
        {
            _weaponSystem.OnEnergyChanged += UpdateEnergyText;
            UpdateEnergyText();
        }

        private void UpdateEnergyText()
        {
            _energy.text = _weaponSystem.Energy.ToString();
        }
    }
}