using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultUI
{
    public class OptionManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _active;
        public void Open()
        {
            _active.SetActive(true);
        }

        public void Close()
        {
            _active.SetActive(false);
        }
    }
}
