using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyObjectPool : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _enemyPrefabs;
    }
}
