using UnityEngine;
using DG.Tweening;

namespace DefaultUI
{
    public class OptionManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _active;
        [SerializeField]
        private CanvasGroup _canvas;
        private object _animation;

        public void Open()
        {
            _active.SetActive(true);
            if (_animation != null && DOTween.IsTweening(_animation))
                return;

            _animation = _canvas.DOFade(1, 0.5f).target;
        }

        public void Close()
        {
            if (_animation != null && DOTween.IsTweening(_animation))
                return;

            _canvas.DOFade(0, 0.5f).OnComplete(() => _active.SetActive(false));
        }
    }
}
