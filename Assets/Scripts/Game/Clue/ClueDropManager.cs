using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ClueDropManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _prefab;
        private List<ClueObject> _clueObjects;

        public void Init()
        {
            _clueObjects = new List<ClueObject>();
            AddPool(20);
        }

        public ClueObject GetClue()
        {
            var clue = _clueObjects.Find(x => !x.gameObject.activeSelf);
            if (clue == null)
            {
                AddPool(20);
                clue = _clueObjects.Find(x => !x.gameObject.activeSelf);
            }
            return clue;
        }

        private void AddPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var go = Instantiate(_prefab, gameObject.transform).GetComponent<ClueObject>();
                go.Init();
                _clueObjects.Add(go);
            }
        }
    }
}
