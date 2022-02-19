using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace Title
{
    public class NameEnterManaegr : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvas;
        [SerializeField]
        private TitleManager _titleManager;
        [SerializeField]
        private InputField _input;
        [SerializeField]
        private RectTransform _rect;

        public void Open()
        {
            _canvas.gameObject.SetActive(true);
            _canvas.DOFade(1, 0.5f).From(0);
        }

        public void EnterButton()
        {
            DefaultSystem.EffectSoundSystem.GetInstance?.PlayEffect("button");
            if (_input.text?.Length < 2)
            {
                _rect.DOShakeAnchorPos(0.5f, 40).OnComplete(() => _rect.anchoredPosition = Vector2.zero);
                _input.text = "";
                return;
            }
            else
            {
                int storyCount = 7;
                DefaultSystem.PlayerSaveData.Init(_input.text, storyCount);
                _titleManager.EnterHomeScene();
            }
        }
    }
}
