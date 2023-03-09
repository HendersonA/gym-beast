using UnityEngine;

public class StackManager : MonoBehaviour
{
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private StackAbility stackAbility;

    private void Start()
    {
        progressBar.OnLoaded += UnloadStack;
    }

    private void UnloadStack()
    {
        stackAbility.UnloadStack();
    }
}