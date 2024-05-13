using System.Collections;
using UnityEngine;

public class KamehaBodyObj : MonoBehaviour {
    public float startWidth = 0f;
    public float targetSize = 100f;
    public float time = 2f;
    private SpriteRenderer spriteRenderer;
    private Vector2 originalSize;
    public bool upSize = true;
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable() {
        if (spriteRenderer != null) {
            spriteRenderer.drawMode = SpriteDrawMode.Sliced;
            originalSize = spriteRenderer.size;
            originalSize.x = 0f;
            if (upSize) {
                StartCoroutine(SmoothChangeSize(originalSize.x, targetSize, time));
            }
        }
    }

    private void OnDisable() {
        StopAllCoroutines();
    }
    private IEnumerator SmoothChangeSize(float startSize, float targetSize, float duration) {
        float elapsedTime = 0f;
        while (elapsedTime < duration) {
            float t = elapsedTime / duration;
            float newSize = Mathf.Lerp(startSize, targetSize, t);
            spriteRenderer.size = new Vector2(newSize, originalSize.y);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.size = new Vector2(targetSize, originalSize.y);

        if (!upSize) {
            spriteRenderer.size = originalSize;
        }
    }
    public float speed = 10f;
    private void Update() {
        Move();
    }
    public void Move() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GameObjectManager.Instance.EnemyObject().transform.position, step);
    }

}
