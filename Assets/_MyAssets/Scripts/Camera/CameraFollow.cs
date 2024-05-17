using Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private float smoothnessFactor;
    public float maxZoomOutDistance = 2f;
    public float maxDistanceScaleOffset = 7f;
    public float maxOffset = 4.5f;
    private void Awake() {
        _camera.Follow = GameObject.FindWithTag("Player").transform;
    }
    void Update() {
        ZoomInOut();
        UpdateOfset();
    }
    void ZoomInOut() {
        float targetSize;
        if (GameObjectManager.Instance.DistanceBetweenEnemyPlayer() > maxZoomOutDistance) {
            targetSize = 2f;
        } else {
            targetSize = 1f;
        }
        float newSize = Mathf.Lerp(_camera.m_Lens.OrthographicSize, targetSize, Time.deltaTime * smoothnessFactor);
        _camera.m_Lens.OrthographicSize = newSize;
    }
    void UpdateOfset() {
        float targetOffset;
        CinemachineFramingTransposer framingTransposer = _camera.GetCinemachineComponent<CinemachineFramingTransposer>();
        if (GameObjectManager.Instance.DistanceBetweenEnemyPlayer() <= maxDistanceScaleOffset) {
            targetOffset = GameObjectManager.Instance.DistanceBetweenEnemyPlayer() / maxDistanceScaleOffset * maxOffset;
        } else 
            targetOffset = maxOffset;
        framingTransposer.m_TrackedObjectOffset = new Vector3(targetOffset, 0, 0);
    }
}
