using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Purse purse))
        {
            purse.AddCoin();
            Destroy(gameObject);
        }
    }
}