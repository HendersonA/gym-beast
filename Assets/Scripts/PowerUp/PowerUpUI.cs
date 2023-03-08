using UnityEngine;

public class PowerUpUI : MonoBehaviour
{
    [SerializeField] private GameObject powerUpMenu;
    [SerializeField] private ProgressBar progressBar;

    private void Start()
    {
        progressBar.OnLoaded += ShowPowerUpMenu;
        progressBar.OnEmpty += ClosePowerUpMenu;
    }

    public void ShowPowerUpMenu()
    {
        powerUpMenu.SetActive(true);
    }

    public void ClosePowerUpMenu()
    {
        powerUpMenu.SetActive(false);
    }
}