using UnityEngine;

public class ScoreManager : MonoBehaviour, IScore
{
    private int _score = 0;
    public int Score
    {
        get => _score;
        set => _score = value;
    }

    public void IncreaseScore(int value)
    {
        _score += value;
    }

    public void DiscountScore(int discount)
    {
        if ((_score - discount) < 0)
        {
            return;
        }
        _score -= discount;
    }
}