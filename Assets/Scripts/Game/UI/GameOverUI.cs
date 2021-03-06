using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Linq;

namespace Game.UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvas;
        [SerializeField]
        private CanvasGroup _buttonsCanvas;
        [SerializeField]
        private GameObject _slotsParent;
        [SerializeField]
        private CanvasGroup _detailCanvas;
        [SerializeField]
        private TextMeshProUGUI _detailName;
        [SerializeField]
        private TextMeshProUGUI _detailContents;
        private List<ResultClueSlot> _slots;
        private object _detailAnimation;

        public void Init()
        {
            _slots = _slotsParent.GetComponentsInChildren<ResultClueSlot>().ToList();
            _slots.ForEach(x => x.Init(ShowDetails));
            gameObject.SetActive(false);
        }


        public void Show(List<string> clueIDs)
        {
            gameObject.SetActive(true);
            _buttonsCanvas.gameObject.SetActive(false);
            int index = 0;
            clueIDs.ForEach(x => _slots[index++].SetSlot(x));

            _canvas.DOFade(1, 1f).From(0).SetEase(Ease.InQuart).OnComplete(ShowButtons);
        }

        private void ShowButtons()
        {
            _buttonsCanvas.gameObject.SetActive(true);
            _buttonsCanvas.DOFade(1, 0.5f).From(0).SetEase(Ease.InQuart);
        }


        public void ShowDetails(string clueID)
        {
            DefaultSystem.EffectSoundSystem.GetInstance?.PlayEffect("button");
            _detailCanvas.gameObject.SetActive(true);
            _detailAnimation = _detailCanvas.DOFade(1, 0.5f).From(0).target;
            _detailName.text = StaticData.ClueStaticData.GetClue(clueID).Name;
            _detailContents.text = StaticData.ClueStaticData.GetClue(clueID).Contents;
        }

        public void OffDetails()
        {
            if (_detailAnimation != null && DOTween.IsTweening(_detailAnimation))
            {
                return;
            }
            _detailAnimation = _detailCanvas.DOFade(0, 0.5f).OnComplete(() => _detailCanvas.gameObject.SetActive(false)).target;
        }
    }
}
