using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Game.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private EnemyObjcet _enemy;
        [SerializeField]
        private Rigidbody2D _rigid;
        [SerializeField]
        private SpriteRenderer _renderer;
        private Transform _target;
        private Enums.UnitState _state = Enums.UnitState.Dead;
        private int _hp;

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
            _hp = _enemy.GetHP;
            this.gameObject.SetActive(false);
        }

        public void Spawn(Vector2 position)
        {
            _state = Enums.UnitState.Alive;
            _target = GameManager.GetInstance.PlayerPos;
            _renderer.color = new Color(1, 1, 1, 1);
            gameObject.transform.position = (Vector2)_target.position + position + Random.insideUnitCircle * 1;
            gameObject.SetActive(true);
        }

        public void Move()
        {
            Vector2 direction = ((Vector2)_target.position - (Vector2)transform.position).normalized;
            var moveAmount = direction * _enemy.GetSpeed * Time.deltaTime * 0.1f;
            _rigid.MovePosition((Vector2)transform.position + moveAmount);
        }

        public void Hit(float power)
        {
            _renderer.DOFade(0.5f, 0.2f).From(1).SetLoops(1, LoopType.Yoyo);
            _hp -= (int)power;
            if (_hp <= 0)
            {
                Dead();
            }
        }

        public void Dead()
        {
            _state = Enums.UnitState.Dead;
            GameManager.GetInstance.DropClue(_enemy.GetID, transform.position);
            gameObject.SetActive(false);
        }

        public float GetAttackPower()
        {
            return _enemy.GetPower * 10;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (other.tag)
            {
                case "Weapone":
                    var weapone = other.GetComponent<Weapone.WeaponeController>();
                    Hit(weapone.GetPower);
                    weapone.Destroy();
                    break;
            }
        }
    }
}
