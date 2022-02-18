using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game.UI
{
    using DefaultUI;
    public class GameUIManager : MonoBehaviour
    {
        [Header("Other Managers")]
        [SerializeField]
        private GameOverUI _overUI;
        [SerializeField]
        private OptionManager _optionManager;
        [Header("UpperUI")]
        [SerializeField]
        private TextMeshProUGUI _timer;
        [SerializeField]
        private Image _hpGauge;
        [SerializeField]
        private Image _expGauge;

        public void Init()
        {

        }

        public void SetTimer(int playTime)
        {
            int min = playTime / 60;
            int sec = playTime % 60;
            _timer.text = $"{(min < 10 ? "0" : "")}{min}:{(sec < 10 ? "0" : "")}{sec}";
        }

        public void SetGauges(float hpRatio, float expRatio)
        {
            _hpGauge.fillAmount = hpRatio;
            _expGauge.fillAmount = expRatio;
        }

        public void GameOverUI()
        {
            _overUI.Show();
        }
    }
}
