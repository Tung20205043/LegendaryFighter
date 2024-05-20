using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;

//using System.Diagnostics;
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
        inputButton.checkForDelay.AddListener(CheckForDelay);
        SpecialUnityEvent.Instance.doClearRecordAction.AddListener(ClearRecord);
    }
    void Update() {
        isSpecialAttack = (playerActions.Count > 0) ? true : false;
    }
    public void TakeFirstInput(string input) {
        if (input != "Q") return;
        RecordAction("Q");
    }
    public void TakeSecondInput(string input) {
        if (playerActions.Count == 0) return; 
        RecordAction(input);
        CheckComboString();
    }
    void CheckForDelay() {
        string[] secondInputs = { "S", "D", "P" };
        StartCoroutine(CheckForSecondInput(secondInputs));
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
    void ClearRecord() {
        playerActions.Clear();
        Debug.Log("Combo executed" );
    }
    void CheckComboString() {
        string currentActionSequence = string.Join("", playerActions);
        foreach (string combo in requiredCombos) {
            if (currentActionSequence.EndsWith(combo)) {
                ExecuteCombo(currentActionSequence);
                
                return;
            }
        }
        playerActions.Clear();
    }
    void ExecuteCombo(string combo) {
        if (combo == "QS")
            specialAttack?.Invoke(AttackType.Kameha);
        else if (combo == "QD")
            specialAttack?.Invoke(AttackType.Teleport);
    }
    
}
