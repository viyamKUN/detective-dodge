using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Story
{
    public class DialogSetter : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _name;
        [SerializeField]
        private TextMeshProUGUI _dialog;

        public void SetDialog(string name, string dialog)
        {
            _name.text = name;
            _dialog.text = dialog;
        }
    }
}
