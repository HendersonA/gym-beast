using UnityEngine;
using TMPro;
using Score;

namespace PowerUp
{
    public class PowerUpScript : MonoBehaviour
    {
        [SerializeField] private PowerUpIndicatorUI powerUpIndicator;
        [SerializeField] private TMP_Text textPowerUpCost;
        [SerializeField] private ScoreUI scoreUI;
        [SerializeField] private PowerUpEffect[] powerUpEffect;
        [SerializeField] private GameObject target;

        private int _currentLevel = 0;

        private void Start()
        {
            InitPowerup();
        }

        public void SetPowerup()
        {
            if (CanLevelUp())
            {
                powerUpEffect[_currentLevel].Apply(target);
                powerUpIndicator.SelectedIndicator(_currentLevel);
                scoreUI.DiscountScore(powerUpEffect[_currentLevel].Cost);
                SetCostText(_currentLevel);
                _currentLevel++;
            }
        }

        public void SetCostText(int index)
        {
            if (powerUpEffect[index] == null)
                return;

            textPowerUpCost.text = powerUpEffect[index].Cost.ToString("$000");
        }

        private bool CanLevelUp()
        {
            return _currentLevel < powerUpEffect.Length &&
                scoreUI.Score >= powerUpEffect[_currentLevel].Cost;
        }

        private void InitPowerup()
        {
            SetCostText(0);
            powerUpIndicator.InstantiateIndicator(powerUpEffect.Length);
        }
    }
}