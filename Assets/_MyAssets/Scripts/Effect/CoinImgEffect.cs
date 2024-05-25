using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
public class CoinImgEffect : MonoBehaviour
{
    public Image targetImage;  
    public float timeMove = 2f;
    private float targetSize = 55f;
    public float firstTimeMove = 0.5f;
    Vector3 firstTargetPos;
    void OnEnable() {
        MoveToNextPoin();
    }
    private void Update() {
        if (this.transform.localPosition == targetPosition()) {
            ObjectPoolingForCoin.Instance.DeSpawn(this.gameObject);
        }
    }
    void MoveToNextPoin() {
        firstTargetPos = this.transform.localPosition + new Vector3(0, -50f, 0);
        MoveCoin(firstTargetPos, 100, firstTimeMove);
        StartCoroutine(MoveToLastPos());
    }
    IEnumerator MoveToLastPos() { 
        yield return new WaitForSeconds (firstTimeMove);
        MoveCoin(targetPosition(), targetSize, timeMove);
    }
    public void MoveCoin(Vector3 endPosition, float endSize, float time) {
        RectTransform rectTransform = targetImage.GetComponent<RectTransform>();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOLocalMove(endPosition, time)); 
        sequence.Join(rectTransform.DOSizeDelta(new Vector2(endSize, endSize), time));
    }
    Vector3 targetPosition() {
        return SpawnCoinManager.Instance.endPosition.localPosition;
    }
}
