using UnityEngine;

public class AISpawnUltSkill : MonoBehaviour {
    [SerializeField] CharacterAnimator characterAnimator;
    [SerializeField] AITeleport AITeleport;
    private void Start() {
        AITeleport.endTeleport.AddListener(DoSpawnSkill);
    }
    public void DoSpawnSkill() {
        //characterAnimator.SetSkill(AttackType.UltimateSkill);
    }
}
