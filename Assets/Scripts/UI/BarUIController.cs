using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarUIController : MonoBehaviour
{
    [SerializeField] Image playerHealth;
    [SerializeField] Image playerMana;
    [SerializeField] Image enemyHealth;
    [SerializeField] Image enemyMana;
    private void Update() {
        UpdateStatusBar(playerHealth, CharacterStats.Instance.PlayerHp, CharacterStats.Instance.maxPlayerHp);
        UpdateStatusBar(playerMana, CharacterStats.Instance.PlayerMana, CharacterStats.Instance.maxPlayerMana);
        UpdateStatusBar(enemyHealth, CharacterStats.Instance.EnemyHp, CharacterStats.Instance.maxEnemyHp);
        UpdateStatusBar(enemyMana, CharacterStats.Instance.EnemyMana, CharacterStats.Instance.maxEnemyMana);
    }
    private void UpdateStatusBar(Image statusBar, float currentValue, float maxValue) {
        float fillAmountRatio = currentValue / maxValue;
        statusBar.fillAmount = fillAmountRatio;
    }
}
