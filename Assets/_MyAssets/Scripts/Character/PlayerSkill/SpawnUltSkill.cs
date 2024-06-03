using System.Collections;
using UnityEngine;

public class SpawnUltSkill : SpawnSkillParent
{
    [SerializeField] private GameObject switchCameraController;
    public float timeZoomCamera = 1.5f;  
    public float timeDelayToSpawn = 0.2f;
    public static bool ultSkillCanMove;
    private void Start() {
        SpecialUnityEvent.Instance.switchCam.AddListener(SwitchCam);
    }
    public void DoUltSkill() {
        ultSkillCanMove = false;
        SwitchCam(timeZoomCamera);
        StartCoroutine(SpawnFromPooling(AttackType.UltimateSkill, timeDelayToSpawn, ObjectPoolingForCharacter.ObjectToSpawn.GokuUltSkill));
    }
    public void SwitchCam(float time) {
        StartCoroutine(SwitchCamera(time));
    }
    IEnumerator SwitchCamera(float time) { 
        switchCameraController.SetActive(true);
        yield return new WaitForSeconds(time);
        switchCameraController.SetActive(false);
        ultSkillCanMove = true;
    }
}
