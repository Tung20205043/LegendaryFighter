using System.Collections;
using UnityEngine;

public class SpawnUltSkill : SpawnSkillParent
{
    [SerializeField] private GameObject switchCameraController;
    public float timeZoomCamera = 1.5f;  
    public float timeDelayToSpawn = 0.2f;
    public static bool ultSkillCanMove;
    public void DoUltSkill() {
        ultSkillCanMove = false;
        StartCoroutine(SwitchCamera());
        StartCoroutine(SpawnFromPooling(AttackType.UltimateSkill, timeDelayToSpawn, ObjectPoolingForCharacter.ObjectToSpawn.GokuUltSkill));
    }
    IEnumerator SwitchCamera() { 
        switchCameraController.SetActive(true);
        yield return new WaitForSeconds(timeZoomCamera);
        switchCameraController.SetActive(false);
        ultSkillCanMove = true;
    }
}
