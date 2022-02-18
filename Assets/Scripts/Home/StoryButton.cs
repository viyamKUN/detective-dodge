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
        [SerializeField]
        private Image _image;
        [SerializeField]
        private GameObject _notReadToken;
        private HomeManager _manager;
        private int _scenarioNumber;
        public void Init(int number, HomeManager manager)
        {
            _buttonAnimator.Init(Click);
            _scenarioNumber = number;
            _manager = manager;
            bool isLock = !DefaultSystem.PlayerSaveData.GetPlayer.ActivateStories[number].IsActivate;
            bool isRead = DefaultSystem.PlayerSaveData.GetPlayer.ActivateStories[number].DidRead;
            _image.color = isLock ? Color.gray : Color.white;
            _notReadToken.SetActive(!isLock && !isRead);
        }

        private void Click()
        {
            Data.StaticData.StoryBookmark.SetScenarioNumber(_scenarioNumber);
            _manager.StoryStart(_scenarioNumber);
        }
    }
}
