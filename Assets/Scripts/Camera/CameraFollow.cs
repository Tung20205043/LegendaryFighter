using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour {
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private float smoothnessFactor;
    private float maxDistanceScaleOffset = 7f;
    private float maxOffset = 4.5f;
    void Update() {
        ZoomInOut();
        UpdateOfset();
    }
    void ZoomInOut() {
        float targetSize;
        if (GameObjectManager.Instance.DistanceBetweenEnemyPlayer() > GameConstant.maxZoomOutDistance) {
            targetSize = 3f;
        } else {
            targetSize = 2f;
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
