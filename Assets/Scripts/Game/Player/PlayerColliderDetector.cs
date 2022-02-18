using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Game.Player
{
    public class PlayerColliderDetector : MonoBehaviour
    {
        [SerializeField]
        private PlayerController _controller;
        [SerializeField]
        private BoxCollider2D _collider;
        [SerializeField]
        private SpriteRenderer _sprite;
        private WaitForSeconds _safeModeTime = new WaitForSeconds(0.5f);
        private object _animation;
        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (other.tag)
            {
                case "Enemy":
                    var enemy = other.GetComponent<Game.Enemy.EnemyController>();
                    _controller.Hit(enemy.GetAttackPower());
                    StartCoroutine(SafeTime());
                    break;
            }
        }

        private IEnumerator SafeTime()
        {
            if (_animation != null && DOTween.IsTweening(_animation))
            {
                DOTween.Kill(_animation);
            }
            _collider.enabled = false;
            _animation = _sprite.DOFade(1, 0.2f).From(0).SetLoops(2, LoopType.Yoyo);
            yield return _safeModeTime;
            if (_animation != null && DOTween.IsTweening(_animation))
            {
                DOTween.Kill(_animation);
            }
            _animation = _sprite.DOFade(1, 0.1f);
            _collider.enabled = true;
        }
    }
}
