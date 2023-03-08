using UnityEngine;
using UI;
using TMPro;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpIndicatorUI powerUpIndicator;
    [SerializeField] private TextMeshProUGUI textPowerupCost;
    [SerializeField] private ScoreUI scoreUI;
    [SerializeField] private PowerupEffect[] powerupEffect;
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
            powerupEffect[_currentLevel].Apply(target);
            powerUpIndicator.SelectedIndicator(_currentLevel);
            scoreUI.DiscountScore(powerupEffect[_currentLevel].Cost);
            _currentLevel++;
            SetCostText(_currentLevel);
        }
    }

    public void SetCostText(int index)
    {
        if (powerupEffect[index] == null)
            return;

        textPowerupCost.text = powerupEffect[index].Cost.ToString("$000");
    }

    private bool CanLevelUp()
    {
        return _currentLevel < powerupEffect.Length &&
            scoreUI.Score >= powerupEffect[_currentLevel].Cost;
    }

    private void InitPowerup()
    {
        SetCostText(0);
        powerUpIndicator.InstantiateIndicator(powerupEffect.Length);
    }
}