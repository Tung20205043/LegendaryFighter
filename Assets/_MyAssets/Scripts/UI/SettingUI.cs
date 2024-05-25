using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour {
    [SerializeField] Button xButton;
    [SerializeField] Button[] OnOffButton;

    public/* static*/ bool onMusic = false;
    public /*static*/ bool onSound = false;
    public/* static*/ bool onNotify = false;
    public /*static*/ bool onHaptic = false;

    [SerializeField] private Animator[] onOffAnim;
    private void Awake() {
        xButton.onClick.AddListener(() => this.gameObject.SetActive(false));
        OnOffButton[0].onClick.AddListener(() => OnclickButton(0));
        OnOffButton[1].onClick.AddListener(() => OnclickButton(1));
        OnOffButton[2].onClick.AddListener(() => OnclickButton(2));
        OnOffButton[3].onClick.AddListener(() => OnclickButton(3));
    }
    void OnclickButton(int i) {
        switch (i) {
            case 0:
                onOffAnim[0].SetBool("On", !onMusic);
                onMusic = !onMusic;
                break;
            case 1: 
                onOffAnim[1].SetBool("On", !onSound); 
                onSound = !onSound;
                break;
            case 2:
                onOffAnim[2].SetBool("On", !onNotify); 
                onNotify = !onNotify;
                break;
            case 3:
                onOffAnim[3].SetBool("On", !onHaptic);
                onHaptic = !onHaptic;
                break;
        }
    }
}
