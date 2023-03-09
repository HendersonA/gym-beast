using UnityEngine;
using TMPro;
using UI;

namespace Stack
{
    public class StackUI : MonoBehaviour
    {
        [SerializeField] private ProgressBar progressBar;
        [SerializeField] private StackAbility stackAbility;
        [SerializeField] private TMP_Text stackText;

        private void OnEnable()
        {
            stackAbility.OnStacked += SetStackTextOnUI;
            progressBar.OnLoaded += UnloadStack;
        }

        private void OnDisable()
        {
            stackAbility.OnStacked -= SetStackTextOnUI;
            progressBar.OnLoaded -= UnloadStack;
        }

        private void UnloadStack()
        {
            stackAbility.UnloadStack();
        }

        private void SetStackTextOnUI(int currentStackValue)
        {
            stackText.text = $"{currentStackValue}/{stackAbility.LimitStack}";
        }
    }
}