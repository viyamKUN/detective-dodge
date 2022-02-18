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
        private GameUIManager _uiManager;
        [SerializeField]
        private Player.PlayerController _controller;
        private static GameManager _instance;
        public static GameManager GetInstance => _instance;
        public Transform PlayerPos => _controller.PlayerObject;

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
            EnemyStaticData.ReadData();
            _uiManager.Init();
            _controller.Init();
        }
    }
}