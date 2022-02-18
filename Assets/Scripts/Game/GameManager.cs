using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    using DefaultUI;
    using Data.StaticData.Enemy;

    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private SceneLoader _loader;
        [SerializeField]
        private UI.GameUIManager _uiManager;
        [SerializeField]
        private Player.PlayerController _controller;
        [SerializeField]
        private Enemy.WaveManager _waveManager;
        [SerializeField]
        private ClueDropManager _clueDropManager;

        private static GameManager _instance;
        public static GameManager GetInstance => _instance;
        public Transform PlayerPos => _controller.PlayerObject;
        private List<string> _clueEarnedList = new List<string>();
        private WaitForSeconds _oneSecondWait = new WaitForSeconds(1);
        private Coroutine _timer;
        private int _playTime;
        private bool _isGameOver;

        private void Awake()
        {
            if (GameManager.GetInstance == null)
            {
                _instance = this;
            }
            else
            {
                GameObject.Destroy(this.gameObject);
            }

            Application.targetFrameRate = 60;
            DG.Tweening.DOTween.Init(true, true, DG.Tweening.LogBehaviour.Default);

            if (!DefaultSystem.PlayerSaveData.Load())
            {
                DefaultSystem.PlayerSaveData.Init("Dummy", 7);
            }
            EnemyStaticData.ReadData();
            WaveStaticData.ReadData();
            StaticData.ClueStaticData.ReadData();

            _uiManager.Init();
            _controller.Init();
            _waveManager.Init();
            _clueDropManager.Init();

            _isGameOver = false;
            _clueEarnedList = new List<string>();
        }

        private void Start()
        {
            Invoke("StartGame", 3f);
            _timer = StartCoroutine(TimeChecker());
            _controller.StartFire();
        }

        private void StartGame()
        {
            _waveManager.StartWave();
        }

        public void GameOver()
        {
            if (_isGameOver)
            {
                return;
            }
            _isGameOver = true;
            _waveManager.StopWave();
            if (_timer != null)
            {
                StopCoroutine(_timer);
            }
            _uiManager.GameOverUI();
        }

        private IEnumerator TimeChecker()
        {
            for (; ; )
            {
                yield return _oneSecondWait;
                _playTime++;
                _uiManager.SetTimer(_playTime);
                _waveManager.UpdateWaveLevel(_playTime);
            }
        }

        public void UpdateUI(float hpRatio, float expRatio)
        {
            _uiManager.SetGauges(hpRatio, expRatio);
        }

        public void GoHomeScene()
        {
            _loader.Load(SceneName.Home);
        }

        public void Retry()
        {
            _loader.Load(SceneName.Game);
        }

        public void EarnClue(string clueID)
        {
            if (_clueEarnedList.Contains(clueID))
                return;
            _clueEarnedList.Add(clueID);
        }

        public void DropClue(int enemyID, Vector2 position)
        {
            if (EnemyStaticData.DoesDropClue(enemyID))
            {
                var clueID = StaticData.ClueStaticData.GetClueIDByRarity();
                _clueDropManager.GetClue().Spawn(clueID, position);
            }
        }
    }
}
