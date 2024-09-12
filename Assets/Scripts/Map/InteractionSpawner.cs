using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSpawner : MonoBehaviour
{
    [Header("Интерактивные объекты")]
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject _barrierPrefab;

    [Header("Количество объектов на платформе")]
    [SerializeField] private int _minInteractions;
    [SerializeField] private int _maxInteractions;

    private float _indentFromEdgePlatform = 1;

    private void OnValidate()
    {
        if (_minInteractions < 0)
            _minInteractions = 0;
        else if (_minInteractions > _maxInteractions)
            _maxInteractions = _minInteractions;

        if (_indentFromEdgePlatform < 0.5f)
            _indentFromEdgePlatform = 0.5f;
    }

    public void CreateInteractionsOnPlatform(GameObject platform)
    {
        float platformSize = platform.transform.localScale.x;

        int numberInteraction = Random.Range(_minInteractions, _maxInteractions + 1);

        Vector3 startPositionInteractionSpawner = platform.transform.position - Vector3.right * (platformSize / 2 - _indentFromEdgePlatform);
        Vector3 stepInteractionSpawner = Vector3.right * (platformSize - 2 * _indentFromEdgePlatform) / numberInteraction;

        for (int i = 0; i < numberInteraction; i++)
            CreateInteraction(startPositionInteractionSpawner + i * stepInteractionSpawner, platform);
    }

    private void CreateInteraction(Vector3 position, GameObject platform)
    {
        int random = Random.Range(0, 3);

        GameObject interaction = null;

        if (random == 1)
            interaction = _coinPrefab;
        else if (random == 2)
            interaction = _barrierPrefab;
        else
            return;

        Vector3 scaleInteraction = new Vector3(interaction.transform.localScale.x / platform.transform.localScale.x,
                                                interaction.transform.localScale.y, interaction.transform.localScale.z);

        interaction = Instantiate(interaction, position + interaction.transform.position,
                                                                Quaternion.identity, platform.transform);
        interaction.transform.localScale = scaleInteraction;
    }
}