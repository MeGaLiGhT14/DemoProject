using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject _barrierPrefab;

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
        Vector3 platformPosition = _counterOfCreatoedPlatform * Vector3.right * 50;
        GameObject platform = Instantiate(_platformPrefab , platformPosition , Quaternion.identity , transform);

        if (_counterOfCreatoedPlatform > 0)
            for (int i = 0; i < 5; i++)
                CreateInteraction(platformPosition +  Vector3.right * (-20 + i * 10) , platform);

        _platforms.Add(platform);
        _counterOfCreatoedPlatform++;
    }

    private void CreateInteraction(Vector3 position , GameObject platform)
    {
        int random = Random.Range(0 , 3);

        if(random == 1)
        {
            GameObject coin = Instantiate(_coinPrefab , position + Vector3.up * 2 , Quaternion.identity , platform.transform);
            coin.transform.localScale = new Vector3(0.01f , 0.5f , 0.5f);
        }
        else if (random == 2)
        {
            GameObject barrier = Instantiate(_barrierPrefab , position + Vector3.up , Quaternion.identity , platform.transform);
            barrier.transform.localScale = new Vector3(0.02f , 1 , 1);
        }
    }
}