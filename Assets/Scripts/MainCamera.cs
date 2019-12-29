using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] Transform _player;

    [SerializeField] Vector3 _distance;

    private void Update()
    {
        transform.position = _player.position + _distance;
    }
}