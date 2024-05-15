using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkill1 : SpawnSkillParent
{
    public Vector2 distanceToSpawn = new Vector2(0.2f, 0.05f);
    public float timeDelayToSpawn = 0.2f;
    public void DoSpawnSkill1(Vector3 playerPosition, Vector3 forward, Vector3 up) {
        StartCoroutine(SpawnFromPooling(playerPosition, forward, up, distanceToSpawn, timeDelayToSpawn, ObjectPoolingForGoku.ObjectToSpawn.GokuSkill));
    }
    
}
