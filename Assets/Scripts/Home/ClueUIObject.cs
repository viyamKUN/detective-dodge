using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Home
{
    using StaticData;
    public class ClueUIObject : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private Image _lock;
        [SerializeField]
        private TextMeshProUGUI _name;
        private string _id;
        private System.Action<string> _clickAction;

        public void Init(System.Action<string> clickAction)
        {
            _clickAction = clickAction;
        }

        public void SetClue(string id)
        {
            _id = id;
            _lock.gameObject.SetActive(false);
            _name.gameObject.SetActive(true);
            _name.text = ClueStaticData.GetClue(id).Name;
            _button.enabled = true;
        }

        public void LockClue()
        {
            _lock.gameObject.SetActive(true);
            _name.gameObject.SetActive(false);
            _button.enabled = false;
        }

        public void Click()
        {
            _clickAction(_id);
        }
    }
}
