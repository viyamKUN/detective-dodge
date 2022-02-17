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

        private void Awake()
        {
            _uiManager.Init();
        }
    }
}
