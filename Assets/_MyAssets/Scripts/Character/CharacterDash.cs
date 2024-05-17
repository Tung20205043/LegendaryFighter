using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class CharacterDash : MonoBehaviour
{
    [Header("Dash Value")]
    [SerializeField] private float dashForce = 10f;
    [SerializeField] private float dashDuration = 0.1f;
    [SerializeField] private float dashDelay = 0.5f;
    private bool isDashing = false;

    [Header("Ghost Effect")]
    public float ghostDelaySecond;
    private Coroutine dashEffectCoroutine;

    private Transform player;
    private Rigidbody2D rb;
    public UnityEvent stopDashing;
    void Start() {
        rb = GetComponentInParent<Rigidbody2D>();
        player = GameObjectManager.Instance.PlayerObject().transform;
    }
    public void Dash() {
        StartCoroutine(DashCoroutine());
    }
    IEnumerator DashCoroutine() {
        yield return new WaitForSeconds(dashDelay); 
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
        direction.Normalize();
        rb.velocity = Vector2.zero;
        rb.AddForce(direction * distance, ForceMode2D.Impulse);
    }
    void StopDash() {
        isDashing = false;
        rb.velocity = Vector2.zero;
        stopDashing?.Invoke();
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
                ObjectPoolingForCharacter.Instance.SpawnObject(ObjectPoolingForCharacter.ObjectToSpawn.GhostEffect1, player.position, player.rotation);
            } else {
                ObjectPoolingForCharacter.Instance.SpawnObject(ObjectPoolingForCharacter.ObjectToSpawn.GhostEffect, player.position, player.rotation);
            }

            yield return new WaitForSeconds(ghostDelaySecond);
        }
    }
    Vector2 DirectionToEnemy() {
        return GameObjectManager.Instance.EnemyObject().transform.position - player.transform.position;
    }
}
