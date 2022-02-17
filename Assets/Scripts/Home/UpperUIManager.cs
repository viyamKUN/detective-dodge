using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Home
{
    public class UpperUIManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _name;
        [SerializeField]
        private Image _gauge;

        public void SetUI(string name, float exp)
        {
            _name.text = name;
            _gauge.fillAmount = exp;
        }
    }
}
