using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviourSingletonPersistent<CurrencyManager> 
{
    private int currentCoin;
    public int CurrentCoin => currentCoin;
    private void Start() {
        currentCoin = 0;
    }
    public void ChangeCoin(int value) { 
        currentCoin += value;
    }
    public void IncrementValue(int plusCoin, float  timeChangeValue) {
        int targetValue = currentCoin + plusCoin;
        DOTween.To(() => currentCoin, x => currentCoin = x, targetValue, timeChangeValue);
    }
}