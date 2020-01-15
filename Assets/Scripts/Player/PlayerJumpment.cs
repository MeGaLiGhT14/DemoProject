using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerJumpment : MonoBehaviour
{
    [SerializeField] private float _jumpEnergy;

    private Rigidbody _rigidbody;

    private bool _onPlatform = false;

    private void OnValidate()
    {
        if (_jumpEnergy < 0)
            _jumpEnergy = 0;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _onPlatform = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _onPlatform = false;
    }

    private void FixedUpdate()
    {
        if (_onPlatform && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * _jumpEnergy, ForceMode.Impulse);

            _onPlatform = false;
        }
    }
}