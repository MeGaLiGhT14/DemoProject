using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    [SerializeField] private PlatformSpawner _platformSpawner;

    public void GetPlatformSpawner(PlatformSpawner platformSpawner)
    {
        _platformSpawner = platformSpawner;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovePlayer>())
            _platformSpawner.RecreatePlatform();
    }
}