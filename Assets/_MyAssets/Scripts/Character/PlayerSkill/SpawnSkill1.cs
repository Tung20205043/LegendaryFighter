using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkill1 : SpawnSkillParent
{
    public float timeDelayToSpawn = 0.2f;
    public void DoSpawnSkill1() {
        StartCoroutine(SpawnFromPooling(AttackType.Skill, timeDelayToSpawn, ObjectPoolingForCharacter.ObjectToSpawn.GokuSkill));
    }
    
}
