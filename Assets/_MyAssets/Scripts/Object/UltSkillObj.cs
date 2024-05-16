using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltSkillObj : MonoBehaviour, ISkillObj
{
    private void OnEnable() {
    }
    public float speed = 10f;
    private void Update() {
        if (!SpawnUltSkill.ultSkillCanMove) return;
        Move();
    }
    public void Move() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GameObjectManager.Instance.EnemyObject().transform.position, step);
    }
    public void DeSpawn() {
        ObjectPoolingForCharacter.Instance.DeSpawn(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            DeSpawn();
        }
    }
}
