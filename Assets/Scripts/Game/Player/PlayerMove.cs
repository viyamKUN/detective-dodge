using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigid;

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
        }
    }
}
