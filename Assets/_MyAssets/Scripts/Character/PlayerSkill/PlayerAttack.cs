using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] SpawnSkill1 spawnSkill1;
    [SerializeField] SpawnUltSkill spawnUlt;
    public void DoSpawnSkill(AttackType type, Vector3 playerPosition) {
        switch (type) {
            case AttackType.Skill:
                spawnSkill1.DoSpawnSkill1(playerPosition);
                break;
            case AttackType.UltimateSkill:
                spawnUlt.DoSpawnUltSkill(playerPosition);
                break;
            default:
                break;
        }
    }
}
