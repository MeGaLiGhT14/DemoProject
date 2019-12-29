using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _movementForce;

    private Rigidbody _rigidbody;

    private void OnValidate()
    {
        if (_movementForce < 0)
            _movementForce = 0;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(Vector3.right * _movementForce * Time.deltaTime, ForceMode.Force);
    }
}