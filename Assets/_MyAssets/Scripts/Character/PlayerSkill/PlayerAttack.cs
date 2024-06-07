using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] SpawnSkill1 spawnSkill1;
    [SerializeField] SpawnUltSkill spawnUlt;
    [SerializeField] SpawnKameha spawnKameha;
    [SerializeField] PlayerTeleport playerTeleport;
    [SerializeField] PlayerHeavyPunch playerHeavyPunch;
    [SerializeField] PlayerSuperPunch playerSuperPunch;

    protected virtual void SpawnKame() {
        PayMana(AttackType.Kameha);
        spawnKameha.Spawn();
    }
    protected virtual void SpawnSkill() {
        PayMana(AttackType.Skill);
        spawnSkill1.DoSpawnSkill1();
    }
    protected virtual void SpawnUltSkill() {
        PayMana(AttackType.UltimateSkill);
        spawnUlt.DoUltSkill();
    }
    protected virtual void Teleport() {
        PayMana(AttackType.Teleport);
        playerTeleport.DoTeleport();
    }
    protected virtual void HeavyPunch() {
        PayMana(AttackType.HeavyPunch);
        playerHeavyPunch.DoTeleport();
    }
    protected virtual void SuperPunch() {
        PayMana(AttackType.SuperPunch);
        playerSuperPunch.DoSuperPunch();
    }

    protected virtual void PayMana(AttackType type) {
        CharacterStats stats = CharacterStats.Instance;
        float manaRequired = GameConstant.manaToCastSkill[(int)type];
        stats.ChangeCurrentMana(Character.Player, -manaRequired);
    }
}
