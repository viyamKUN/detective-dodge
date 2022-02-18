using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace Game.UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvas;
        [SerializeField]
        private CanvasGroup _buttonsCanvas;

        public void Show()
        {
            gameObject.SetActive(true);
            _buttonsCanvas.gameObject.SetActive(false);
            _canvas.DOFade(1, 1f).From(0).SetEase(Ease.InQuart).OnComplete(ShowButtons);
        }

        private void ShowButtons()
        {
            _buttonsCanvas.gameObject.SetActive(true);
            _buttonsCanvas.DOFade(1, 0.5f).From(0).SetEase(Ease.InQuart);
        }
    }
}
