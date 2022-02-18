using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    private Vector3 _margin = new Vector3(0, 0, -10);

    private void LateUpdate()
    {
        transform.position = _player.transform.position + _margin;
    }
}
