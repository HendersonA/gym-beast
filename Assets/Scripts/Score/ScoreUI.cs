using TMPro;
using UnityEngine;

namespace UI
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
            scoreText.text = _score.ToString();
        }

        private void OnEnable()
        {
            Collectible.OnScoreChange += OnCollectible;
        }

        private void OnDisable()
        {
            Collectible.OnScoreChange -= OnCollectible;
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