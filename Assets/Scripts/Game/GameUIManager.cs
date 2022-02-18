using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game
{
    using DefaultUI;
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField]
        private OptionManager _optionManager;
        [SerializeField]
        private TextMeshProUGUI _timer;

        public void Init()
        {

        }

        public void SetTimer(int playTime)
        {
            int min = playTime / 60;
            int sec = playTime % 60;
            _timer.text = $"{(min < 10 ? "0" : "")}{min}:{(sec < 10 ? "0" : "")}{sec}";
        }
    }
}
