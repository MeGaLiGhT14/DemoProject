using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionSpawner))]
public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;

    [SerializeField] private GameObject _startPlatform;

    private List<GameObject> _platforms = new List<GameObject>();
    private int _counterOfCreatoedPlatform = 1;

    private InteractionSpawner interactionSpawner;

    #region MonoBehaviour

    private void OnValidate()
    {
        if (!_platformPrefab.CompareTag("Platform"))
            _platformPrefab = null;

        if (!_startPlatform.CompareTag("Platform"))
            _startPlatform = null;
        else
            _platforms.Add(_startPlatform);
    }

    private void Start()
    {
        interactionSpawner = GetComponent<InteractionSpawner>();

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

            for (int i = 0; i < 9; i++)
                interactionSpawner.CreateInteraction(platformPosition + Vector3.right * (-20 + i * 5) , platform);

        _platforms.Add(platform);
        _counterOfCreatoedPlatform++;
    }
}