using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Title
{
    using DefaultUI;
    public class TitleManager : MonoBehaviour
    {
        [SerializeField]
        private SceneLoader _loader;
        [SerializeField]
        private OptionManager _option;

        private void Start()
        {
            DG.Tweening.DOTween.Init(true, true, DG.Tweening.LogBehaviour.Default);
        }

        /// <summary>
        /// 홈 화면으로 이동합니다.
        /// </summary>
        public void EnterHomeScene()
        {
            _loader.Load(SceneName.Home);
        }

        /// <summary>
        /// 설정창을 켭니다.
        /// </summary>
        public void OpenOption()
        {
            _option.Open();
        }
    }
}
