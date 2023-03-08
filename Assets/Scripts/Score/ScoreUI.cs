using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        private int Score { get; set; }

        private void Start()
        {
            scoreText.text = Score.ToString();
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
            Score += amount;
            Debug.Log("OnCollectible " + Score);
            scoreText.text = Score.ToString("000");
        }
    }
}