using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject _barrierPrefab;

    public void CreateInteraction(Vector3 position , GameObject platform)
    {
        int random = Random.Range(0 , 3);

        GameObject interaction = null;

        if (random == 1)
            interaction = _coinPrefab;
        else if (random == 2)
            interaction = _barrierPrefab;
        else
            return;

        Vector3 scaleInteraction = new Vector3(interaction.transform.localScale.x / platform.transform.localScale.x ,
                                                interaction.transform.localScale.y , interaction.transform.localScale.z);

        interaction = Instantiate(interaction , position + interaction.transform.position , 
                                                                Quaternion.identity , platform.transform);
        interaction.transform.localScale = scaleInteraction;
    }
}