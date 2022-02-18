using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private EnemyObjectPool _objectPool;
        private List<Vector2> _circlePositions = new List<Vector2>()
        {
            new Vector2(4, 3), new Vector2(4, -3), new Vector2(-4, 3), new Vector2(-4, -3),
            new Vector2(3, 4), new Vector2(3, -4), new Vector2(-3, 4),new Vector2(-3, -4)
        };

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
            switch (shape)
            {
                case "Circle":
                    return _circlePositions;
                case "Clock":
                    List<Vector2> positions = new List<Vector2>();
                    float angle = (3 - timePin) * 30;
                    float x = Mathf.Cos(angle * Mathf.PI / 180.0f) * 5;
                    float y = Mathf.Sin(angle * Mathf.PI / 180.0f) * 5;
                    positions.Add(new Vector2(x, y));
                    return positions;
            }
            return new List<Vector2>() { Vector2.one };
        }
    }
}
