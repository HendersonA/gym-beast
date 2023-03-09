using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace PowerUp
{
    public class PowerUpIndicatorUI : MonoBehaviour
    {
        [SerializeField] private Transform wrapperContent;
        [SerializeField] private GameObject prefabIndicator;

        private List<GameObject> inspectorlist = new List<GameObject>();

        public void InstantiateIndicator(int length)
        {
            for (int i = 0; i < length; i++)
            {
                GameObject indicator = Instantiate(
                prefabIndicator,
                wrapperContent.transform.position,
                wrapperContent.transform.rotation,
                wrapperContent.transform);
                inspectorlist.Add(indicator);
            }
        }

        public void SelectedIndicator(int index)
        {
            inspectorlist[index].GetComponent<Image>().color = Color.black;
        }
    }
}