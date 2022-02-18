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

        public void Init()
        {
            _essentialScetion.Init(ShowDetails);
            _baseScetion.Init(ShowDetails);
            _tmiScetion.Init(ShowDetails);
            Close();
        }

        public void Open()
        {
            gameObject.SetActive(true);
            SetData();
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        private void SetData()
        {
            _essentialScetion.SetData(ClueStaticData.GetCluesByType(Models.Story.ClueType.Essential));
            _baseScetion.SetData(ClueStaticData.GetCluesByType(Models.Story.ClueType.Base));
            _tmiScetion.SetData(ClueStaticData.GetCluesByType(Models.Story.ClueType.TMI));
        }

        private void ShowDetails(string id)
        {
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
