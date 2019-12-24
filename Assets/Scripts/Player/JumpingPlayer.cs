using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class JumpingPlayer : MonoBehaviour
{
    [SerializeField] private float _jumpEnergy;

    private Rigidbody rigidbody;

    #region MonoBehaviour

    private void OnValidate()
    {
        if (_jumpEnergy < 0)
            _jumpEnergy = 0;
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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