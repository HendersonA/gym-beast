using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action<int> OnScoreChange;
    [SerializeField] private int score = 10;

    private void OnDisable()
    {
        ChangeScore();
    }

    private void ChangeScore()
    {
        OnScoreChange?.Invoke(score);
    }
}
