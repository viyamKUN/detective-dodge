using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

namespace Story
{
    public class DialogSetter : MonoBehaviour
    {
        [SerializeField]
        private float _dialogShowingSpeed;
        [SerializeField]
        private TextMeshProUGUI _name;
        [SerializeField]
        private TextMeshProUGUI _dialog;
        private object _dialogAnimation;

        public void SetDialog(string name, string dialog)
        {
            _name.text = name;
            dialog = dialog.Replace("{n}", DefaultSystem.PlayerSaveData.GetPlayer.Name);
            float duration = dialog.Length * 0.1f / _dialogShowingSpeed;
            _dialogAnimation = _dialog.DOText(dialog, duration).From("").target;
        }

        public bool IsAnimationPlaying()
        {
            if (_dialogAnimation == null)
            {
                return false;
            }
            return DOTween.IsTweening(_dialogAnimation);
        }

        public void ForceCompleteAnimation()
        {
            if (_dialogAnimation == null)
            {
                return;
            }
            DOTween.Kill(_dialogAnimation, true);
        }
    }
}
