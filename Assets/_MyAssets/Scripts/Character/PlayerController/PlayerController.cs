using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerController : CharacterController {

    [SerializeField] protected PlayerAttack playerAttack;
    [SerializeField] protected JoystickMovement joystickMovement;
    [SerializeField] private PunchCombo punchCombo;
    [SerializeField] protected PlayerBuffMana playerBuffMana;
    [SerializeField] protected PlayerTransform playerTransform;

    protected TakeInputButton inputButton;
    private GameObject inputButtonObj;
    public float moveSpeed;
    public static CharacterState playerState;
    private void Awake() {
        inputButtonObj = GameObject.Find("ButtonInput");
        inputButton = inputButtonObj.GetComponent<TakeInputButton>();
    }
    private void Start() {
        AddListener();
    }
   protected override void OnEnable() {
        base.OnEnable();
        playerState = CharacterState.Ready;
    }
    protected void Update() {
        punchCombo.ExitPunchCombo();
        if (CharacterStats.Instance.IsMaxMana(Character.Player) && characterAnimator.currentAnimationState == AnimationState.BuffMana) {
            BuffMana(false);
        }

        CannotExitScreen();
    }
    #region Move Funcion
    protected override void Move(Vector3 targetPosition) {
        if (!IsOnMovement()) {
            return;
        }
        if (targetPosition == default) {
            characterAnimator.StopMovement();
            return;
        }
        Vector3 newPosition = transform.position + targetPosition * moveSpeed * Time.deltaTime;
        newPosition = GamePositionManager.Instance.LimitPosition(newPosition);
        characterAnimator.SetMovement(joystickMovement.MoveType());
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * moveSpeed);
    }
    #endregion

    #region Buff Mana + Dash
    protected override void BuffMana(bool onBuff) {
        if (onBuff && !IsOnMovement()) return;
        if (!onBuff && characterAnimator.currentAnimationState != AnimationState.BuffMana) return;
        characterAnimator.SetBuffMana(onBuff);
        playerBuffMana.DoLogicBuffMana(onBuff);
    }

    void Dash() {
        DoSpecialSKill(AttackType.Teleport);
        if (!IsOnMovement()) return;
        if (CanDash(Character.Player)) {
            characterDash.Dash();
            characterAnimator.SetDash(true);
        }
    }
    void StopDash() {
        characterAnimator.SetDash(false);
    }
    #endregion

    #region Attack + Defend
    protected override void Attack(AttackType type) {
        if (type == AttackType.Skill)
            DoSpecialSKill(AttackType.Kameha);
        if (type == AttackType.Punch)
            DoSpecialSKill(AttackType.SuperPunch);
        if (type == AttackType.Punch && (IsOnMovement() || characterAnimator.currentAnimationState == AnimationState.Punch)) {
            punchCombo.StartPunch();
            return;
        }
        if (!IsOnMovement()) return;
        if (CanCastSkill(Character.Player, type)) {
            DoCastSkill(type);
        }
    }
    void DoCastSkill(AttackType type) {
        characterAnimator.SetSkill(type);
    }
    void DoSpecialSKill(AttackType type) {
        if (characterAnimator.currentAnimationState == AnimationState.BuffMana
            && CanCastSkill(Character.Player, type)) {
            characterAnimator.SetSpecialSkill(type);
            playerBuffMana.DoLogicBuffMana(false);
            DoCastSkill(type);
            return;
        }
    }
    void DoComboPunch() {
        characterAnimator.DoComboPunch();
    }
    protected override void Defend(bool defending) {
        if (defending && !IsOnMovement()) return;
        if (!defending && characterAnimator.currentAnimationState != AnimationState.Defend) return;
        characterAnimator.SetDefend(defending);
    }
    #endregion

    #region Take Damage + Die
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("EnemySkill")) {
            characterAnimator.SetTakeDamage((TakeDamageType)1);
        }
    }
    protected override void Die() {
        throw new System.NotImplementedException();
    }
    #endregion

    #region Transform
    void Transform() {
        if (!IsOnMovement()) return;
        characterAnimator.SetTransform();
        SpecialUnityEvent.Instance.switchCam?.Invoke(3f);
    }
    public void DoTransform() {
        playerTransform.Transform();
    }

    #endregion
    bool IsOnMovement() {
        return (characterAnimator.currentAnimationState == AnimationState.Idle ||
            characterAnimator.currentAnimationState == AnimationState.Movement);
    }
    void AddListener() {
        joystickMovement.moveDirection.AddListener(Move);
        inputButton.isBuffingMana.AddListener(BuffMana);
        inputButton.isDashing.AddListener(Dash);
        characterDash.stopDashing.AddListener(StopDash);
        inputButton.attacking.AddListener(Attack);
        inputButton.isDefending.AddListener(Defend);
        inputButton.isTransform.AddListener(Transform);
        SpecialUnityEvent.Instance.doComboPunch.AddListener(DoComboPunch);
        SpecialUnityEvent.Instance.readyToFight.AddListener(ChangeState);
    }
    void ChangeState() {
        playerState = CharacterState.Fight;
    }
    void Ready() {
        SpecialUnityEvent.Instance.playerIsReady?.Invoke();
    }
}
