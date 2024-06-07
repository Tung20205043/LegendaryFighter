using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviourSingletonPersistent<CurrencyManager> 
{
    private int currentCoin;
    public int CurrentCoin => currentCoin;
    public int plusCoin;

    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private float timeChangeValue;
    private void Start() {
        SpecialUnityEvent.Instance.endCoinRoad.AddListener(IncrementValue);
    }
    private void OnEnable() {
        currentCoin = 0;
    }

    private void Update()
    {
        coinText.fontSize = currentCoin switch
        {
            >= 1000000 => 18f,
            >= 100000 and < 1000000 => 24f,
            >= 10000 and < 100000 => 26f,
            > 1000 and < 10000 => 30f,
            _ => 32f
        };
        coinText.text = GameUltis.FormatNumber(currentCoin);
    }
    void IncrementValue() {
        int targetValue = currentCoin + plusCoin;
        DOTween.To(() => currentCoin, x => currentCoin = x, targetValue, timeChangeValue);
    }
    public void ChangeCoin(int value) { 
        currentCoin += value;
    }
}
