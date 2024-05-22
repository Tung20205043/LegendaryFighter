using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffMana : MonoBehaviour
{
    [SerializeField] private GameObject auraBuff;
    public void DoLogicBuffMana(bool onBuff) {
        if (onBuff)
            DoBuffMana();
        else 
            StopBuffMana();
    }
    void DoBuffMana() {
        CharacterStats.Instance.ChangeBuffManaState(true, Character.Player);
        auraBuff.SetActive(true);
    }
    void StopBuffMana() {
        CharacterStats.Instance.ChangeBuffManaState(false, Character.Player);
        auraBuff.SetActive(false);
    }
}
