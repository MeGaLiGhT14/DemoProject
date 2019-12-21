using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _movementForce;
    [SerializeField] private float _jumpEnergy;

    private Rigidbody rigidbody;

    #region MonoBehaviour

    private void OnValidate()
    {
        if (_movementForce < 0)
            _movementForce = 0;

        if (_jumpEnergy < 0)
            _jumpEnergy = 0;
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(Vector3.right * _movementForce * Time.deltaTime , ForceMode.Force);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * _jumpEnergy , ForceMode.Impulse);
        }
    }

    #endregion
}