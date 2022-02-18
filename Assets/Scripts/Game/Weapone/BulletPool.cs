using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapone
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField]
        private GameObject _prefab;
        private List<WeaponeController> _weaponeControllers;

        public void Init()
        {
            _weaponeControllers = new List<WeaponeController>();
            AddPool(20);
        }

        public WeaponeController GetBullet()
        {
            var bullet = _weaponeControllers.Find(x => !x.gameObject.activeSelf);
            if (bullet == null)
            {
                AddPool(20);
                bullet = _weaponeControllers.Find(x => !x.gameObject.activeSelf);
            }
            return bullet;
        }

        private void AddPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var go = Instantiate(_prefab, gameObject.transform).GetComponent<WeaponeController>();
                go.Init();
                _weaponeControllers.Add(go);
            }
        }
    }
}
