using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] SpawnSkill1 spawnSkill1;
    [SerializeField] SpawnUltSkill spawnUlt;
    [SerializeField] SpawnKameha spawnKameha;
    [SerializeField] PlayerTeleport playerTeleport;
    [SerializeField] PlayerHeavyPunch playerHeavyPunch;
    [SerializeField] PlayerSuperPunch playerSuperPunch;

    void SpawnKame() {
        PayMana(AttackType.Kameha);
        spawnKameha.Spawn();
    }
    void SpawnSkill() {
        PayMana(AttackType.Skill);
        spawnSkill1.DoSpawnSkill1();
    }
    void SpawnUltSkill() {
        PayMana(AttackType.UltimateSkill);
        spawnUlt.DoUltSkill();
    }
    void Teleport() {
        PayMana(AttackType.Teleport);
        playerTeleport.DoTeleport();
    }
    void HeavyPunch() {
        PayMana(AttackType.HeavyPunch);
        playerHeavyPunch.DoTeleport();
    }
    void SuperPunch() {
        PayMana(AttackType.SuperPunch);
        playerSuperPunch.DoSuperPunch();
    }

    void PayMana(AttackType type) {
        CharacterStats stats = CharacterStats.Instance;
        float manaRequired = GameConstant.manaToCastSkill[(int)type];
        stats.ChangeCurrentMana(Character.Player, -manaRequired);
    }
}
