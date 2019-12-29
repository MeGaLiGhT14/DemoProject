using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Purse : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _coins = 0;

    private void Start()
    {
        SetNumberCoins();
    }

    public void AddCoin()
    {
        _coins++;

        SetNumberCoins();
    }

    private void SetNumberCoins()
    {
        _text.text = _coins.ToString();
    }
}