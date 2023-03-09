using System;
using UnityEngine;

namespace Score
{
    public class Collectible : MonoBehaviour
    {
        public static event Action<int> OnScoreChanged;
        [SerializeField] private int score = 10;

        private void OnDisable()
        {
            ChangeScore();
        }

        private void ChangeScore()
        {
            OnScoreChanged?.Invoke(score);
        }
    }
}
