using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerMove _move;

        public Transform PlayerObject => _move.transform;

        public void Init()
        {
            _move.Init();
        }

        public void Move(InputAction.CallbackContext callback)
        {
            _move.MoveDirection = callback.ReadValue<Vector2>();
        }

        public void Look(InputAction.CallbackContext callback)
        {
            _move.LookDirection = callback.ReadValue<Vector2>();
        }

        /// <summary>
        /// Auto Shooting by weapone settings
        /// </summary>
        public void Shoot()
        {
            // Shooter list의 모든 슈팅 제어
        }
    }
}
