using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private EnemyObjectPool _objectPool;

        public void SpawnEnemies(string shape, List<(int id, int count)> enemies)
        {
            Debug.Log($"Spawn Shape: {shape}  Enemies kind Count: {enemies.Count}");
        }
    }
}
