using UnityEngine;
using DG.Tweening;

namespace Home
{
    using DefaultUI;
    using DefaultSystem;
    using StaticData;

    public class HomeManager : MonoBehaviour
    {
        [SerializeField]
        private SceneLoader _loader;
        [SerializeField]
        private StoriesButtonsManager _storyButtonsManager;
        [SerializeField]
        private UpperUIManager _upperUIManager;
        [SerializeField]
        private ClueUIManager _clueUIManager;

        private void Awake()
        {
            StoryStaticData.ReadData();
            ClueStaticData.ReadData();

            if (!PlayerSaveData.Load())
            {
                // 이름 입력 이벤트 출력
                EnterPlayerName("김호걸");
            }
            // 진행도 표시
            _storyButtonsManager.Init();
            _upperUIManager.SetUI(PlayerSaveData.GetPlayer.Name, PlayerSaveData.GetPlayer.EXP);
            DOTween.Init(true, true, LogBehaviour.Default);
            _clueUIManager.Init();
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

        public void StoryStart()
        {
            _loader.Load(SceneName.Story);
        }

        public void ClueUIOpen()
        {
            _clueUIManager.Open();
        }
    }
}
