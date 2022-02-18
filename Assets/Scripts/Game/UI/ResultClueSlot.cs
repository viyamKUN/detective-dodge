using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.UI
{
    public class ResultClueSlot : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;
        private string _id;
        private System.Action<string> _clickAction;

        public void Init(System.Action<string> clickAction)
        {
            _clickAction = clickAction;
            gameObject.SetActive(false);
        }
        public void SetSlot(string clueID)
        {
            gameObject.SetActive(true);
            _text.name = StaticData.ClueStaticData.GetClue(clueID).Name;
            _id = clueID;
        }

        public void Click()
        {
            _clickAction(_id);
        }
    }
}
