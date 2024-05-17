using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKameha : SpawnSkillParent
{
    public Vector2 distanceToSpawn;
    public float timeDelayToSpawn;
    [SerializeField] Transform spawnPos;
    public void DoSpawnKameha(Vector3 playerPosition, Vector3 forward, Vector3 up) {
        //StartCoroutine(SpawnFromPooling(playerPosition, forward, up, distanceToSpawn, timeDelayToSpawn, ObjectPoolingForCharacter.ObjectToSpawn.Kameha));
    }
    public void SpawnFromPoolingg(Vector3 playPosition, Vector3 forward, Vector3 up, Vector2 distanceToSpawn, float timeDelayToSpawn, ObjectPoolingForCharacter.ObjectToSpawn objType) {
        ObjectPoolingForCharacter.Instance.SpawnObject(objType, SpawnPosition(playPosition, forward, up, distanceToSpawn), SpawmQuaternion(GameObjectManager.Instance.EnemyObject()));
    }
    public void Spawn() {
        ObjectPoolingForCharacter.ObjectToSpawn objType = ObjectPoolingForCharacter.ObjectToSpawn.Kameha;
        
        ObjectPoolingForCharacter.Instance.SpawnObject(objType, spawnPos.position, SpawmQuaternion(GameObjectManager.Instance.EnemyObject()));
    }

}
