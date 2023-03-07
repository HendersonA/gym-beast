using UnityEngine;

public class StackManager : MonoBehaviour
{
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private StackEnemy stackEnemy;
    [SerializeField] private ScoreManager scoreManager;

    private void Start()
    {
        progressBar.OnLoaded += UnloadStack;
    }

    private void UnloadStack()
    {
        scoreManager.IncreaseScore(stackEnemy.UnloadStack());
    }
}