using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private void Update()
    {
        transform.position = _player.transform.position + new Vector3(0 , 2 , -10);
    }
}