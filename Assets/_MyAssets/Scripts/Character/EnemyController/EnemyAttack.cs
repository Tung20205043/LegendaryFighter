
using UnityEngine;

public class EnemyAttack : PlayerAttack
{
    [SerializeField] private PunchComboAI punchComboAI;
    private void OnEnable() {
        StartComboTypeA();
    }
    public void StartComboTypeA() {
        punchComboAI.Attack();
    }
}
