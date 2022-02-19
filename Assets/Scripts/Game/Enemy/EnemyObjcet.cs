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
        public int GetID => _id;
        public float GetSpeed => EnemyStaticData.GetSpeed(_id);
        public float GetPower => EnemyStaticData.GetPower(_id);
        public int GetHP => EnemyStaticData.GetHP(_id);
        public float GetEXP => EnemyStaticData.GetEXP(_id);
    }
}
