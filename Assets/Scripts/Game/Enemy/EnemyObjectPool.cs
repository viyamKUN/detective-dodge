using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyObjectPool : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _enemyPrefabs;
        private List<List<EnemyController>> _pools;
        private readonly int minimumCount = 20;

        public void Init()
        {
            _pools = new List<List<EnemyController>>();
            int index = 0;
            foreach (var prefab in _enemyPrefabs)
            {
                _pools.Add(new List<EnemyController>());
                for (int i = 0; i < minimumCount; i++)
                {
                    var go = Instantiate(prefab, gameObject.transform).GetComponent<EnemyController>();
                    go.Init();
                    _pools[index].Add(go);
                }
                index++;
            }
        }
    }
}
