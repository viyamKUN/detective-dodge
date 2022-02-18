using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    using DefaultUI;

    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private SceneLoader _loader;
        [SerializeField]
        private GameUIManager _uiManager;
        [SerializeField]
        private Player.PlayerController _controller;

        private void Awake()
        {
            _uiManager.Init();
            _controller.Init();
        }
    }
}
