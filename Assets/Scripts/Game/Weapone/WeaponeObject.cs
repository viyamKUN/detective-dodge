using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapone
{
    public class WeaponeObject : MonoBehaviour
    {
        [SerializeField]
        private int _id;

        public float GetPower => 5.0f;
        public float GetSpeed => 3.0f;
    }
}
