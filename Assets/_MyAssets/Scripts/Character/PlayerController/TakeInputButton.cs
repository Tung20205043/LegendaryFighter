
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TakeInputButton : MonoBehaviour
{
    [SerializeField] HoldButton buffManaButton;
    [SerializeField] Button levelUpButton;
    [SerializeField] Button[] attackButton;
    [SerializeField] Button dashButton;
    [SerializeField] HoldButton defendButton;
    [SerializeField] Button transformButton;

    public UnityEvent<bool> isBuffingMana;
    public UnityEvent<bool> isDefending;
    public UnityEvent isDashing;
    public UnityEvent<AttackType> attacking;
    public UnityEvent isTransform;
    private void Awake() {
        dashButton.onClick.AddListener(Dashing);
        transformButton.onClick.AddListener(DoTransform);
        attackButton[0].onClick.AddListener(() => Attacking(AttackType.Punch));
        attackButton[1].onClick.AddListener(() => Attacking(AttackType.Skill));
        attackButton[2].onClick.AddListener(() => Attacking(AttackType.UltimateSkill));
        attackButton[3].onClick.AddListener(() => Attacking(AttackType.HeavyPunch));

        buffManaButton.holdButton.AddListener(BuffingMana);
        defendButton.holdButton.AddListener(Defending);
        SpecialUnityEvent.Instance.setActiveHeavyPunchButton.AddListener(SetActiveHeavyPunch);
    }
    private void Start() {
            
    }
    private void Update() {
        if (PlayerController.playerState == CharacterState.Ready) return;
        if (Input.GetKeyDown(KeyCode.Q)) {
            BuffingMana(true);
        }
        if (Input.GetKeyUp(KeyCode.Q)) {
            BuffingMana(false);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            Attacking(AttackType.Skill);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            Dashing();
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            Attacking(AttackType.Punch);
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            if (!attackButton[3].IsActive()) return;
            Attacking(AttackType.HeavyPunch);
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            Attacking(AttackType.UltimateSkill);
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            Defending(true);
        }
        if (Input.GetKeyUp(KeyCode.W)) {
            Defending(false);
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            DoTransform();
        }
    }
    public void BuffingMana(bool state) {
        if (PlayerController.playerState == CharacterState.Ready) return;
        isBuffingMana?.Invoke(state);
    }
    public void Defending(bool state) {
        if (PlayerController.playerState == CharacterState.Ready) return;
        isDefending?.Invoke(state);
    }
    public void Attacking(AttackType type) {
        if (PlayerController.playerState == CharacterState.Ready) return;
        attacking?.Invoke(type);
    }
    public void Dashing() {
        if (PlayerController.playerState == CharacterState.Ready) return;
        isDashing?.Invoke();
    }
    void SetActiveHeavyPunch() {
        if (CharacterStats.Instance.PlayerMana >= GameConstant.manaToCastSkill[(int)AttackType.HeavyPunch]) {
            attackButton[3].gameObject.SetActive(true);
        }
    }
    void DoTransform() {
        if (PlayerController.playerState == CharacterState.Ready) return;
        isTransform?.Invoke();
    }
    
}
