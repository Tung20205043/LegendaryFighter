using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharChooseUI : UIParent {
    [SerializeField] Button nextButton;
    protected override void Awake() {
        base.Awake();
        nextButton.onClick.AddListener(LoadNextScene);
    }
    void LoadNextScene() {
        SceneManager.LoadScene(1);
    }
}
