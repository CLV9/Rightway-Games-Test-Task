using Gameplay.Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text _score;

        private void Start()
        {
            GameController.Instance.OnScoreChanged += UpdateScore;
            UpdateScore();
        }

        private void UpdateScore()
        {
            _score.text = $"Score: {GameController.Instance.Score}";
        }
    }
}