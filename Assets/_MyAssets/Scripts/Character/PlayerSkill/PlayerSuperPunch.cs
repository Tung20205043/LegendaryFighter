using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuperPunch : CharacterDashEffect
{
    [SerializeField] CharacterAnimator characterAnimator;
    private void Update() {
        if (GameObjectManager.Instance.DistanceBetweenEnemyPlayer() <= 0.3f &&
            characterAnimator.currentAnimationState == AnimationState.Attack &&
            characterAnimator.currentAttackType == AttackType.SuperPunch) {
            StopDash();
            SpecialUnityEvent.Instance.doComboPunch?.Invoke();
        }
    }
    public void DoSuperPunch() {
        Dash();
    }
    public override void SpawnGhostEffect(bool toTheLeft) {
        Transform player = GameObjectManager.Instance.PlayerObject().transform;
        ObjectPoolingForCharacter.ObjectToSpawn obj = !toTheLeft ? ObjectPoolingForCharacter.ObjectToSpawn.PunchGhost :
           ObjectPoolingForCharacter.ObjectToSpawn.PunchGhost1;
        ObjectPoolingForCharacter.Instance.SpawnObject(obj, player.position, player.rotation);
    }
}
