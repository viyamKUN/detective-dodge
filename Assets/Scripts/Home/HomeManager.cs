using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Home
{
    public class HomeManager : MonoBehaviour
    {
        [SerializeField]
        private StoriesButtonsManager _storyButtonsManager;

        private void Awake()
        {
            // 스토리 데이터 리딩 (한 번만)
            // 진행도 표시
            _storyButtonsManager.Init();
            DOTween.Init(true, true, LogBehaviour.Default);
        }
    }
}
