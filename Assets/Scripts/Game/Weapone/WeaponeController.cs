using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Game.Weapone
{
    public class WeaponeController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigid;
        [SerializeField]
        private BoxCollider2D _collider;
        [SerializeField]
        private WeaponeObject _weapone;
        [SerializeField]
        private SpriteRenderer _renderer;
        private WaitForSeconds _bulletAlive = new WaitForSeconds(2f);
        private Coroutine _moving;

        public float GetPower => _weapone.GetPower;

        public void Init()
        {
            gameObject.SetActive(false);
        }

        public void Spawn(Vector2 position, Vector2 look)
        {
            if (_moving != null)
            {
                StopCoroutine(_moving);
            }
            gameObject.SetActive(true);
            _collider.enabled = true;
            _rigid.velocity = Vector2.zero;
            _renderer.color = new Color(1, 1, 1, 1);
            transform.position = position;

            _rigid.AddForce((look - (Vector2)transform.position).normalized * 20 * _weapone.GetSpeed, ForceMode2D.Force);
            _moving = StartCoroutine(MovingCoroutine());
        }

        public void Destroy()
        {
            if (_moving != null)
            {
                StopCoroutine(_moving);
            }
            gameObject.SetActive(false);
        }

        private IEnumerator MovingCoroutine()
        {
            yield return _bulletAlive;
            _collider.enabled = false;
            _renderer.DOFade(0, 0.2f).From(1).OnComplete(() => gameObject.SetActive(false));
        }
    }
}
