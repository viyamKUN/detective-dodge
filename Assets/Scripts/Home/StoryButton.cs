using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Home
{
    public class StoryButton : MonoBehaviour
    {
        [SerializeField]
        private DefaultUI.ButtonAnimator _buttonAnimator;

        public void Init()
        {
            _buttonAnimator.Init();
        }
    }
}
