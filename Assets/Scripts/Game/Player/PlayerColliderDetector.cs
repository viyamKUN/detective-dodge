using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerColliderDetector : MonoBehaviour
    {
        [SerializeField]
        private PlayerController _controller;

        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (other.tag)
            {
                case "Enemy":
                    var enemy = other.GetComponent<Game.Enemy.EnemyController>();
                    _controller.Hit(enemy.GetAttackPower());
                    break;
            }
        }
    }
}
