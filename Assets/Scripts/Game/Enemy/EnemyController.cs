using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private EnemyObjcet _enemy;
        [SerializeField]
        private Rigidbody2D _rigid;
        private Transform _target;
        private Enums.UnitState _state = Enums.UnitState.Dead;

        private void FixedUpdate()
        {
            if (_state.Equals(Enums.UnitState.Dead))
            {
                return;
            }
            Move();
        }

        public void Init()
        {
            _state = Enums.UnitState.Dead;
            this.gameObject.SetActive(false);
        }

        public void Spawn()
        {
            _state = Enums.UnitState.Alive;
            _target = GameManager.GetInstance.PlayerPos;
            gameObject.SetActive(true);
        }

        public void Move()
        {
            Vector2 direction = ((Vector2)_target.position - (Vector2)transform.position).normalized;
            var moveAmount = direction * _enemy.GetSpeed * Time.deltaTime * 0.1f;
            _rigid.MovePosition((Vector2)transform.position + moveAmount);
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
