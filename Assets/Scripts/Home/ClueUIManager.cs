using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        public void Init()
        {
            _essentialScetion.Init();
            _baseScetion.Init();
            _tmiScetion.Init();
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
    }
}
