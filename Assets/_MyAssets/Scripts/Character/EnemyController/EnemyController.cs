using UnityEngine;

public class EnemyController : CharacterController
{
    private TakeInputButton inputButton;
    [SerializeField] GameObject inputButtonObj;
    [SerializeField] CharacterController player;
    [SerializeField] PunchComboAI punchComboAI;
    [SerializeField] EnemyTakeDamage enemyTakeDamage;
    private void Awake() {
        inputButtonObj = GameObject.Find("ButtonInput");
        inputButton = inputButtonObj.GetComponent<TakeInputButton>();
    }
    private void Start() {
        inputButton.attacking.AddListener(CallDefend);
        inputButton.isBuffingMana.AddListener(BuffMana);
        inputButton.isDefending.AddListener(BuffMana);
    }
    private void Update() {
        if (CantBuffMana()) {
            BuffMana(false);
        }
        Die();
        CannotExitScreen();
        if (player.characterAnimator.currentAnimationState != AnimationState.Defend) {
            //Debug.Log("Attack Player");
        }
        //Debug.Log(CantBuffMana());

        if (Input.GetKeyDown(KeyCode.Space)) {
            characterAnimator.Play("SpawnAnim");
        }
    }
    bool CantBuffMana() { 
        return (CharacterStats.Instance.IsMaxMana(Character.Enemy)) ;
    }
    protected override void Move(Vector3 position) {
        throw new System.NotImplementedException();
    }
    protected override void Attack(AttackType type) {
        throw new System.NotImplementedException();
    }
    protected override void BuffMana(bool buff) {
        if (CantBuffMana() && buff) return;
        CharacterStats.Instance.ChangeBuffManaState(buff, Character.Enemy);
        //characterAnimator.SetBuffMana(buff, );
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
}
