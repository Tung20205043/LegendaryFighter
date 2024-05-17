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
        if (CharacterStats.Instance.IsMaxMana(Character.Player) && characterAnimator.currentAnimationState == AnimationState.BuffMana) {
            BuffMana(false);
        }
        if (characterAnimator.currentAnimationState == AnimationState.Attack) {
            BuffMana(false);
        }
        punchCombo.ExitPunchCombo();
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
    //bool CancelBuffMana() { 
    //}
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
        if (CanAttack()) {  
            DoCastSkill(type);
        }
    }
    bool CanAttack() {
        return (characterAnimator.currentAnimationState == AnimationState.Idle ||
            characterAnimator.currentAnimationState == AnimationState.Movement ||
            characterAnimator.currentAnimationState == AnimationState.BuffMana);
    }
    void DoCastSkill(AttackType type) {
        if (CanCastSkill(Character.Player, type, false)){
            characterAnimator.SetSkill(type);
            playerAttack.DoSpawnSkill(type, transform.position, transform.forward, transform.up);
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
    }
    [SerializeField] SpawnKameha spawnKameha;
    void SpawnKame() {
        spawnKameha.Spawn();
    }
}
