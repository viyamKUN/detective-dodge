using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigid;
        private Transform _target;
        private Enums.UnitState _state;

        private void FixedUpdate()
        {
            if (_state.Equals(Enums.UnitState.Dead))
            {
                return;
            }
            Move();
        }

        public void Spawn(Transform player)
        {
            _state = Enums.UnitState.Alive;
            _target = player;
            gameObject.SetActive(true);
        }

        public void Move()
        {
            // Move to target
        }

        public void Hit()
        {
            // Show Effect : 깜빡깜빡
        }

        public void Dead()
        {
            // Show Effect
            _state = Enums.UnitState.Dead;
            gameObject.SetActive(false);
        }
    }
}
