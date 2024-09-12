using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionSpawner))]
public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private GameObject _startPlatform;

    private List<GameObject> _platforms = new List<GameObject>();
    private int _createdPlatforms = 1;

    private float _platformSize;

    [SerializeField] private InteractionSpawner _interactionSpawner;

    private void OnValidate()
    {
        if (_platformPrefab.GetComponent<Platform>())
        {
            _platformSize = _platformPrefab.transform.localScale.x;
        }
        else
        {
            _platformPrefab = null;
            _platformSize = 0;
        }

        if (_startPlatform.GetComponent<Platform>() != null)
            _platforms.Add(_startPlatform);
        else
            _startPlatform = null;
    }

    private void Start()
    {
        CreatePlatform();
    }

    public void RecreatePlatform()
    {
        CreatePlatform();

        if (_platforms.Count > 3)
        {
            Destroy(_platforms[0].gameObject);
            _platforms.RemoveAt(0);
        }
    }

    private void CreatePlatform()
    {
        Vector3 platformPosition = _createdPlatforms * Vector3.right * _platformSize;
        GameObject platform = Instantiate(_platformPrefab, platformPosition, Quaternion.identity, transform);
        platform.GetComponent<Platform>().SetPlatformSpawner(GetComponent<PlatformSpawner>());

        _interactionSpawner.CreateInteractionsOnPlatform(platform);

        _platforms.Add(platform);
        _createdPlatforms++;
    }
}