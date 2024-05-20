using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] SpawnSkill1 spawnSkill1;
    [SerializeField] SpawnUltSkill spawnUlt;
    [SerializeField] SpawnKameha spawnKameha;
    [SerializeField] PlayerTeleport playerTeleport;
    [SerializeField] PlayerHeavyPunch playerHeavyPunch;
    public void DoSkill(AttackType type) {
        switch (type) {
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
    void SpawnKame() {
        spawnKameha.Spawn();
    }
    void SpawnSkill() { 
        spawnSkill1.DoSpawnSkill1();
    }
    void SpawnUltSkill() {
        spawnUlt.DoUltSkill();
    }
}
