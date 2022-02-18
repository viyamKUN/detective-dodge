using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ClueObject : MonoBehaviour
    {
        private string _clueID;
        public string GetClueID => _clueID;

        public void Init()
        {
            gameObject.SetActive(false);
        }

        public void Spawn(string id, Vector2 position)
        {
            transform.position = position;
            _clueID = id;
            gameObject.SetActive(true);
        }

        public void Destory()
        {
            gameObject.SetActive(false);
        }
    }
}
