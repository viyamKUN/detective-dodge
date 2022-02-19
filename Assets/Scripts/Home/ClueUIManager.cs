using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Home
{
    using StaticData;
    public class ClueUIManager : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvas;
        [SerializeField]
        private RectTransform _rect;
        [SerializeField]
        private ClueSection _essentialScetion;
        [SerializeField]
        private ClueSection _baseScetion;
        [SerializeField]
        private ClueSection _tmiScetion;
        [SerializeField]
        private CanvasGroup _detailObject;
        [SerializeField]
        private TextMeshProUGUI _detailName;
        [SerializeField]
        private TextMeshProUGUI _detailContents;
        private object _canvasAnimation;
        private object _rectAnimation;

        public void Init()
        {
            _essentialScetion.Init(ShowDetails);
            _baseScetion.Init(ShowDetails);
            _tmiScetion.Init(ShowDetails);
            gameObject.SetActive(false);
        }

        public void Open()
        {
            if (_canvasAnimation != null && _rectAnimation != null && DOTween.IsTweening(_canvasAnimation) && DOTween.IsTweening(_rectAnimation))
                return;
            gameObject.SetActive(true);
            DefaultSystem.EffectSoundSystem.GetInstance?.PlayEffect("button");
            SetData();
            _canvasAnimation = _canvas.DOFade(1, 0.5f).From(0).target;
            _rectAnimation = _rect.DOAnchorPosY(0, 0.5f).From(new Vector2(-200, 0)).SetEase(Ease.InOutBack).target;
        }

        public void Close()
        {
            if (_canvasAnimation != null && _rectAnimation != null && DOTween.IsTweening(_canvasAnimation) && DOTween.IsTweening(_rectAnimation))
                return;
            DefaultSystem.EffectSoundSystem.GetInstance?.PlayEffect("button");
            _canvasAnimation = _canvas.DOFade(0, 0.5f).From(1).OnComplete(() => gameObject.SetActive(false)).target;
            _rectAnimation = _rect.DOAnchorPosY(-200, 0.5f).From(Vector2.zero).SetEase(Ease.InOutBack).target;
        }

        private void SetData()
        {
            _essentialScetion.SetData(ClueStaticData.GetCluesByType(Models.Story.ClueType.Essential));
            _baseScetion.SetData(ClueStaticData.GetCluesByType(Models.Story.ClueType.Base));
            _tmiScetion.SetData(ClueStaticData.GetCluesByType(Models.Story.ClueType.TMI));
        }

        private void ShowDetails(string id)
        {
            DefaultSystem.EffectSoundSystem.GetInstance?.PlayEffect("button");
            _detailObject.gameObject.SetActive(true);
            _detailObject.DOFade(1, 0.5f).From(0);
            _detailName.text = ClueStaticData.GetClue(id).Name;
            _detailContents.text = ClueStaticData.GetClue(id).Contents;
        }

        public void CloseDetails()
        {
            _detailObject.DOFade(0, 0.5f).OnComplete(() => _detailObject.gameObject.SetActive(false));
        }
    }
}
