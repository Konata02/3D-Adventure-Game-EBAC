using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Itens
{


    public class ItemLayout : MonoBehaviour
    {

        private ItemSetup _currSetup;
        public Image uiImage;
        public TextMeshProUGUI uiValue;

        public void Load(ItemSetup setup)
        {
            _currSetup = setup;
            UpdateUI();
        }

        private void UpdateUI()
        {
            uiImage.sprite = _currSetup.icon;
        }

        void Update()
        {
            uiValue.text = _currSetup.soInt.value.ToString();
        }

    }

}