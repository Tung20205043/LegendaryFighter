using System;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private float timeChangeValue;

    public static int plusCoin = 100;

    private void Start()
    {
        SpecialUnityEvent.Instance.endCoinRoad.AddListener(IncrementValue);
    }

    private void Update()
    {
        coinText.fontSize = CurrencyManager.Instance.CurrentCoin switch
        {
            >= 1000000 => 18f,
            >= 100000 and < 1000000 => 24f,
            >= 10000 and < 100000 => 26f,
            > 1000 and < 10000 => 30f,
            _ => 32f
        };
        coinText.text = GameUltis.FormatNumber(CurrencyManager.Instance.CurrentCoin);
    }

    private void IncrementValue()
    {
        CurrencyManager.Instance.IncrementValue(plusCoin, timeChangeValue);
    }
}
