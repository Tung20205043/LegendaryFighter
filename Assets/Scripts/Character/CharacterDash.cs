using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.U2D.Aseprite;
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
    public GameObject ghostEffect;
    public float ghostDelaySecond;
    private Coroutine dashEffectCoroutine;
    [SerializeField] private Transform parentToSpawnGhostEffect;

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
        Vector2 direction = DirectionToEnemy();
        direction.Normalize();
        rb.velocity = Vector2.zero;
        rb.AddForce(direction * dashForce, ForceMode2D.Impulse);

        StartDashEffect();
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
    Vector3 ghostEffRotation;
    IEnumerator DashEffectCoroutine() {
        while (true)
        {
            if (DirectionToEnemy().x < 0) {
                ghostEffRotation = new Vector3(0, player.rotation.eulerAngles.y, player.rotation.eulerAngles.z);
            }
            else ghostEffRotation = new Vector3(0, player.rotation.eulerAngles.y, player.rotation.eulerAngles.z);
            Quaternion rotationQuaternion = Quaternion.Euler(ghostEffRotation);

            GameObject ghost = Instantiate(ghostEffect, player.position, player.rotation, parentToSpawnGhostEffect);
            //Destroy(ghost,0.5f);
            yield return new WaitForSeconds(ghostDelaySecond);
        }
    }
    Vector2 DirectionToEnemy() {
        return GameObjectManager.Instance.EnemyObject().transform.position - player.transform.position;
    }
}
