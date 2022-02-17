using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Home
{
    public class StoryButton : MonoBehaviour
    {
        [SerializeField]
        private DefaultUI.ButtonAnimator _buttonAnimator;
        private HomeManager _manager;
        private int _scenarioNumber;
        public void Init(int number, HomeManager manager)
        {
            _buttonAnimator.Init(Click);
            _scenarioNumber = number;
            _manager = manager;
        }

        private void Click()
        {
            Data.StaticData.StoryBookmark.SetScenarioNumber(_scenarioNumber);
            _manager.StoryStart();
        }
    }
}
