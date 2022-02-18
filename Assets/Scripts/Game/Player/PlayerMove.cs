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

        public Vector2 MoveDirection { get; set; }
        public Vector2 LookDirection { get; set; }
        private PlayerConfig _config;

        public void Init(PlayerConfig config)
        {
            _config = config;
            MoveDirection = Vector2.zero;
            LookDirection = Vector2.zero;
        }

        private void FixedUpdate()
        {
            Vector2 direction = MoveDirection * _config.MoveSpeed * Time.deltaTime * 0.1f;
            _rigid.MovePosition((Vector2)transform.position + direction);
            _animator.speed = direction.Equals(Vector2.zero) ? 0 : 1;
            if (direction.Equals(Vector2.zero))
            {
                return;
            }
            _renderer.flipX = direction.x > 0;
        }
    }
}
