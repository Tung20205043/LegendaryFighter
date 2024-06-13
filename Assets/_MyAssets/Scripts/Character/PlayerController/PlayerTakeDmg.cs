using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDmg : CharacterDashEffect
{
    [SerializeField] CharacterAnimator characterAnimator;
    public override void Start() {
        base.Start();
    }
    

    public void DoTakeDamage(TakeDamageType type) {
        if (characterAnimator.currentAnimationState == AnimationState.Die) return;
        if (type == TakeDamageType.Type1 || type == TakeDamageType.Type2 || type == TakeDamageType.Type3) {
            CharacterStats.Instance.ChangeCurrentMana(Character.Enemy, +2);
        }
        characterAnimator.SetTakeDamage(type);
        if (GameManager.Instance.GameMode != GameMode.Train) {
            CharacterStats.Instance.TakeDamage(Character.Player, CharacterStats.Instance.EnemyAtk);
        }
        if (type == TakeDamageType.Type3) {
            Dash();
        }
        if (type == TakeDamageType.HeavySkill) {
            Dash();
        }
    }
    public override void SpawnGhostEffect(bool toTheLeft) {
        var player = GameObjectManager.Instance.PlayerObject().transform;
        var obj = !toTheLeft ? ObjectPoolingForCharacter.ObjectToSpawn.TakeDamageGhost1 :
            ObjectPoolingForCharacter.ObjectToSpawn.TakeDamageGhost;
        ObjectPoolingForCharacter.Instance.SpawnObject(obj, player.position, player.rotation);
    }
}
