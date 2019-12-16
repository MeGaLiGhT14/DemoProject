using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purse : MonoBehaviour
{
    private int _numberCoins = 0;

    public void AddCoin()
    {
        _numberCoins++;
    }
}