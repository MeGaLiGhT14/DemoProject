using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;

    private List<GameObject> _platforms = new List<GameObject>();

    private int _counterOfCreatoedPlatform = 0;

    #region MonoBehaviour

    private void OnValidate()
    {
        if (!_platformPrefab.CompareTag("Platform"))
            _platformPrefab = null;
    }

    private void Start()
    {
        CreatePlatform();
        CreatePlatform();
    }

    #endregion

    public void TranspositionPlatform()
    {
        CreatePlatform();

        if (_counterOfCreatoedPlatform > 3)
        {
            Destroy(_platforms[0].gameObject);
            _platforms.RemoveAt(0);
        }
    }

    private void CreatePlatform()
    {
        _platforms.Add(Instantiate(_platformPrefab , _counterOfCreatoedPlatform * Vector3.right * 50 ,
                                                                                Quaternion.identity , transform));

        _counterOfCreatoedPlatform++;
    }
}