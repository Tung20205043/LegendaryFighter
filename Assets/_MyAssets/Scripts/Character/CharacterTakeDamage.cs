using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterTakeDamage : MonoBehaviour
{
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            DoTakeDamage(TakeDamageType.Type1);
        }
    }
    public void DoTakeDamage(TakeDamageType type) {
        CharacterStats.Instance.TakeDamage(Character.Enemy, CharacterStats.Instance.PlayerAtk);
        if (type == TakeDamageType.Type3) {
            Dash();
        }
    }
    [Header("Dash Value")]
    [SerializeField] private float dashForce = 10f;
    [SerializeField] private float dashDuration = 0.1f;
    [SerializeField] private float dashDelay = 0.5f;
    private bool isDashing = false;

    [Header("Ghost Effect")]
    public float ghostDelaySecond;
    private Coroutine dashEffectCoroutine;

    private Transform enemy;
    private Rigidbody2D rb;
    void Start() {
        enemy = GameObjectManager.Instance.EnemyObject().transform;
        rb = GetComponentInParent<Rigidbody2D>();
    }
    public void Dash() {
        StartCoroutine(DashCoroutine());
    }
    IEnumerator DashCoroutine() {
        DoDashing();
        yield return new WaitForSeconds(dashDelay);
        StopDash();
    }
    void DoDashing() {
        isDashing = true;
        DashDistance(dashForce);
        StartDashEffect();
    }
    public void DashDistance(float distance) {
        Vector2 direction = DirectionToEnemy();
        if (direction == Vector2.zero) 
            direction = new Vector2(1, 0);
        direction.Normalize();
        rb.velocity = Vector2.zero;
        rb.AddForce(direction * distance, ForceMode2D.Impulse);
    }
    void StopDash() {
        isDashing = false;
        rb.velocity = Vector2.zero;
        StopDashEffect();
    }

    void StartDashEffect() {
        if (dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
        dashEffectCoroutine = StartCoroutine(DashEffectCoroutine());
    }
    void StopDashEffect() {
        if (dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
    }
    IEnumerator DashEffectCoroutine() {
        while (true) {
            if (DirectionToEnemy().x < 0) {
                ObjectPoolingForEnemy.Instance.SpawnObject(ObjectPoolingForEnemy.ObjectToSpawn.TakeDamageGhost, enemy.position, enemy.rotation);
            } else {
                ObjectPoolingForEnemy.Instance.SpawnObject(ObjectPoolingForEnemy.ObjectToSpawn.TakeDamageGhost1, enemy.position, enemy.rotation);
            }

            yield return new WaitForSeconds(ghostDelaySecond);
        }
    }
    Vector2 DirectionToEnemy() {
        return enemy.transform.position - GameObjectManager.Instance.PlayerObject().transform.position;
    }
}
