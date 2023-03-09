using TMPro;
using UnityEngine;

namespace Score
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        private int _score = 0;
        public int Score
        {
            get => _score;
            set => _score = value;
        }

        private void Start()
        {
            UpdateScoreText();
        }

        private void OnEnable()
        {
            Collectible.OnScoreChanged += OnCollectible;
        }

        private void OnDisable()
        {
            Collectible.OnScoreChanged -= OnCollectible;
        }

        private void OnCollectible(int amount)
        {
            _score += amount;
            UpdateScoreText();
        }

        public void DiscountScore(int discount)
        {
            if ((_score - discount) < 0)
            {
                return;
            }
            _score -= discount;
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            scoreText.text = _score.ToString("$000");
        }
    }
}