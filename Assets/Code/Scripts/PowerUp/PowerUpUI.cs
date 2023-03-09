using UnityEngine;
using UI;

namespace PowerUp
{
    public class PowerUpUI : MonoBehaviour
    {
        [SerializeField] private GameObject powerUpMenu;
        [SerializeField] private ProgressBar progressBar;

        private void OnEnable()
        {
            progressBar.OnLoaded += ShowPowerUpMenu;
            progressBar.OnEmpted += ClosePowerUpMenu;
        }

        private void OnDisable()
        {
            progressBar.OnLoaded -= ShowPowerUpMenu;
            progressBar.OnEmpted -= ClosePowerUpMenu;
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
}