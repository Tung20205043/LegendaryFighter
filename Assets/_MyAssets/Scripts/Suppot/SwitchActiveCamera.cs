using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActiveCamera : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera zoomCamera;
    [SerializeField] GameObject gameUI;
    private void OnEnable() {
        mainCamera.gameObject.SetActive(false);
        if (GameObjectManager.Instance.DirectionToEnemy().x < 0)
            zoomCamera.transform.localRotation = Quaternion.Euler(0, 0, 180);
        else 
            zoomCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
        zoomCamera.gameObject.SetActive(true);
        gameUI.SetActive(false);
    }
    private void OnDisable() {
        mainCamera.gameObject.SetActive(true);
        zoomCamera.gameObject.SetActive(false);
        gameUI.SetActive(true);
    }
}
