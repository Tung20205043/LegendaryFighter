using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKameha : SpawnSkillParent
{
    public Vector2 distanceToSpawn;
    public float timeDelayToSpawn;
    public void DoSpawnKameha(Vector3 playerPosition, Vector3 forward, Vector3 up) {
        StartCoroutine(SpawnFromPooling(playerPosition, forward, up, distanceToSpawn, timeDelayToSpawn, ObjectPoolingForCharacter.ObjectToSpawn.Kameha));
    }
}
