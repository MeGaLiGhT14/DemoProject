using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    public void ReachingEdge()
    {
        transform.parent.GetComponent<PlatformSpawner>().TranspositionPlatform();
    }
}