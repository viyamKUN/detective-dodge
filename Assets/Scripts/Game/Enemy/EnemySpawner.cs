using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private EnemyObjectPool _objectPool;

        public void Init()
        {
            _objectPool.Init();
        }

        public void SpawnEnemies(string shape, List<(int id, int count)> enemies)
        {
            if (shape.Equals("Circle"))
            {
                Debug.Log("Spawn Circle");
            }
            else if (shape.Contains("Clock"))
            {
                int timePin = int.Parse(shape.Replace("Clock", ""));
                Debug.Log("Spawn Clock Side : " + timePin);
            }
        }
    }
}
