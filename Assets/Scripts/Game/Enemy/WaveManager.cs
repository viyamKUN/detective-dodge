using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    using Data.StaticData.Enemy;
    using Models.Enemy;

    public class WaveManager : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawner _spawner;
        private Wave _currentWave;
        private int _currentLevel;
        private int _spawnCount;
        private WaitForSeconds _waveCallDelay = new WaitForSeconds(3);
        private Coroutine _waveCoroutine;

        public void Init()
        {
            _spawner.Init();
        }

        public void StartWave()
        {
            _currentLevel = 0;
            _spawnCount = 0;
            UpdateWave();
            _waveCoroutine = StartCoroutine(WaveCall());
        }

        public void StopWave()
        {
            if (_waveCoroutine == null) return;
            StopCoroutine(_waveCoroutine);
        }

        public void UpdateWaveLevel(float playTime)
        {
            _currentLevel = (int)playTime / 100;
        }

        private IEnumerator WaveCall()
        {
            for (; ; )
            {
                SpawnWave();
                yield return _waveCallDelay;
            }
        }

        /// <summary>
        /// 일정 간격으로 웨이브를 호출해주세요.
        /// </summary>
        private void SpawnWave()
        {
            if (_spawnCount == _currentWave.Times)
            {
                UpdateWave();
            }
            _spawner.SpawnEnemies(_currentWave.Shape, _currentWave.Enemies);
            _spawnCount++;
        }

        private void UpdateWave()
        {
            _currentWave = WaveStaticData.GetRandomWave(level: _currentLevel);
            _spawnCount = 0;
        }
    }
}
