using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Home
{
    using DefaultUI;
    using DefaultSystem;

    public class HomeManager : MonoBehaviour
    {
        [SerializeField]
        private SceneLoader _loader;
        [SerializeField]
        private StoriesButtonsManager _storyButtonsManager;
        [SerializeField]
        private UpperUIManager _upperUIManager;

        private void Awake()
        {
            // 스토리 데이터 리딩 (한 번만)
            if (!PlayerSaveData.Load())
            {
                // 이름 입력 이벤트 출력
                EnterPlayerName("김호걸");
            }
            // 진행도 표시
            _storyButtonsManager.Init();
            _upperUIManager.SetUI(PlayerSaveData.GetPlayer.Name, PlayerSaveData.GetPlayer.EXP);
            DOTween.Init(true, true, LogBehaviour.Default);
        }

        public void EnterPlayerName(string name)
        {
            int storyCount = 7;
            PlayerSaveData.Init(name, storyCount);
        }

        /// <summary>
        /// 게임 시작 버튼을 통해서 입력받습니다.
        /// </summary>
        public void GameStart()
        {
            _loader.Load(SceneName.Game);
        }
    }
}
