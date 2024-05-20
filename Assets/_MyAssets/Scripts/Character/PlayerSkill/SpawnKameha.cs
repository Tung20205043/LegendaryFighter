using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKameha : SpawnSkillParent
{
    public float timeDelayToSpawn;
    private Vector3 spawnPos;

    public void Spawn() {
        spawnPos = GetPlayerPoint.Instance.KamehaPos;
        ObjectPoolingForCharacter.ObjectToSpawn objType = ObjectPoolingForCharacter.ObjectToSpawn.Kameha;      
        ObjectPoolingForCharacter.Instance.SpawnObject(objType, spawnPos, SpawmQuaternion(GameObjectManager.Instance.EnemyObject()));
    }

}
