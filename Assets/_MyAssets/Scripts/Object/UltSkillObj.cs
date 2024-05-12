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
        if (GameUltis.ExitScreen(this.transform.position)) {
            DeSpawn();
        }
    }
    public void Move() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GameObjectManager.Instance.EnemyObject().transform.position, step);
        //transform.Translate(Vector3.forward * step);
    }
    public void DeSpawn() {
        ObjectPooling.Instance.DeSpawn(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            DeSpawn();
        }
    }
}
