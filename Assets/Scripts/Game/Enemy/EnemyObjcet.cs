using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    using Data.StaticData.Enemy;
    public class EnemyObjcet : MonoBehaviour
    {
        [SerializeField]
        private int _id;
        public float GetSpeed => EnemyStaticData.GetSpeed(_id);
    }
}
