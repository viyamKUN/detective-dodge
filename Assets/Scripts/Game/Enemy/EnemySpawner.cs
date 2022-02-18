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

        public void SpawnWaveContents(string shape, List<(int id, int count)> enemies)
        {
            if (shape.Equals("Circle"))
            {
                var positions = GetPositionsPool(shape);
                enemies.ForEach(x => SpawnEnemies(x.id, x.count, positions));

                Debug.Log("Spawn Circle");
            }
            else if (shape.Contains("Clock"))
            {
                int timePin = int.Parse(shape.Replace("Clock", ""));
                var positions = GetPositionsPool("Clock", timePin);
                enemies.ForEach(x => SpawnEnemies(x.id, x.count, positions));

                Debug.Log("Spawn Clock Side : " + timePin);
            }
        }

        private void SpawnEnemies(int id, int count, List<Vector2> positions)
        {
            _objectPool.Spawn(id, count, positions);
        }

        private List<Vector2> GetPositionsPool(string shape, int timePin = 0)
        {
            List<Vector2> positions = new List<Vector2>();
            switch (shape)
            {
                case "Circle":
                    positions.Add(new Vector2(1, 1));
                    positions.Add(new Vector2(1, -1));
                    positions.Add(new Vector2(-1, 1));
                    positions.Add(new Vector2(-1, -1));
                    break;
                case "Clock":
                    positions.Add(new Vector2(0, 3));
                    break;
            }
            return positions;
        }
    }
}
