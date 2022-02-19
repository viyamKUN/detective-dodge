using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Home
{
    public class StoryButton : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _rect;
        [SerializeField]
        private DefaultUI.ButtonAnimator _buttonAnimator;
        [SerializeField]
        private Image _image;
        [SerializeField]
        private GameObject _notReadToken;
        private HomeManager _manager;
        private int _scenarioNumber;
        private Vector2 _originalPos;
        public void Init(int number, HomeManager manager)
        {
            _buttonAnimator.Init(Click);
            _originalPos = _rect.anchoredPosition;
            _scenarioNumber = number;
            _manager = manager;
            bool isLock = !DefaultSystem.PlayerSaveData.GetPlayer.ActivateStories[number].IsActivate;
            bool isRead = DefaultSystem.PlayerSaveData.GetPlayer.ActivateStories[number].DidRead;
            _image.color = isLock ? Color.gray : Color.white;
            _notReadToken.SetActive(!isLock && !isRead);
        }

        private void Click()
        {
            bool isLock = !DefaultSystem.PlayerSaveData.GetPlayer.ActivateStories[_scenarioNumber].IsActivate;
            if (isLock)
            {
                _rect.DOShakeAnchorPos(0.5f, 60).OnComplete(() => _rect.anchoredPosition = _originalPos);
                return;
            }
            Data.StaticData.StoryBookmark.SetScenarioNumber(_scenarioNumber);
            _manager.StoryStart(_scenarioNumber);
        }
    }
}
