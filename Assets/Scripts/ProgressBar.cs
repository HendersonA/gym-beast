using UnityEngine;
using UnityEngine.UI;
using System;

public class ProgressBar : MonoBehaviour
{
    public event Action OnLoaded;
    [SerializeField] private Image progressBarImage;
    [SerializeField] private float speedLoad = 0.05f;
    private float _progressBarValue = 0f;
    private bool _isProgressBarFilled = false;


    private void FullProgressBar()
    {
        if (progressBarImage.fillAmount < 1f)
        {
            _progressBarValue++;
            SetProgressBarValue(_progressBarValue);
        }
        else if (progressBarImage.fillAmount == 1f && _isProgressBarFilled == false)
        {
            OnLoaded.Invoke();
            _isProgressBarFilled = true;
        }
    }

    private void EmptyProgressBar()
    {
        _isProgressBarFilled = false;
        _progressBarValue = 0f;
        SetProgressBarValue(progressBarImage.fillAmount = _progressBarValue);
    }

    private void SetProgressBarValue(float newValue)
    {
        progressBarImage.fillAmount = newValue * speedLoad;
    }

    private void OnTriggerStay(Collider other)
    {
        IPlayer player = other.GetComponent<IPlayer>();
        if (player != null)
        {
            FullProgressBar();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IPlayer player = other.GetComponent<IPlayer>();
        if (player != null)
        {
            EmptyProgressBar();
        }
    }
}