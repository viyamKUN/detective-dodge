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
        private Image _lock;
        [SerializeField]
        private TextMeshProUGUI _name;
        private string _id;

        public void SetClue(string id)
        {
            _id = id;
            _lock.gameObject.SetActive(false);
            _name.gameObject.SetActive(true);
            _name.text = ClueStaticData.GetClue(id).Name;
        }

        public void LockClue()
        {
            _lock.gameObject.SetActive(true);
            _name.gameObject.SetActive(false);
        }
    }
}
