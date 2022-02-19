using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _renderer;
        [SerializeField]
        private Rigidbody2D _rigid;
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private Game.Weapone.BulletPool _bulletPool;

        public Vector2 MoveDirection { get; set; }
        public Vector2 LookDirection { get; set; }
        private PlayerConfig _config;
        private WaitForSeconds _fireDelay = new WaitForSeconds(0.5f);
        private Vector2 _pistolMargin = new Vector2(0.1f, 0);
        private Coroutine _fireCoroutine;
        private bool _isDead;

        public void Init(PlayerConfig config)
        {
            _config = config;
            MoveDirection = Vector2.zero;
            LookDirection = Vector2.zero;
            _isDead = false;
            _bulletPool.Init();
        }

        public void StartFire()
        {
            _fireCoroutine = StartCoroutine(FireCoroutine());
        }

        public void Dead()
        {
            if (_fireCoroutine != null)
            {
                StopCoroutine(_fireCoroutine);
            }
            _isDead = true;
        }

        private void FixedUpdate()
        {
            if (_isDead) return;
            Vector2 direction = MoveDirection * _config.MoveSpeed * Time.deltaTime * 0.1f;
            _rigid.MovePosition((Vector2)transform.position + direction);
            _animator.speed = direction.Equals(Vector2.zero) ? 0 : 1;
            if (direction.Equals(Vector2.zero))
            {
                return;
            }
            _renderer.flipX = direction.x > 0;
        }

        private void Fire()
        {
            Vector2 pistolPos = (Vector2)transform.position + _pistolMargin * (_renderer.flipX ? 1 : -1);
            LookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _bulletPool.GetBullet().Spawn(pistolPos, LookDirection);
            DefaultSystem.EffectSoundSystem.GetInstance?.PlayEffect("bullet");
        }

        private IEnumerator FireCoroutine()
        {
            for (; ; )
            {
                yield return _fireDelay;
                Fire();
            }
        }
    }
}
