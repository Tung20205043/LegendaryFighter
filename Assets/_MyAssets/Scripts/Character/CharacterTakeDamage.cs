using System.Collections;
using UnityEngine;
public class CharacterTakeDamage : MonoBehaviour
{
    #region Ghost Effect
    [Header("Dash Value")]
    [SerializeField] private float dashForce = 10f;
    [SerializeField] private float dashDuration = 0.1f;
    [SerializeField] private float dashDelay = 0.5f;
    private bool isDashing = false;

    [Header("Ghost Effect")]
    public float ghostDelaySecond;
    private Coroutine dashEffectCoroutine;

    //private Transform enemy;
    private Rigidbody2D rb;
    public virtual void Start() {
        //enemy = GameObjectManager.Instance.EnemyObject().transform;
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
        Vector2 direction = DirectionToTarget();
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
            if (DirectionToTarget().x < 0) {
                SpawnGhostEffect(true);
            } else {
                SpawnGhostEffect(false);
                //ObjectPoolingForEnemy.Instance.SpawnObject(ObjectPoolingForEnemy.ObjectToSpawn.TakeDamageGhost1, enemy.position, enemy.rotation);
            }

            yield return new WaitForSeconds(ghostDelaySecond);
        }
    }
    public virtual void SpawnGhostEffect(bool toTheLeft) { 

    }
    Vector2 DirectionToTarget() {
        return GameObjectManager.Instance.EnemyObject().transform.position - GameObjectManager.Instance.PlayerObject().transform.position;
    }
    #endregion
}
