using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckForCombo : MonoBehaviour {
    [SerializeField] protected TakeInputButton inputButton;
    List<string> playerActions = new List<string>();
    public float timeWaitForCombo = 0.5f;
    public string[] requiredCombos = new string[] { "QS", "QD", "QP" };
    public static bool isSpecialAttack = false;
    public UnityEvent<AttackType> specialAttack;
    private void Start() {
        inputButton.firstComboInputEvent.AddListener(TakeFirstInput);
        inputButton.secondComboInputEvent.AddListener(TakeSecondInput);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            TakeFirstInput("Q");
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            TakeSecondInput("S");
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            TakeSecondInput("D");
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            TakeSecondInput("P");
        }
        if (playerActions.Count > 0) 
            isSpecialAttack = true;
        else isSpecialAttack = false;
    }
    public void TakeFirstInput(string input) {
        if (input != "Q") return;
        //Debug.Log("Q");
        RecordAction("Q");
        string[] secondInputs = { "S", "D", "P" };
        StartCoroutine(CheckForSecondInput(secondInputs));
    }
    public void TakeSecondInput(string input) {
        if (playerActions.Count == 0) return; 
        //Debug.Log(input);
        RecordAction(input);
        CheckComboString();
    }
    IEnumerator CheckForSecondInput(string[] input) {
        yield return new WaitForSeconds(timeWaitForCombo);
        foreach (string inputItem in input) {
            if(!playerActions.Contains(inputItem))
                playerActions.Clear();
        }
    }

    void RecordAction(string action) {
        playerActions.Add(action);
    }

    void CheckComboString() {
        string currentActionSequence = string.Join("", playerActions);
        foreach (string combo in requiredCombos) {
            if (currentActionSequence.EndsWith(combo)) {
                ExecuteCombo(currentActionSequence);
                playerActions.Clear();
                return;
            }
        }
        playerActions.Clear();
    }

    void ExecuteCombo(string combo) {
        Debug.Log("Combo executed: " + combo);
        if (combo == "QS")
            specialAttack?.Invoke(AttackType.Kameha);
    }
}
