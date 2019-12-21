using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Purse : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _numberCoins = 0;

    #region MonoBehaviour

    private void Start()
    {
        SetNumberCoins();
    }

    #endregion

    public void AddCoin()
    {
        _numberCoins++;

        SetNumberCoins();
    }

    private void SetNumberCoins()
    {
        _text.text = _numberCoins.ToString();
    }
}