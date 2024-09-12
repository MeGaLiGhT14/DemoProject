using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    [SerializeField] private PlatformSpawner _platformSpawner;

    public void SetPlatformSpawner(PlatformSpawner platformSpawner)
    {
        _platformSpawner = platformSpawner;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
            _platformSpawner.RecreatePlatform();
    }
}