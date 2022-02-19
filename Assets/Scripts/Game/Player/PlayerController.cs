using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;
        [SerializeField]
        private PlayerMove _move;
        private PlayerConfig _config;
        private int _hp;
        private float _exp;

        public Transform PlayerObject => _move.transform;

        public void Init()
        {
            _config = new PlayerConfig();
            _move.Init(_config);
            _hp = _config.MaxHP;
            _exp = _config.EXP;
            UpdateUI();
        }

        public void Move(InputAction.CallbackContext callback)
        {
            _move.MoveDirection = callback.ReadValue<Vector2>();
        }

        public void Hit(float rawDamage)
        {
            _hp -= (int)rawDamage;
            if (_hp <= 0)
            {
                _hp = 0;
                Dead();
            }
            UpdateUI();
        }

        public void StartFire()
        {
            _move.StartFire();
        }

        public void KillEnemy(float earnEXP)
        {
            _exp += earnEXP;
            DefaultSystem.PlayerSaveData.GetPlayer.EXP = _exp;
            UpdateUI();
        }

        private void Dead()
        {
            _gameManager.GameOver();
            _move.Dead();
        }

        private void UpdateUI()
        {
            _gameManager.UpdateUI(_hp / (float)_config.MaxHP, _exp);
        }
    }
}
