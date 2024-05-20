using UnityEngine;

public class PlayerController : CharacterController {

    [SerializeField] protected PlayerAttack playerAttack;
    [SerializeField] protected JoystickMovement joystickMovement;
    [SerializeField] private GameObject auraBuff;
    [SerializeField] private PunchCombo punchCombo;

    protected TakeInputButton inputButton;
    private CheckForCombo checkForCombo;
    private GameObject inputButtonObj;
    public float moveSpeed;
    private void Awake() {
        inputButtonObj = GameObject.Find("ButtonInput");
        inputButton = inputButtonObj.GetComponent<TakeInputButton>();
        checkForCombo = inputButtonObj.GetComponentInChildren<CheckForCombo>();
    }
    private void Start()
    {
        AddListener();
    }
    protected void Update() {
        punchCombo.ExitPunchCombo();
        if (CharacterStats.Instance.IsMaxMana(Character.Player) && characterAnimator.currentAnimationState == AnimationState.BuffMana) {
            BuffMana(false);
        }

        CannotExitScreen();

        if (Input.GetKeyDown(KeyCode.Space)) {
            characterAnimator.Play("Spawn");
        }
    }
    #region Move Funcion
    protected override void Move(Vector3 targetPosition) {
        if (!CanMove()) {
            return; 
        }
        if (targetPosition == default) {
            characterAnimator.StopMovement();
            return;
        }
        Vector3 newPosition = transform.position + targetPosition * moveSpeed * Time.deltaTime;
        newPosition = GameManager.Instance.LimitPosition(newPosition);
        characterAnimator.SetMovement(joystickMovement.MoveType());
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * moveSpeed);
    }
    #endregion

    #region Buff Mana + Dash
    protected override void BuffMana(bool onBuff) {
        //if (characterAnimator.currentAnimationState == AnimationState.Attack) return;
        CharacterStats.Instance.ChangeBuffManaState(onBuff, Character.Player);
        characterAnimator.SetBuffMana(onBuff);
        auraBuff.SetActive(onBuff);
    }

    void Dash() {
        if (CanCastSkill(Character.Player, AttackType.Defaut, true)) {
            characterDash.Dash();
            characterAnimator.SetDash();
        }
    }
    void StopDash() {
        characterAnimator.SetIdle();
    }
    #endregion

    #region Attack + Defend
    protected override void Attack(AttackType type) {
        if (type == AttackType.Punch) {
            punchCombo.StartPunch();
            return;
        }
        if (CanAttackInState() && CheckForCombo.isSpecialAttack) {
            DoCastSkill(type, true);
        }
        if (CanAttackInState() && !CheckForCombo.isSpecialAttack) {  
            DoCastSkill(type);
        }
    }
    bool CanAttackInState() {
        return (characterAnimator.currentAnimationState == AnimationState.Idle ||
            characterAnimator.currentAnimationState == AnimationState.Movement ||
            characterAnimator.currentAnimationState == AnimationState.BuffMana);
    }
    void DoCastSkill(AttackType type) {
        if (CanCastSkill(Character.Player, type, false)){
            characterAnimator.SetSkill(type, false);
            playerAttack.DoSkill(type);
        }
    }
    void DoCastSkill(AttackType type, bool isSpecialAtk) {
        if (CanCastSkill(Character.Player, type, false)) {
            BuffMana(false);
            characterAnimator.SetSkill(type, isSpecialAtk);
            playerAttack.DoSkill(type);
            SpecialUnityEvent.Instance.doClearRecordAction?.Invoke();
        }
    }
    protected override void Defend(bool defending) {
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
        characterAnimator.SetTransform();
    }
    #endregion
    bool CanMove() { 
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
        checkForCombo.specialAttack.AddListener(Attack);
        inputButton.isTransform.AddListener(Transform);
    }
}
