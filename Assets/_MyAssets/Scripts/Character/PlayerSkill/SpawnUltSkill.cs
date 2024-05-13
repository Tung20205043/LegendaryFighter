using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUltSkill : SpawnSkillParent
{
    [SerializeField] GameObject switchCameraController;
    public float timeZoomCamera = 1.5f;
    public Vector2 distanceToSpawn = new Vector2(0f, 0.2f);
    public float timeDelayToSpawn = 0.2f;
    public static bool ultSkillCanMove;
    public void DoUltSkill(Vector3 playerPos, Vector3 forward, Vector3 up) {
        ultSkillCanMove = false;
        StartCoroutine(SwitchCamera());
        StartCoroutine(SpawnFromPooling(playerPos, forward, up, distanceToSpawn, timeDelayToSpawn, 3));
    }
    IEnumerator SwitchCamera() { 
        switchCameraController.SetActive(true);
        yield return new WaitForSeconds(timeZoomCamera);
        switchCameraController.SetActive(false);
        ultSkillCanMove = true;
    }

}
