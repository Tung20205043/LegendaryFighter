using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Playables;

public class EnemyController : CharacterController {
    private TakeInputButton inputButton;
    [SerializeField] GameObject inputButtonObj;
    [SerializeField] CharacterController player;
    [SerializeField] PunchComboAI punchComboAI;
    [SerializeField] EnemyTakeDamage enemyTakeDamage;
    [SerializeField] GameObject manaAura;
    [SerializeField] float speed;
    [SerializeField] float atkRange;
    public CharacterState enemyState;
    private void Awake() {
        inputButtonObj = GameObject.Find("ButtonInput");
        inputButton = inputButtonObj.GetComponent<TakeInputButton>();
    }
    protected override void OnEnable() {
        base.OnEnable();
        enemyState = CharacterState.Ready;
    }
    private void Start() {
        inputButton.attacking.AddListener(CallDefend);
        inputButton.isBuffingMana.AddListener(BuffMana);
        inputButton.isDefending.AddListener(BuffMana);
        SpecialUnityEvent.Instance.readyToFight.AddListener(ChangeState);
    }
    private void Update() {
        CannotExitScreen();

        if (GameModeManager.Instance.currentGameMode == GameMode.Train) return;

        if (enemyState == CharacterState.Ready) return;
        //BuffMana(!FullMana());
        if (FullMana() && IsOnMovement())
            Move(TargetPos());
        if (Direction(TargetPos()) < atkRange) {
            characterAnimator.SetIdle();
            characterAnimator.StopMovement();   
        }
    }
    void ChangeState() {
        enemyState = CharacterState.Fight;
    }
    bool FullMana() {
        return (CharacterStats.Instance.IsMaxMana(Character.Enemy));
    }
    protected override void Move(Vector3 targetPosition) {
        Vector3 currentPosition = transform.position;
        Vector3 direction = targetPosition - transform.position;
        if (Direction(targetPosition) > atkRange) {
            Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
            Vector3 newPosition = currentPosition + moveVector;

            if ((targetPosition - newPosition).magnitude < moveVector.magnitude) {
                newPosition = targetPosition;
            }

            transform.position = newPosition;
            characterAnimator.SetMovement(MovementType.Forward);
        }
    }
    protected override void Attack(AttackType type) {
        throw new System.NotImplementedException();
    }
    protected override void BuffMana(bool buff) {
        if (GameModeManager.Instance.currentGameMode == GameMode.Train) return;

        if (FullMana() && buff) return;
        CharacterStats.Instance.ChangeBuffManaState(buff, Character.Enemy);
        characterAnimator.SetBuffMana(buff);
        manaAura.SetActive(buff);
    }
    void CallDefend(AttackType type) {
        //Defend(true);
    }
    protected override void Defend(bool defending) {
        characterAnimator.SetDefend(defending);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("PlayerNormalSkill")) {
            enemyTakeDamage.DoTakeDamage(TakeDamageType.NormalSkill);
        }
        if (collision.CompareTag("PlayerHeavySkill")) {
            enemyTakeDamage.DoTakeDamage(TakeDamageType.HeavySkill);
        }
    }
    protected override void Die() {
        if (CharacterStats.Instance.EnemyHp <= 0) {
            characterAnimator.SetDie();
        }
    }
    bool IsOnMovement() {
        return (characterAnimator.currentAnimationState == AnimationState.Idle ||
            characterAnimator.currentAnimationState == AnimationState.Movement);
    }
    float Direction(Vector3 targetPosition) {
        Vector3 direction = targetPosition - transform.position;
        float distance = direction.magnitude;
        return distance;
    }
    Vector3 TargetPos() {
        return GameObjectManager.Instance.PlayerObject().transform.position;
    }
    void Ready() {
        SpecialUnityEvent.Instance.enemyIsReady?.Invoke();
    }

}
