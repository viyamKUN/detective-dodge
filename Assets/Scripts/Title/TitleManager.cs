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
        [SerializeField]
        private NameEnterManaegr _nameEnterManager;

        private void Start()
        {
            DG.Tweening.DOTween.Init(true, true, DG.Tweening.LogBehaviour.Default);
        }

        /// <summary>
        /// 홈 화면으로 이동합니다.
        /// </summary>
        public void EnterHomeScene()
        {
            if (!DefaultSystem.PlayerSaveData.Load())
            {
                _nameEnterManager.Open();
                return;
            }
            _loader.Load(SceneName.Home);
            DefaultSystem.EffectSoundSystem.GetInstance?.PlayEffect("title");
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
