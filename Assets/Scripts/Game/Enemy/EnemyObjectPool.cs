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
                AddPool(index, prefab, minimumCount);
                index++;
            }
        }

        public void Spawn(int id, int count, List<Vector2> positions)
        {
            while (_pools[id].FindAll(x => !x.gameObject.activeSelf).Count < count)
            {
                AddPool(id, _enemyPrefabs[id], minimumCount);
            }

            int i = 0;
            int remain = count;
            while (remain > 0)
            {
                if (_pools[id][i].gameObject.activeSelf)
                {
                    i++;
                    continue;
                }
                remain--;
                var randomPos = positions[Random.Range(0, positions.Count)];
                _pools[id][i].Spawn(randomPos);
            }
        }

        private void AddPool(int index, GameObject prefab, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var go = Instantiate(prefab, gameObject.transform).GetComponent<EnemyController>();
                go.Init();
                _pools[index].Add(go);
            }
        }
    }
}
