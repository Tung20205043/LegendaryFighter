using System;
using UnityEngine;

public class EnemyTakeDamage : CharacterDashEffect
{
    [SerializeField] CharacterAnimator characterAnimator;
    [SerializeField] RaycastCheck raycastCheck;
    [SerializeField] GameObject playObj;
    public override void Start() {
        base.Start();
        playObj = GameObjectManager.Instance.PlayerObject();
        raycastCheck = playObj.GetComponent<RaycastCheck>();
        raycastCheck.takeDmgEvent.AddListener(DoTakeDamage);
    }
    

    public void DoTakeDamage(TakeDamageType type) {
        if (characterAnimator.currentAnimationState == AnimationState.Die) return;
        if (type == TakeDamageType.Type1 || type == TakeDamageType.Type2 || type == TakeDamageType.Type3) {
            CharacterStats.Instance.ChangeCurrentMana(Character.Player, +2);
        }


        characterAnimator.SetTakeDamage(type);
        if (GameManager.Instance.GameMode != GameMode.Train) {
            CharacterStats.Instance.TakeDamage(Character.Enemy, CharacterStats.Instance.PlayerAtk);
        }
        if (type == TakeDamageType.Type3) {
            Dash();
            SpecialUnityEvent.Instance.setActiveHeavyPunchButton?.Invoke();
        }
        if (type == TakeDamageType.HeavySkill) {
            Dash();
        }
    }
    public override void SpawnGhostEffect(bool toTheLeft) {
        Transform enemy = GameObjectManager.Instance.EnemyObject().transform;
        ObjectPoolingForEnemy.ObjectToSpawn obj = !toTheLeft ? ObjectPoolingForEnemy.ObjectToSpawn.TakeDamageGhost1 :
           ObjectPoolingForEnemy.ObjectToSpawn.TakeDamageGhost;
        ObjectPoolingForEnemy.Instance.SpawnObject(obj, enemy.position, enemy.rotation);
    }
}
