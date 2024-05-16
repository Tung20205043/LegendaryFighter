using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] SpawnSkill1 spawnSkill1;
    [SerializeField] SpawnUltSkill spawnUlt;
    [SerializeField] SpawnKameha spawnKameha;
    [SerializeField] PlayerTeleport playerTeleport;
    [SerializeField] PlayerHeavyPunch playerHeavyPunch;
    public void DoSpawnSkill(AttackType type, Vector3 playerPosition, Vector3 forward, Vector3 up) {
        switch (type) {
            case AttackType.Skill:
                spawnSkill1.DoSpawnSkill1(playerPosition, forward, up);
                break;
            case AttackType.UltimateSkill:
                spawnUlt.DoUltSkill(playerPosition, forward, up);
                break;
            case AttackType.Kameha:
                spawnKameha.DoSpawnKameha(playerPosition, forward, up);
                break;
            case AttackType.Teleport:
                playerTeleport.DoTeleport();
                break;
            case AttackType.HeavyPunch:
                playerHeavyPunch.DoTeleport();
                break;
            default:
                break;
        }
    }
}
