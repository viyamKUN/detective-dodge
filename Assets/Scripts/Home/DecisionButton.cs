using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Home
{
    public class DecisionButton : MonoBehaviour
    {
        [SerializeField]
        private DefaultUI.ButtonAnimator _buttonAnimator;
        public void Init()
        {
            _buttonAnimator.Init(Click);
        }

        private void Click()
        {

        }
    }
}
